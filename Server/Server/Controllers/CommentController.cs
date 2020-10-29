using Server.DTO;
using Server.Helper.AutorizationHelper;
using Server.Models;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Server.Controllers
{
    public class CommentController : ApiController
    {
        ICommentService _service { get; set; }

        public CommentController(ICommentService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public IEnumerable<CommentDTO> GetAllCommentsBySongId(int videoId)
        {
            return _service.GetAllCommentsByVideoId(videoId);
        }

        [JwtAuthentication]        
        public IHttpActionResult Post(Comment comment)
        {
            if (!ModelState.IsValid)
            {                
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Input data is not valid")),
                });
            }

            comment = _service.Insert(comment);
            return CreatedAtRoute("DefaultApi", new { id = comment.Id }, comment);
        }

        [JwtAuthentication]
        public IHttpActionResult Put(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Input data is not valid")),
                });
            }

            if (_service.Update(id, comment) == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("The comment is not found!!")),
                });
            }
            return Ok();

        }

        [JwtAuthentication]
        public IHttpActionResult Delete(int id)
        {
            if (!(_service.Delete(id)))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("The user is not found!!")),
                });
            }
            return Ok();
        }
    }
}

