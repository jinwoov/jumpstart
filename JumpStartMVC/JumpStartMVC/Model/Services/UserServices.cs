using JumpStartMVC.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JumpStartMVC.Model.Services
{
    public class UserServices : IUserManager
    {
        private static readonly HttpClient client = new HttpClient();
        public string baseURL = @"https://jumpstartapi.azurewebsites.net/api/";

        public Task<HttpResponseMessage> CreateActivity(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateActivity(User user)
        {
            throw new NotImplementedException();
        }
    }
}
