using Newtonsoft.Json;

namespace OpenFigi
{
    public class OpenFIGIRequest
    {
        private OpenFIGIRequest()
        {
            
        }

        public OpenFIGIRequest(string idType, string idValue)
            : this()
        {
            IdType = idType;
            IdValue = idValue;
        }

        public OpenFIGIRequest WithExchangeCode(string exchCode)
        {
            ExchangeCode = exchCode;
            return this;
        }

        public OpenFIGIRequest WithMicCode(string micCode)
        {
            MicCode = micCode;
            return this;
        }

        public OpenFIGIRequest WithCurrency(string currency)
        {
            Currency = currency;
            return this;
        }

        public OpenFIGIRequest WithMarketSectorDescription(string marketSectorDescription)
        {
            MarketSectorDescription = marketSectorDescription;
            return this;
        }

        [JsonProperty("idType")]
        public string IdType { get; set; }
        [JsonProperty("idValue")]
        public string IdValue { get; set; }
        [JsonProperty("exchCode")]
        public string ExchangeCode { get; set; }
        [JsonProperty("micCode")]
        public string MicCode { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("marketSecDes")]
        public string MarketSectorDescription { get; set; }
    }
}
