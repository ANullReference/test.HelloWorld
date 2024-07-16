using MSME.Core.Abstractions;
using MSME.Core.Domain;

namespace MSME.Core;

public class ServiceManager : IServiceManager
{
    private IPokemonDataAccess _pokemonDataAccess;

  private IPokemonRuleEngine _ruleEngine;

  public ServiceManager(IPokemonDataAccess pokemonDataAccess, IPokemonRuleEngine ruleEngine)
  {
    _pokemonDataAccess = pokemonDataAccess;
    _ruleEngine = ruleEngine;
  }


  public async Task<IEnumerable<PokemonDetail>> FetchAllMyPokemon(int maxPokemonCount = 8)//number should come from config ultimately.
  {
    //fetch all pokemons
    PokemonApiDto pokemonApiDto = await _pokemonDataAccess.FetchAllPokemon();

    //radomize list and fetch  top count (8)
    var results =  pokemonApiDto
      .Results.OrderBy( o => Guid.NewGuid() ) // randomize pokemon order
              .Select(s => new Result() { Name = s.Name, Url = s.Url } )
              .Take(maxPokemonCount)
              .ToArray();

    var pokemonDetails = await _pokemonDataAccess.FetchPokemonDetail(results);
    var pokemonDetailsArray = pokemonDetails.ToArray();

    List<IndexAlreadyAdded> alreadyAdded = new List<IndexAlreadyAdded>();

    //loop through all and fight each other...
    for(int i = 0; i < pokemonDetailsArray.Count(); i++)
    {
      for(int j = 0; j < pokemonDetailsArray.Count(); j++)
      {
        if (i == j)
        {
          //cant fight yourself though...
          continue;
        }

        if (alreadyAdded.Any(w => (w.Index1 == i && w.Index2 == j) || (w.Index1 == j && w.Index2 == i)))
        {
          //already added somewhere
          continue;
        }

        _ = _ruleEngine.Fight( pokemonDetailsArray[i], pokemonDetailsArray[j] );

        alreadyAdded.Add(new IndexAlreadyAdded(i,j));
        alreadyAdded.Add(new IndexAlreadyAdded(j,i));
      }
    }

    return pokemonDetailsArray;
  }

  private class IndexAlreadyAdded
  {
    public IndexAlreadyAdded(int first, int second)
    {
      Index1 = first;
      Index2 = second;
    }

    public int Index1 {get; set;}
    public int Index2 {get; set;}
  }
}
