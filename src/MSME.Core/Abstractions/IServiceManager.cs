using MSME.Core.Domain;

namespace MSME.Core.Abstractions;

public interface IServiceManager
{
    public Task<List<Friends>> GetFriends();

    public Task<bool> InsertFriend(Friends friend);

    public Task<IEnumerable<PokemonDetail>> FetchAllMyPokemon(int maxPokemonCount);
}
