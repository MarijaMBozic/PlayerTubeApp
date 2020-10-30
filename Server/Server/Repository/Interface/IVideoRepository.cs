using Server.DTO;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository.Interface
{
    public interface IVideoRepository
    {
        IEnumerable<VideoDTO> GetAllVideos();
        IEnumerable<VideoDTO> GetAllVideoByUserId(int userId);
        VideoDTO GetVideoById(int videoId);
        int Insert(Video video);
        void Update(Video video);
        void View(int numberOfViews, int videoId);
        void Like(int userId, int videoId, bool like);
        bool Delete(int id);
        bool? GetLikeInfo(int userId, int commentId);
        bool DeleteLike(int userId, int commentId);
    }
}
