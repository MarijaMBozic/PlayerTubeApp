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
using System.Security.Claims;
using Server.DTO;
using Server.Helper;

namespace Server.Service
{
    public class VideoService : IVideoService
    {
        IVideoRepository _repository;
        IUserRepository _userRepository;
        ISubscriberService _subscriberservice;

        public VideoService(IVideoRepository repository)
        {
            _repository = repository;
        }

        public VideoDTO GetVideoById(int id)
        {
            VideoDTO video=_repository.GetVideoById(id);
            if (video != null)
            {
                video.Views += 1;
                _repository.View(video.Views, id);
            }
            return video;
        }

        public IEnumerable<VideoDTO> GetAllVideosByUserId(int userId)
        {
            try
            {
                var videos = _repository.GetAllVideoByUserId(userId);

                return videos;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }

        public IEnumerable<VideoDTO> GetAllVideos()
        {
            try
            {
                var videos = _repository.GetAllVideos();

                return videos;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }

        public Video Insert(MultipartFormDataStreamProvider video, string root)
        {
            var videoPath = string.Empty;
            try
            {
                foreach (var file in video.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName;
                    var randomNameExtension = RandomGenerateString.RandomStringName();

                    name = randomNameExtension+name.Trim('"');

                    var localVideoName = file.LocalFileName;
                    videoPath = Path.Combine(root, name);
                    File.Move(localVideoName, videoPath);
                }

                var identity = HttpContext.Current.User.Identity as ClaimsIdentity;

                Video newVideo = new Video
                {
                    Name = HttpContext.Current.Request.Form["Name"],
                    Description = HttpContext.Current.Request.Form["Description"],
                    UserId = int.Parse(identity.Name),
                    Path = videoPath,
                };

                _repository.Insert(newVideo);

                var loginUser = _userRepository.GetUserById(newVideo.UserId);

                foreach (var user in _subscriberservice.GetAllSubscribersByUser(newVideo.UserId))
                {
                    _subscriberservice.SendEmail(user.SubscriberEmail, loginUser.Username , newVideo.Name);
                }

                return newVideo;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }

        public bool Delete(int id)
        {
            var video = _repository.GetVideoById(id);

            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            if (identity == null)
            {
                return false;
            }

            if (video == null)
            {
                return false;
            }
            try
            {
                if (identity.Name == video.UserId.ToString())
                {
                    if(_repository.Delete(video.Id))
                    {
                        DeleteVideoFromFile(video.Path);
                        return true;
                    }                   
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return false;
            }
        }

        public void DeleteVideoFromFile(string path)
        {
            var filePath = path;     

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
               
        public bool Like(int videoId, bool like)
        {        
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            if (identity == null)
            {
                return false;
            }

            var userId = int.Parse(identity.Name);

            //var video = _repository.GetVideoById(videoId);
            //if(video.UserId== userId)
            //{
            //    return false;
            //}

            bool? likeData = _repository.GetLikeInfo(userId, videoId);

            if (like == likeData)
            {
                _repository.DeleteLike(userId, videoId);
                return true;
            }

            try
            {
                _repository.Like(userId, videoId, like);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return false;
            }
        }

        public bool Update(int id, Video video)
        {
            if (id != video.Id)
            {
                return false;
            }

            try
            {
                _repository.Update(video);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return false;
            }
        }

        public bool View(int videoId, int numberOfViews)
        {
            VideoDTO video = _repository.GetVideoById(videoId);
            if (video==null)
            {
                return false;
            }

            try
            {
                _repository.View(video.Id, numberOfViews);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return false;
            }
        }

        public IEnumerable<VideoDTO> GetAllVideosBySearch(string videoName)
        {
            try
            {
                var videos = _repository.GetAllVideoBySearch(videoName);

                return videos;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }
    }
}