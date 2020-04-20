using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jumpstartAPI.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public string Skills { get; set; }
        public Tag Tags { get; set; }

        public List<UserJobs> userJobs = new List<UserJobs>();


    }
    public enum Tag
    {
        Favortite = 0,
        Pending = 1,
        Completed = 2
    }
}
