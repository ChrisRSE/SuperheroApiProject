using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroAPITests.DataHandling
{

    public class ID : IResponse
    {
        public string response { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Powerstats powerstats { get; set; }
        public Biography biography { get; set; }
        public Appearance appearance { get; set; }
        public Work work { get; set; }
        public Connections connections { get; set; }
        public Image image { get; set; }
    }


    public class Name : IResponse
    {
        public string response { get; set; }

        [JsonProperty("results-for")]
        public string resultsfor { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string name { get; set; }
        public Powerstats powerstats { get; set; }
        public Biography biography { get; set; }
        public Appearance appearance { get; set; }
        public Work work { get; set; }
        public Connections connections { get; set; }
        public Image image { get; set; }
    }

    public class Powerstats : IResponse
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
        public string[] height { get; set; }
        public string[] weight { get; set; }
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
