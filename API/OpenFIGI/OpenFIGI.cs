using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using RestSharp;
using System.Diagnostics;

namespace OpenFigi
{
    // https://github.com/OpenFIGI/api-examples/tree/master/csharp
    public static class OpenFIGI
    {
        public static OpenFigiStockData GetStockData(List<OpenFIGIRequest> requests)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            RestClient client = new("https://api.openfigi.com/v1/mapping");
            RestRequest request = new(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "text/json");
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new NewtonsoftJsonSerializer();
            request.AddJsonBody(requests);

            IRestResponse<List<OpenFIGIArrayResponse>> response = client.Post<List<OpenFIGIArrayResponse>>(request);
            if (response.Data != null && response.Data.Any())
            {
                foreach (OpenFIGIArrayResponse dataInstrument in response.Data)
                {
                    if (dataInstrument.Data != null && dataInstrument.Data.Any())
                    {
                        Debug.WriteLine(dataInstrument.Data[0].Figi);
                        return dataInstrument.Data[0];
                    }
                }
            }
            return null;
        }
    }
}
