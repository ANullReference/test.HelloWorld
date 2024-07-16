using System.Collections.Concurrent;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using MSME.Core.Abstractions;
using MSME.Core.Domain;


namespace MSME.Infrastructure;

public class PokemonDataAccess : IPokemonDataAccess
{

  private HttpClient _httpClient;
  private AppSettings _appSettings;
  private ILogger _logger;
  private IJsonHandler _jsonHandler;

  private ICacheManager _cacheManager;

  private const string CACHE_KEY = "pokemon_cache";

  public PokemonDataAccess(HttpClient httpClient, IOptions<AppSettings> options, ILogger logger, IJsonHandler jsonHandler, ICacheManager cacheManager)
  {
    _httpClient = httpClient;
    _appSettings = options.Value;
    _logger = logger;
    _jsonHandler = jsonHandler;
    _cacheManager = cacheManager;
  }

  //fic interface ref
  public async Task<PokemonApiDto> FetchAllPokemon()
  {
    if (_cacheManager.DoesItemExists(CACHE_KEY))
    {
      return _cacheManager.Get<PokemonApiDto>(CACHE_KEY);
    };

    try
    {
      HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync( _appSettings.Settings.PokemonUrl );
      httpResponseMessage.EnsureSuccessStatusCode();

       Stream stream =  await httpResponseMessage.Content.ReadAsStreamAsync();

       StreamReader streamReader = new StreamReader(stream);
       string response = await streamReader.ReadToEndAsync();

        var pokemonApiDto =_jsonHandler.Deserialize<PokemonApiDto>(response);

        _cacheManager.Add(CACHE_KEY, pokemonApiDto);

        return pokemonApiDto;
    }
    catch(Exception exception)
    {
      _logger.Error(exception.Message);
    }

    return null;
  }

  /// <summary>
  ///
  /// </summary>
  /// <param name="results"></param>
  /// <returns></returns>
  public async Task<IEnumerable<PokemonDetail>> FetchPokemonDetail(Result[] results)
  {
    //iterate through and fetch pokemon details....Lets use some tasks....
    if (results == null || results.Length == 0)
    {
      return null;
    }

    List<Task> tasks = new List<Task>();

    var concurrentBag = new ConcurrentBag<List<PokemonDetail>>();

    foreach(var r in results)
    {
      Task t = Task.Run(async () =>
        {
          HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync( r.Url );
          httpResponseMessage.EnsureSuccessStatusCode();

          Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync();

          StreamReader streamReader = new StreamReader(stream);
          string response = await streamReader.ReadToEndAsync();

          var pokemonDetailApiDto =_jsonHandler.Deserialize<PokemonDetailApiDto>(response);

          var pokemonDetail = pokemonDetailApiDto?.ToPokemonDetail();


          if (pokemonDetail != null)
          {
            var list = new List<PokemonDetail>() { pokemonDetail} ;
            concurrentBag.Add( list );
          }

        }, new CancellationToken()
      );

      tasks.Add(t);
    }

    if (tasks != null)
    {
      Task.WaitAll(tasks.ToArray());
    }

    return concurrentBag.SelectMany(s => s).ToList();
  }
}
