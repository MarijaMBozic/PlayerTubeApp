using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Interface
{
    public interface IVideoService
    {
        Video Insert(Video video);
    }
}
