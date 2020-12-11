using Server.DTO;
using Server.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Interface
{
    public interface ISubscriberService
    {
        IEnumerable<SubscriberDTO> GetAllSubscribersByUser(int userId);
        void Insert(SubscriberDTO subscriber);
        bool Delete(int id);
        void SendEmail(string email, string userName, string videoName);
    }
}
