using Server.DTO;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Interface
{
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetAllCommentsByVideoId(int videoId);
        IEnumerable<CommentDTO> Get_AllCommentsByVideoIdAndParentComment(int videoId, int parentCommentId);
        Comment Insert(Comment comment);
        Comment Update(int id, Comment comment);
        bool Delete(int id);
        void DeleteChildeComments(int commentId);
        bool Like(int commentId, bool like);
    }
}
