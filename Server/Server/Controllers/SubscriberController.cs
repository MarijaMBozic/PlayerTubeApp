using Server.DTO;
using Server.Helper.AutorizationHelper;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class SubscriberController : ApiController
    {
        ISubscriberService _service { get; set; }

        public SubscriberController(ISubscriberService service)
        {
            _service = service;
        }

        [JwtAuthentication]
        public IHttpActionResult Post(SubscriberDTO subscriber)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Invalid data!")),
                });
            }

             _service.Insert(subscriber);
            return Ok();
        }       
    }
}
