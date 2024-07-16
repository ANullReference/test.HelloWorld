namespace MSME.Core.Abstractions;

public interface ICacheManager
{
  public void Add<T>(string name, T itemtToCache);
  public T? Get<T>(string name);
  public bool DoesItemExists(string name);
}
