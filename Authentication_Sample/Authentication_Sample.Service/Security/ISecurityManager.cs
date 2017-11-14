using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Sample.Service.Security
{
    public interface ISecurityManager<T> where T : IIdentityModel
    {
        T User { get; }
    }
}
