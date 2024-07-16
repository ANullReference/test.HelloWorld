using MSME.Core.Domain;

namespace MSME.Core.Abstractions;

public interface IServiceManager
{
    public Task<IEnumerable<PokemonDetail>> FetchAllMyPokemon(int maxPokemonCount);
}
