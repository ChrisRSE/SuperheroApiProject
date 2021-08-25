
using SuperheroApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
    public class ExperimentAnon
    {
        public string response { get; set; }

        [JsonPropertyName("results-for")]
        public string resultsfor { get; set; }

        public ICollection<SuperheroItem> results { get; set; }
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
}
