using Server.DTO;
using Server.Helper.Exeptions;
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
            LoginDataDTO loginUser = _service.Login(user.Email, user.Password);

            if (loginUser == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Invalid email or password!")),
                    ReasonPhrase = "User Not Found"
                });
            }
            return Ok(loginUser);                              
        }
    }
}
