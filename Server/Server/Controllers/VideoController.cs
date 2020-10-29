using Server.DTO;
using Server.Helper.AutorizationHelper;
using Server.Models;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Server.Controllers
{
    public class VideoController : ApiController
    {
        IVideoService _service { get; set; }

        public VideoController(IVideoService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public IEnumerable<VideoDTO> GetAllVideos()
        {
            return _service.GetAllVideos();
        }

        [AllowAnonymous]
        public IEnumerable<VideoDTO> GetAllVideosByUserId(int userId)
        {
            return _service.GetAllVideosByUserId(userId);
        }

        [JwtAuthentication]
        public async Task<IHttpActionResult> Post()
        {
            var root = AppDomain.CurrentDomain.BaseDirectory + @"Upload\Videos";
            var provider = new MultipartFormDataStreamProvider(root);

            await Request.Content.ReadAsMultipartAsync(provider);
            Video video =_service.Insert(provider, root);

            if (video==null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Invalid video data")),
                });
            }

           return CreatedAtRoute("DefaultApi", new { id = video.Id }, video);
        }

        [JwtAuthentication]
        public IHttpActionResult Delete(int id)
        {
            if (!(_service.Delete(id)))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("The video is not found!!")),
                });
            }
            return Ok();
        }

        [JwtAuthentication]
        [Route("api/Like")]
        public IHttpActionResult LikeVideo(int videoId, bool like)
        {
            if (!(_service.Like(videoId, like)))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("The video is not found!!")),
                });
            }
            return Ok();
        }
    }
}
