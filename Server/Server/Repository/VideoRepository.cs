using Server.DTO;
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
        public IEnumerable<VideoDTO> GetAllVideos()
        {
            List<VideoDTO> videoList = new List<VideoDTO>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllVideos";
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            VideoDTO video = new VideoDTO
                            {
                                Id = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                                Views = int.Parse(row[2].ToString()),
                                Path = row[3].ToString(),
                                Description = row[4].ToString(),
                                Username = row[5].ToString(),
                                UserId = int.Parse(row[6].ToString()),
                                VideoLikes = int.Parse(row[7].ToString()),
                                Unlikes = int.Parse(row[8].ToString())
                            };
                            videoList.Add(video);
                        }
                        return videoList;
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

        public IEnumerable<VideoDTO> GetAllVideoByUserId(int userId)
        {
            List<VideoDTO> videoList = new List<VideoDTO>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllVideoByUserId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            VideoDTO video = new VideoDTO
                            {
                                Id = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                                Views = int.Parse(row[2].ToString()),
                                Path = row[3].ToString(),
                                Description = row[4].ToString(),
                                Username = row[5].ToString(),
                                UserId = int.Parse(row[6].ToString()),
                                VideoLikes= int.Parse(row[7].ToString()),
                                Unlikes= int.Parse(row[8].ToString())
                            };
                            videoList.Add(video);
                        }
                        return videoList;
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

        public VideoDTO GetVideoById(int videoId)
        {
            VideoDTO response = null;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_VideoById";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", videoId);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            VideoDTO video = new VideoDTO
                            {
                                Id = int.Parse(row[0].ToString()),
                                Name = row[1].ToString(),
                                Views = int.Parse(row[2].ToString()),
                                Path = row[3].ToString(),
                                Description = row[4].ToString(),
                                Username = row[5].ToString(),
                                UserId = int.Parse(row[6].ToString())
                            };
                            response = video;
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

        public void Update(Video video)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Update_Video";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", video.Id);
                        cmd.Parameters.AddWithValue("@Name", video.Name);
                        cmd.Parameters.AddWithValue("@Description", video.Description);
                        cmd.ExecuteNonQuery();
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

        public bool Delete(int id)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Delete_Video";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
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

        public void Like(int userId, int videoId, bool like)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Like_Video";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@VideoId", videoId);
                        cmd.Parameters.AddWithValue("@IsLiked", like);
                        cmd.ExecuteNonQuery();
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

        public void View(int numberOfViews, int videoId)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Update_VideoViews";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", videoId);
                        cmd.Parameters.AddWithValue("@Views", numberOfViews);
                        cmd.ExecuteNonQuery();
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

        public bool? GetLikeInfo(int userId, int videoId)
        {
            bool? response = null;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_LikeByUserIdAndVideoId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@VideoId", videoId);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            response = bool.Parse(row[0].ToString());
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

        public bool DeleteLike(int userId, int videoId)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Delete_LikeVideo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@VideoId", videoId);
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
    }
}