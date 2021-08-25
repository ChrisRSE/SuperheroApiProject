using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SuperheroApi.Models
{
    
    public class SuperheroItem
    {
        public int id { get; set; }
        public string response { get; set; }
        public string name { get; set; }
        public Powerstats powerstats { get; set; }
        public Biography biography { get; set; }
        public Appearance appearance { get; set; }
        public Work work { get; set; }
        public Connections connections { get; set; }
        public Image image { get; set; }
     
    }

    public class Powerstats
    {
        public int id { get; set; }
        public string intelligence { get; set; }
        public string strength { get; set; }
        public string speed { get; set; }
        public string durability { get; set; }
        public string power { get; set; }
        public string combat { get; set; }
    }

    public class Biography
    {
        public int id { get; set; }

        [JsonPropertyName("full-name")]
        public string fullname { get; set; }

        [JsonPropertyName("alter-egos")]
        public string alteregos { get; set; }
        [NotMapped]
        public ICollection<string> aliases { get; set; }

        [JsonPropertyName("place-of-birth")]
        public string placeofbirth { get; set; }

        [JsonPropertyName("first-appearance")]
        public string firstappearance { get; set; }
        public string publisher { get; set; }
        public string alignment { get; set; }
    }
    public class Appearance
    {
        public int id { get; set; }
        public string gender { get; set; }
        public string race { get; set; }
        [NotMapped]
        public ICollection<string> height { get; set; }
        [NotMapped]
        public ICollection<string> weight { get; set; }
        [JsonPropertyName("eye-color")]
        public string eyecolor { get; set; }
        [JsonPropertyName("hair-color")]
        public string haircolor { get; set; }
    }

    public class Work
    {
        public int id { get; set; }
        public string occupation { get; set; }

        [JsonPropertyName(@"_base")]
        public string _base { get; set; }
    }

    public class Connections
    {
        public int id { get; set; }

        [JsonPropertyName("group-affiliation")]
        public string groupaffiliation { get; set; }
        public string relatives { get; set; }
    }


    public class Image
    {
        public int id { get; set; }
        public string url { get; set; }
    }
}
