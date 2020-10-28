using Server.DTO;
using Server.Models;
using Server.Repository.Interface;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Server.Service
{
    public class CommentService : ICommentService
    {
        ICommentRepository _repository { get; set; }

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CommentDTO> GetAllCommentsByVideoId(int videoId)
        {
            try
            {
                var comments = _repository.GetAllCommentsByVideoId(videoId);

                return comments;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }

        public Comment Insert(Comment comment)
        {
            try
            {
                if ((comment.Id = _repository.Insert(comment)) != 0)
                {
                    return comment;
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }

        public Comment Update(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return null;
            }

            try
            {
                _repository.Update(comment);
                return comment;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }

        public bool Delete(int id)
        {
            var comment = _repository.GetCommentById(id);

            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            if (identity == null)
            {
                return false;
            }

            if (comment == null)
            {
                return false;
            }
            try
            {
                if (identity.Name == comment.UserId.ToString())
                {
                    _repository.Delete(comment);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return false;
            }
        }
    }
}