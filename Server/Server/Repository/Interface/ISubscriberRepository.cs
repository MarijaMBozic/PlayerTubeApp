using Server.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository.Interface
{
    public interface ISubscriberRepository
    {
        IEnumerable<SubscriberDTO> GetAllSubscribersEmailByUser(int userId);
        int Insert(SubscriberDTO subscriber);
        bool Delete(int id);
        bool CheckSubscription(SubscriberDTO subscriber);
    }
}
