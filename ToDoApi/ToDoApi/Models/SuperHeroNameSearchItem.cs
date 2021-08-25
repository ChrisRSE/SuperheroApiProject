
using SuperheroApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
    public class SuperHeroNameSearchItem
    {
        public string response { get; set; }

        [JsonPropertyName("results-for")]
        public string resultsfor { get; set; }

        public ICollection<SuperheroItem> results { get; set; }
    }

}
