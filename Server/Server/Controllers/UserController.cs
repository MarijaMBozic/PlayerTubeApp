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
    public class UserController : ApiController
    {
        IUserService _service { get; set; }

        public UserController(IUserService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public IHttpActionResult Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user = _service.Insert(user);
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        [JwtAuthentication]
        public IHttpActionResult Put(int id, UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_service.Update(id, user))
            {
                return Ok();
            }            
            return BadRequest("Not found");
        }

        [JwtAuthentication]
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
