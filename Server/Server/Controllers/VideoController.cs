﻿using Server.Helper.AutorizationHelper;
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

        [JwtAuthentication]
        public async Task<IHttpActionResult> Post()
        {
            var ctx = HttpContext.Current;
            var root = AppDomain.CurrentDomain.BaseDirectory + @"Upload\Videos";
            var provider = new MultipartFormDataStreamProvider(root);
            string videoPath = string.Empty;

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName;

                    name = name.Trim('"');

                    var localVideoName = file.LocalFileName;
                    videoPath = Path.Combine(root, name);
                    File.Move(localVideoName, videoPath);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }

            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
           

            Video video = new Video
            {
                Name = HttpContext.Current.Request.Form["Name"],                
                Description = HttpContext.Current.Request.Form["Description"],
                UserId = int.Parse(identity.Name),
                Path = videoPath,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Insert(video);
            return CreatedAtRoute("DefaultApi", new { id = video.Id }, video);
        }
    }    
}
