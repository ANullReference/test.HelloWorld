using MSME.Core.Domain;

namespace MSME.Core.Abstractions;

public interface IPokemonDataAccess
{
  public Task<PokemonApiDto> FetchAllPokemon();

  public Task<IEnumerable<PokemonDetail>> FetchPokemonDetail(Result[] results);
}
