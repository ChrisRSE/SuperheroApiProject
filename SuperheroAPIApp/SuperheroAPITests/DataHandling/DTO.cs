using Newtonsoft.Json;

namespace SuperheroAPITests.DataHandling
{
    public class DTO<ResponseType> where ResponseType : IResponse, new()
    {
        public ResponseType Response { get; set; }

        internal void DeserializeResponse(string idResponse)
        {
            Response = JsonConvert.DeserializeObject<ResponseType>(idResponse);
        }
    }
}
