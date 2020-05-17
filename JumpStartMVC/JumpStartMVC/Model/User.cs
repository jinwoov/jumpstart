using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JumpStartMVC.Model
{
    public class User
    {
        [JsonPropertyName("iD")]
        public int ID { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("jobs")]
        public List<Job> Jobs { get; set; }
    }
}
