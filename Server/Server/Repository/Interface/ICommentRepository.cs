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
        CommentDTO GetCommentById(int commentId);
        int Insert(Comment comment);
        void Update(Comment comment);
        void Delete(CommentDTO comment);
        void Like(int userId, int commentId, bool like);
    }
}
