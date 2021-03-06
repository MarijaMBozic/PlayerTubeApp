﻿using Server.DTO;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Interface
{
    public interface IUserService
    {
        User Insert(User user);
        bool Update(int id, UserDTO user);
        bool Delete(int id);
    }
}
