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
    public class LoginController : ApiController
    {
        ILoginService _service { get; set; }

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [Route("api/Token")]
        public IHttpActionResult Post(User user)
        {
            var token = _service.Login(user.Email, user.Password);
            if (token != string.Empty)
            {
                return Ok(token);
            }
            return BadRequest();
        }
    }
}
