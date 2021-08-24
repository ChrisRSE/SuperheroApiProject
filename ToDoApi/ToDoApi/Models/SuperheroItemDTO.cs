using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperheroApi.DTOModels
{
    public class SuperheroItemDTO
    {
        public string response { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Powerstats powerstats { get; set; }
        public Biography biography { get; set; }
        public Appearance appearance { get; set; }
        public Work work { get; set; }
        public Connections connections { get; set; }
        public Image image { get; set; }

    }

    public class Name
    {
        public string response { get; set; }

        [JsonProperty("results-for")]
        public string resultsfor { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
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
        public string intelligence { get; set; }
        public string strength { get; set; }
        public string speed { get; set; }
        public string durability { get; set; }
        public string power { get; set; }
        public string combat { get; set; }
    }

    public class Biography
    {
        [JsonProperty("full-name")]
        public string fullname { get; set; }

        [JsonProperty("alter-egos")]
        public string alteregos { get; set; }
        public string[] aliases { get; set; }

        [JsonProperty("place-of-birth")]
        public string placeofbirth { get; set; }

        [JsonProperty("first-appearance")]
        public string firstappearance { get; set; }
        public string publisher { get; set; }
        public string alignment { get; set; }
    }

    public class Appearance
    {
        public string gender { get; set; }
        public string race { get; set; }

        public string height { get; set; }
        public string weight { get; set; }
        [JsonProperty("eye-color")]
        public string eyecolor { get; set; }
        [JsonProperty("hair-color")]
        public string haircolor { get; set; }
    }

    public class Work
    {
        public string occupation { get; set; }

        [JsonProperty(@"base")]
        public string _base { get; set; }
    }

    public class Connections
    {
        [JsonProperty("group-affiliation")]
        public string groupaffiliation { get; set; }
        public string relatives { get; set; }
    }


    public class Image
    {
        public string url { get; set; }
    }
}
