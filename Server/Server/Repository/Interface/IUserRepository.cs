﻿using Server.DTO;
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
        User GetUserById(int id);
        bool CheckUsername(string username);
        bool CheckEmail(string userEmail);
        int Insert(User user);
        void Update(int id, string password);
        void Delete(User user);
    }
}
