using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperheroAPITests.HTTP;
using SuperheroAPITests.DataHandling;
using Newtonsoft.Json.Linq;


namespace SuperheroAPITests.Services
{
    

    public class NameService : IResponse
    {
        #region Properties
        public CallManager CallManager { get; set; }
        public JObject Json_Response { get; set; }
        public DTO<Name> NameDTO { get; set; }
        public string NameSelected { get; set; }
        public string NameResponse { get; set; }

        #endregion
        public NameService()
        {
            CallManager = new CallManager();
            NameDTO = new DTO<Name>();
        }

        public async Task MakeRequestAsync(string name)
        {
            NameSelected = name;
            NameResponse = await CallManager.MakeNameRequestAsync(NameSelected);
            Json_Response = JObject.Parse(NameResponse);
            NameDTO.DeserializeResponse(NameResponse);
        }


    }
}
