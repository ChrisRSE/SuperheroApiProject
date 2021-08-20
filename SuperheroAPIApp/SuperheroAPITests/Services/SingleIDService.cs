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
    public class SingleIDService
    {
        #region Properties
        public CallManager CallManager { get; set; }
        public JObject Json_response { get; set; }
        public DTO<ID> SingleIdDTO { get; set; }
        public string IdSelected { get; set; }
        public string IdResponse { get; set; }
        #endregion
        public SingleIDService()
        {
            CallManager = new CallManager();
            SingleIdDTO = new DTO<ID>();
        }

        public async Task MakeRequestAsync(int id)
        {
            IdResponse = await CallManager.MakeIdRequestAsync(id);
            Json_response = JObject.Parse(IdResponse);
            SingleIdDTO.DeserializeResponse(IdResponse);
        }

    }
}
