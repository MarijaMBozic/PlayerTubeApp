using Server.Models;
using Server.Repository.Interface;
using Server.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Service
{
    public class UserService:IUserService
    {
        IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Insert(User user)
        {
            try
            {
                if ((user.Id = _repository.Insert(user)) != 0)
                {
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exeption" + ex.Message.ToString());
                return null;
            }
        }
    }
}