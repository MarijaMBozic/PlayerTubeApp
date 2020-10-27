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
    public class VideoRepository : IVideoRepository
    {
        public IEnumerable<Video> GetAllVideo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Video> GetAllVideoByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Video GetVideoById(int songId)
        {
            throw new NotImplementedException();
        }

        public int Insert(Video video)
        {
            int videoId = 0;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_NewVideo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VideoName", video.Name);
                        cmd.Parameters.AddWithValue("@VideoPath", video.Path);
                        cmd.Parameters.AddWithValue("@Description", video.Description);
                        cmd.Parameters.AddWithValue("@UserId", video.UserId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            videoId = int.Parse(reader.GetValue(0).ToString());
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
            return videoId;
        }

        public void Update(Video song)
        {
            throw new NotImplementedException();
        }

        public void Delete(Video song)
        {
            throw new NotImplementedException();
        }
    }
}