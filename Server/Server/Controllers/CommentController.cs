using Server.DTO;
using Server.Helper.AutorizationHelper;
using Server.Models;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        [JwtAuthentication]
        public IEnumerable<CommentDTO> GetAllCommentsBySongId(int videoId)
        {
            return _service.GetAllCommentsByVideoId(videoId);
        }

        public IHttpActionResult Post(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            comment = _service.Insert(comment);
            return CreatedAtRoute("DefaultApi", new { id = comment.Id }, comment);
        }

        public IHttpActionResult Put(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_service.Update(id, comment) == null)
            {
                return BadRequest("Not found");
            }
            return Ok();

        }

        public IHttpActionResult Delete(int id)
        {
            if (!(_service.Delete(id)))
            {
                return BadRequest("Not found");
            }
            return Ok();
        }
    }
}

