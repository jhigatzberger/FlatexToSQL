using Newtonsoft.Json;

namespace OpenFigi
{
    public class OpenFigiStockData
    {
        [JsonProperty("figi")]
        public string Figi { get; set; }
        [JsonProperty("securityType")]
        public string SecurityType { get; set; }
        [JsonProperty("marketSector")]
        public string MarketSector { get; set; }
        [JsonProperty("ticker")]
        public string Ticker { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("uniqueID")]
        public string UniqueID { get; set; }
        [JsonProperty("exchCode")]
        public string ExchCode { get; set; }
        [JsonProperty("shareClassFIGI")]
        public string ShareClassFIGI { get; set; }
        [JsonProperty("compositeFIGI")]
        public string CompositeFIGI { get; set; }
        [JsonProperty("securityType2")]
        public string SecurityType2 { get; set; }
        [JsonProperty("securityDescription")]
        public string SecurityDescription { get; set; }
        [JsonProperty("uniqueIDFutOpt")]
        public string UniqueIDFutOpt { get; set; }

        [JsonProperty("tickerComplete")]
        public string TickerComplete
        {
            get { return MarketSector == "Equity" ? string.Format("{0} {1} {2}", Ticker, ExchCode, MarketSector) : string.Format("{0} {1}", Ticker, MarketSector); }

        }

    }
}
