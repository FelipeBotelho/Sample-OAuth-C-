using Authentication_Sample.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Sample.Service.Interfaces
{
    public interface IUserService
    {
        User Get(string login, string password);
    }
}
