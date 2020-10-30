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
    public class CommentRepository : ICommentRepository
    {
        public string ConnectionString { get; private set; }

        public CommentDTO GetCommentById(int id)
        {
            CommentDTO response = null;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_CommentsById";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            CommentDTO comment = new CommentDTO
                            {
                                Id = int.Parse(row[0].ToString()),
                                Content = row[1].ToString(),
                                CreateDate = DateTime.Parse(row[2].ToString()),                                
                                Username = row[3].ToString(), 
                                UserId= int.Parse(row[4].ToString()), 
                                ParentComment=int.Parse(row[5].ToString())
                            };
                            response = comment;
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

        public IEnumerable<CommentDTO> GetAllCommentsByVideoId(int videoId)
        {
            List<CommentDTO> commentList = new List<CommentDTO>();

            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllCommentsByVideoId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VideoId", videoId);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            CommentDTO comment = new CommentDTO
                            {
                                Id = int.Parse(row[0].ToString()),
                                Content = row[1].ToString(),
                                CreateDate = DateTime.Parse(row[2].ToString()),                               
                                Username = row[3].ToString(),
                                ParentComment = int.Parse(row[4].ToString()),
                                CommentLikes = int.Parse(row[5].ToString()),
                                Unlikes = int.Parse(row[6].ToString())
                            };
                            commentList.Add(comment);
                        }
                        return commentList;
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

        public IEnumerable<CommentDTO> Get_AllCommentsByVideoIdAndParentComment(int videoId, int parentCommentId)
        {
            List<CommentDTO> commentList = new List<CommentDTO>();

            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllCommentsByVideoIdAndParentComment";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VideoId", videoId);
                        cmd.Parameters.AddWithValue("@ParentComment", parentCommentId);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            CommentDTO comment = new CommentDTO
                            {
                                Id = int.Parse(row[0].ToString()),
                                Content = row[1].ToString(),
                                CreateDate = DateTime.Parse(row[2].ToString()),
                                Username = row[3].ToString(),
                                ParentComment = int.Parse(row[4].ToString()),
                                CommentLikes = int.Parse(row[5].ToString()),
                                Unlikes = int.Parse(row[6].ToString())
                            };
                            commentList.Add(comment);
                        }
                        return commentList;
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

        public IEnumerable<int> GetAllCommentsByParentId(int commentId)
        {
            List<int> listOfChiledCommentsId = new List<int>();
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_AllCommentsByParentId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", commentId);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {

                            int Id = int.Parse(row[0].ToString());
                            listOfChiledCommentsId.Add(Id);
                        }
                        return listOfChiledCommentsId;
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

        public bool? GetLikeInfo(int userId, int commentId)
        {
            bool? response = null;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Get_LikeByUserIdAndCommentId";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@CommentId", commentId);
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

        public int Insert(Comment comment)
        {
            int commentId = 0;
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert_NewComment";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Content", comment.Content);
                        cmd.Parameters.AddWithValue("@UserId", comment.UserId);
                        cmd.Parameters.AddWithValue("@VideoId", comment.VideoId);
                        cmd.Parameters.AddWithValue("@VideoId", comment.ParentComment);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            commentId = int.Parse(reader.GetValue(0).ToString());
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
            return commentId;
        }

        public void Update(Comment comment)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Update_Comment";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", comment.Id);
                        cmd.Parameters.AddWithValue("@Content", comment.Content);
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

        public void Delete(int commentId)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Delete_Comment";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", commentId);
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

        public void Like(int userId, int commentId, bool like)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Like_Comment";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@CommentId", commentId);
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

   

        public bool DeleteLike(int userId, int commentId)
        {
            using (SqlConnection conn = ConnectionHelper.GetNewConnection())
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Delete_Like";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@CommentId", commentId);
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