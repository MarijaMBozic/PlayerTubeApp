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
        IEnumerable<Video> GetAllVideo();
        IEnumerable<Video> GetAllVideoByUserId(int userId);
        Video GetVideoById(int songId);
        int Insert(Video song);
        void Update(Video song);
        void Delete(Video song);
    }
}
