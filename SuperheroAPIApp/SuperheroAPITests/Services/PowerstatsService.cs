using Newtonsoft.Json.Linq;
using SuperheroAPITests.DataHandling;
using SuperheroAPITests.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroAPITests.Services
{
    public class PowerstatsService
    {
        #region Properties
        public CallManager CallManager { get; set; }
        public JObject Json_response { get; set; }
        public DTO<Powerstats> PowerstatDTO { get; set; }
        public string PowerstatSelected { get; set; }
        public string PowerstatResponse { get; set; }
        #endregion

        public PowerstatsService()
        {
            CallManager = new CallManager();
            PowerstatDTO = new DTO<Powerstats>();
        }

        public async Task MakeRequestAsync(int id)
        {
            PowerstatResponse = await CallManager.MakePowerstatRequestAsync(id);
            Json_response = JObject.Parse(PowerstatResponse);
            PowerstatDTO.DeserializeResponse(PowerstatResponse);
        }
    }
}
