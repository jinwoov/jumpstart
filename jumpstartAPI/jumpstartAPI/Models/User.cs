using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jumpstartAPI.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }

        public List<UserJobs> userJobs = new List<UserJobs>();
    }
}
