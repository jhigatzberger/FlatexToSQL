using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenFigi
{
    public class OpenFIGIArrayResponse
    {
        [JsonProperty("data")]
        public List<OpenFigiStockData> Data { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
