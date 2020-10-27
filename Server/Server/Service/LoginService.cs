using Server.Helper.AutorizationHelper;
using Server.Repository.Interface;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Service
{
    public class LoginService : ILoginService
    {
        ILoginRepository _repository { get; set; }

        public LoginService(ILoginRepository repository)
        {
            _repository = repository;
        }

        public bool CheckUser(string email, string password)
        {
            if (_repository.Login(email, password) != null)
            {
                return true;
            }

            return false;
        }

        public string Login(string email, string password)
        {
            string token = string.Empty;
            if (CheckUser(email, password))
            {
                var user = _repository.Login(email, password);
                token = TokenMenager.GenerateToken(user.Id, user.Username);
            }
            return token;
        }
    }
}