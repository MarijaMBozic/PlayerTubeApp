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
    public class SubscriberRepository : ISubscriberRepository
    {
        public IEnumerable<SubscriberDTO> GetAllSubscribersEmailByUser(int userId)
        {
            List<SubscriberDTO> subscriberList = new List<SubscriberDTO>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllSubscriberByUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {                            
                            SubscriberDTO subscriber = new SubscriberDTO
                            {
                                SubscriberEmail = row[0].ToString(),
                            };
                            subscriberList.Add(subscriber);
                        }
                        return subscriberList;
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

        public int Insert(SubscriberDTO subscriber)
        {
            int subscribtionId = 0;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_NewSubscriber";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", subscriber.UserId);
                        cmd.Parameters.AddWithValue("@SubscriberId", subscriber.SubscriberId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            subscribtionId = int.Parse(reader.GetValue(0).ToString());
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
            return subscribtionId;
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Delete_Subscriber";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SubscriberId", id);
                        cmd.ExecuteNonQuery();
                        return true;
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

        public bool CheckSubscription(SubscriberDTO subscriber)
        {
            bool response=false;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Check_Subscribtion";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", subscriber.UserId);
                        cmd.Parameters.AddWithValue("@SubscriberId", subscriber.SubscriberId);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            SubscriberDTO sub = new SubscriberDTO
                            {
                                Id = int.Parse(row[0].ToString()),
                            };

                            if(sub.Id!=0)
                            {
                                response = true;
                            }                            
                        }
                        return response;
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