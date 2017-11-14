using Authentication_Sample.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication_Sample.Service.Entities;

namespace Authentication_Sample.Service.Services
{
    public class UserService : IUserService
    {
        public User Get(string login, string password)
        {
            if (login.Equals("lucas@test.com") && password.Equals("123456"))
            {
                var user = new User
                {
                    Id = 1,
                    Email = "lucas@test.com",
                    Name = "Lucas",
                    Password = "123456"
                };
                return user;
            }
            return null;
        }
    }
}
