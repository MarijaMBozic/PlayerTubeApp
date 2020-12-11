using Server.DTO;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Interface
{
    public interface IVideoService
    {
        IEnumerable<VideoDTO> GetAllVideos();
        VideoDTO GetVideoById(int videoId);
        IEnumerable<VideoDTO> GetAllVideosByUserId(int userId);
        IEnumerable<VideoDTO> GetAllVideosBySearch(string videoName);
        Video Insert(MultipartFormDataStreamProvider video, string root);
        bool Update(int id, Video video);
        bool View(int numberOfViews, int videoId);
        bool Delete(int id);
        void DeleteVideoFromFile(string path);
        bool Like(int videoId, bool like);
    }
}
