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
        [Route("api/Registration")]
        public IHttpActionResult Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Registration data is not in valid format!");
            }

            user = _service.Insert(user);
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        [JwtAuthentication]
        public IHttpActionResult Put(int id, UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Password is not in valid format!");
            }

            if (_service.Update(id, user))
            {
                return Ok();
            }            
            return Content(HttpStatusCode.BadRequest, "The user is not found!");
        }

        [JwtAuthentication]
        public IHttpActionResult Delete(int id)
        {
            if (!(_service.Delete(id)))
            {
                return Content(HttpStatusCode.BadRequest, "The user is not found!");
            }
            return Ok();
        }
    }
}
