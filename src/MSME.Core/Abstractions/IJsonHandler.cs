namespace MSME.Core.Abstractions;

public interface IJsonHandler
{
  public string Serialize<T>(T param);
  public T? Deserialize<T>(string s);
}
