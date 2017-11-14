using Authentication_Sample.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Sample.Service.Interfaces
{
    public interface ISecurityService
    {
        OperationResult<IdentityContract> SignIn(string login, string password);
    }
}
