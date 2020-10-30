using Server.DTO;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository.Interface
{
    public interface ICommentRepository
    {
        IEnumerable<CommentDTO> GetAllCommentsByVideoId(int videoId);
        IEnumerable<CommentDTO> Get_AllCommentsByVideoIdAndParentComment(int videoId, int parentCommentId);
        IEnumerable<int> GetAllCommentsByParentId(int commentId);
        CommentDTO GetCommentById(int commentId);
        int Insert(Comment comment);
        void Update(Comment comment);
        void Delete(int commentId);
        void Like(int userId, int commentId, bool like);
        bool? GetLikeInfo(int userId, int commentId);
        bool DeleteLike(int userId, int commentId);
    }
}
