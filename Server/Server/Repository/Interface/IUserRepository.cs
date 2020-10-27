using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository.Interface
{
    public interface IUserRepository
    {
        User GetUserByUsernameAndPassword(string username, string password);
        bool CheckUsername(string username);
        bool CheckEmail(string userEmail);
        int Insert(User user);
        void Update(User user);
        void Delete(User user);
    }
}
