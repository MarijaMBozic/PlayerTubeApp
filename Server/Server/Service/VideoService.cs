using Server.Models;
using Server.Repository.Interface;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Net.Http.Headers;

namespace Server.Service
{
    public class VideoService : IVideoService
    {
        IVideoRepository _repository;

        public VideoService(IVideoRepository repository)
        {
            _repository = repository;
        }


        public Video Insert(Video video)
        {


            //var ctx = HttpContext.Current;
            //var root = AppDomain.CurrentDomain.BaseDirectory + @"Upload\Videos";
            //var provider = new MultipartFormDataStreamProvider(root);
            //var videoPath = string.Empty;

            //try
            //{
            //     Request.Content.ReadAsMultipartAsync(provider);

            //    foreach (var file in provider.FileData)
            //    {
            //        var name = file.Headers.ContentDisposition.FileName;

            //        name = name.Trim('"');

            //        var localImgName = file.LocalFileName;
            //        videoPath = Path.Combine(root, name);
            //        File.Move(localImgName, videoPath);
            //    }
            //}
            //catch
            //{
            //    throw;
            //}

            //Video video = new Video
            //{
            //    Name = HttpContext.Current.Request.Form["Name"],
            //    Path = videoPath,
            //    Description = HttpContext.Current.Request.Form["Description"],
            //    UserId = int.Parse(HttpContext.Current.Request.Form["UserId"]),               
            //};

            try
            {
                if ((video.Id = _repository.Insert(video)) != 0)
                {
                    return video;
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }
    }
}