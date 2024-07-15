using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MSME.Core.Abstractions;
using MSME.Core.Domain;
using MSME.Infrastructure.Data;

namespace MSME.Infrastructure;
public class DataAccess : IDataAccess
{

  private AppSettings _appSettings;
  private MSMEDataContextContext _dbCtx;

  public DataAccess(IOptions<AppSettings> options, MSMEDataContextContext dbContext )
  {
    _appSettings = options.Value;
    _dbCtx = dbContext;
  }



  /// <summary>
  ///
  ///
  /// Fetch all friends.
  /// </summary>
  /// <returns></returns> <summary>
  ///
  /// </summary>
  /// <returns></returns>
  public async Task<List<Friends>> GetFriends()
  {
    return await _dbCtx.Friends.AsNoTracking().ToListAsync();
  }

  /// <summary>
  /// Insert friend into db
  /// </summary>
  /// <param name="friend"></param>
  /// <returns></returns>
  public async Task<bool> InsertFriend(Friends friend)
  {
    _ = await _dbCtx.Friends.AddAsync(friend);

    int i = await _dbCtx.SaveChangesAsync();

    return i > 0;
  }
}
