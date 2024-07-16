
using MSME.Core.Abstractions;
using System.Runtime.Caching;

namespace MSME.Infrastructure;

public class CacheManager : ICacheManager
{

  private MemoryCache _cache;
  private CacheItemPolicy _cacheItemPolicy;

  public CacheManager()
  {
    _cacheItemPolicy = new CacheItemPolicy( );
    _cacheItemPolicy.SlidingExpiration = new TimeSpan(1,0,0);

    _cache = new MemoryCache("myMemCache");
  }



  public void Add<T>(string name, T itemToCache)
  {
    if (DoesItemExists(name) || itemToCache == null )
    {
      return;
    }

    _cache.Add(name, itemToCache, _cacheItemPolicy);
  }

  public bool DoesItemExists(string name)
  {
    return _cache.Contains(name);
  }

  public T? Get<T>(string name)
  {
    if (!DoesItemExists(name))
    {
      return default(T);
    }

    return (T) _cache.Get(name);
  }
}
