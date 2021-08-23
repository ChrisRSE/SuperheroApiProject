using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace SuperheroAPITests.HTTP
{
    public class CallManager
    {
        private readonly IRestClient _client;
        public int Status { get; set; }
        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }
        public async Task<string> MakeIdRequestAsync(int Id)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"{Id}";
            var response = await _client.ExecuteAsync(request);
            Status = (int)response.StatusCode;
            return response.Content;
        }

        public async Task<string> MakeNameRequestAsync(string name)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"search/{name.ToLower().Trim()}";
            var response = await _client.ExecuteAsync(request);
            Status = (int)response.StatusCode;
            return response.Content;
        }

        public async Task<string> MakePowerstatRequestAsync(int id)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"{id}/powerstats";
            var response = await _client.ExecuteAsync(request);
            Status = (int)response.StatusCode;
            return response.Content;
        }
    }
}
