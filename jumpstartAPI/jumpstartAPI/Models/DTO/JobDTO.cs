using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jumpstartAPI.Models.DTO
{
    public class JobDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public string Skills { get; set; }
        public int Tags { get; set; }
        public int UserID { get; set; }
    }
}
