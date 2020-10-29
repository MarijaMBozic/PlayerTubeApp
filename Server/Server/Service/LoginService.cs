using Server.DTO;
using Server.Helper.AutorizationHelper;
using Server.Helper.Exeptions.UserExeption;
using Server.Models;
using Server.Repository.Interface;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Server.Service
{
    public class LoginService : ILoginService
    {
        ILoginRepository _repository { get; set; }

        public LoginService(ILoginRepository repository)
        {
            _repository = repository;
        }

        public LoginDataDTO Login(string email, string password)
        {
            LoginDataDTO loginUser = new LoginDataDTO();
            try
            {
                loginUser = _repository.Login(email, password);
                if (loginUser != null)
                {
                    loginUser.Token = TokenMenager.GenerateToken(loginUser.Id, loginUser.Username);
                }               
                return loginUser;                  
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }
    }
}