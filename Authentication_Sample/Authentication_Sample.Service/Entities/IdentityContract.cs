using Authentication_Sample.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Sample.Service.Entities
{
    public class IdentityContract : IIdentityModel
    {
        public bool IsAuthenticated { get; set; }
        public string Login { get; set; }
        public string AuthenticationType { get; set; }
        public User User { get; set; }
    }
}
