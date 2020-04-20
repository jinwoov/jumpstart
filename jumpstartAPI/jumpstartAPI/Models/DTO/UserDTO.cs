using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jumpstartAPI.Models.DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }

        public List<JobDTO> JobList = new List<JobDTO>();
    }
}
