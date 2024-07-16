using MSME.Core.Domain;

namespace MSME.Core.Abstractions;

public interface IPokemonRuleEngine
{
  public Task<bool> Fight (PokemonDetail left, PokemonDetail right);

}
