﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Sample.Service.Security
{
    public interface IIdentityModel
    {
        bool IsAuthenticated { get; set; }
        string Login { get; set; }
        string AuthenticationType { get; set; }
        // List<string> Roles { get; }
    }
}
