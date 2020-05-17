using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JumpStartMVC.Model.Interface
{
    public interface IUserManager
    {
        public Task<User> GetUserByName(string Name);

        public Task<HttpResponseMessage> CreateActivity(User user);

        public Task<HttpResponseMessage> UpdateActivity(User user);
    }
}
