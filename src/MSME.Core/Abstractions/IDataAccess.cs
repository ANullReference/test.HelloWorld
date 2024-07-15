using MSME.Core.Domain;

namespace MSME.Core.Abstractions;

public interface IDataAccess
{
  public Task<List<Friends>> GetFriends();

  public Task<bool> InsertFriend(Friends friend);
}
