using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace OpenFigi
{
    public interface IJsonSerializer : ISerializer, IDeserializer
    {
    }
}
