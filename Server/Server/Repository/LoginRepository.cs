using Server.DTO;
using Server.Helper;
using Server.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Server.Repository
{
    public class LoginRepository : ILoginRepository
    {
        public LoginDataDTO Login(string email, string password)
        {
            LoginDataDTO user = null;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_LoginData";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", HashPasswordHelper.HashPassword(password));
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            LoginDataDTO loginUser = new LoginDataDTO
                            {
                                Id = int.Parse(row[0].ToString()),
                                Username = row[1].ToString(),
                            };
                            user = loginUser;
                        }
                        return user;
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
    }
}