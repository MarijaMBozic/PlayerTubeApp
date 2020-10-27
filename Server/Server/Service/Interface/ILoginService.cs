using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Interface
{
    public interface ILoginService
    {
        string Login(string email, string password);
        bool CheckUser(string email, string password);
    }
}
