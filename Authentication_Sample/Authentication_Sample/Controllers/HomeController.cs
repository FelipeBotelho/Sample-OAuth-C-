using Authentication_Sample.Service.Entities;
using Authentication_Sample.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Authentication_Sample.Controllers
{
    public class HomeController : ApiController
    {

        private readonly ISecurityManager<IdentityContract> _user;

        public HomeController(ISecurityManager<IdentityContract> user)
        {
            _user = user;
        }
        
        //NAO FAÇA DESSE JEITO>>> NUNCA RETORNE PASSWORD E ETC ^.^
        [Authorize]
        [HttpGet]
        public IdentityContract GetUserInfo()
        {
            try
            {
                return _user.User;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet]
        public List<Guid> GetGuids()
        {
            var list = new List<Guid>();
            for(var i=0; i<10; i++)
            {
                list.Add(Guid.NewGuid());
            }
            return list;
        }
    }
}
