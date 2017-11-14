using Authentication_Sample.Service.Entities;
using Authentication_Sample.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Sample.Service.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUserService _userService;

        private const string USER_DOESNT_EXIST = "Incorrect Email or Password.";

        public SecurityService(IUserService userService)
        {
            _userService = userService;
        }


        public OperationResult<IdentityContract> SignIn(string login, string password)
        {
            var result = new OperationResult<IdentityContract>();

            var user = _userService.Get(login, password);

            if (user == null)
                result.AddError(USER_DOESNT_EXIST);

            if (!result.Success) return result;

            result.Result = new IdentityContract()
            {
                User = user
            };

            return result;
        }
    }    
}
