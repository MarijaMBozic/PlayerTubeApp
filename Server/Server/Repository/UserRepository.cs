using Server.Helper;
using Server.Models;
using Server.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Server.Repository
{
    public class UserRepository : IUserRepository
    {
        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }
        public bool CheckUsername(string username)
        {
            int userId = 0;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_Username";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            userId = int.Parse(reader.GetValue(0).ToString());
                            return true;
                        }
                        return false;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public bool CheckEmail(string userEmail)
        {
            int userId = 0;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_Email";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", userEmail);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            userId = int.Parse(reader.GetValue(0).ToString());
                            return true;
                        }
                        return false;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int Insert(User user)
        {
            int userId = 0;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_NewUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Password", HashPasswordHelper.HashPassword(user.Password));
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            userId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return userId;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}