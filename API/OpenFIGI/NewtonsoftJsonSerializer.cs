using Newtonsoft.Json;

namespace OpenFigi
{
    public class NewtonsoftJsonSerializer : IJsonSerializer
    {
        private JsonSerializerSettings settings;


        public NewtonsoftJsonSerializer()
        {
            settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }


        public string ContentType
        {
            get { return "application/json"; }
            set { }
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }


        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }

        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content, settings);
        }
    }
}
