using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JumpStartMVC.Model
{
    public class Job
    {
        [JsonPropertyName("iD")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("skills")]
        public string Skills { get; set; }

        [JsonPropertyName("tags")]
        public int Tags { get; set; }

        [JsonPropertyName("userID")]
        public int UserID { get; set; }
    }
}
