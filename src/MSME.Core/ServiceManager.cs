using MSME.Core.Abstractions;
using MSME.Core.Domain;

namespace MSME.Core;


public class ServiceManager : IServiceManager
{
  private IDataAccess _dataAccess;

  public ServiceManager(IDataAccess dataAccess)
  {
    _dataAccess = dataAccess;
  }

  public async Task<List<Friends>> GetFriends()
  {
    return await _dataAccess.GetFriends();
  }

  public async Task<bool> InsertFriend(Friends friend)
  {
    return await _dataAccess.InsertFriend(friend);
  }

}
