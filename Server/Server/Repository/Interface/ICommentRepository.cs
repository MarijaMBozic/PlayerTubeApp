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
        CommentDTO GetCommentById(int commentId);
        int Insert(Comment comment);
        void Update(Comment comment);
        void Delete(CommentDTO comment);
    }
}
