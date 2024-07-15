using MSME.Core.Abstractions;
using Newtonsoft.Json;

namespace MSME.Infrastructure;

public class JsonHandler : IJsonHandler
{
  public T? Deserialize<T>(string s) => JsonConvert.DeserializeObject<T>(s);

  public string Serialize<T>(T param) => JsonConvert.SerializeObject(param);

}
