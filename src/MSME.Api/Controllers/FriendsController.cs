using Microsoft.AspNetCore.Mvc;
using MSME.Core.Abstractions;
using MSME.Core.Domain;

namespace MSME.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendsController : ControllerBase
{
  private IServiceManager _serviceManager;
  private IJsonHandler _jsonHandler;

  public FriendsController(IServiceManager serviceManager, IJsonHandler jsonHandler)
  {
    _serviceManager = serviceManager;
    _jsonHandler = jsonHandler;
  }

  [HttpGet]
  [Route("GetFriends")]
  public async Task<IActionResult> GetFriends()
  {
    List<Friends> friends;

    try
    {
      friends =  await _serviceManager.GetFriends();
    }
    catch(Exception exception)
    {
      return Problem(exception.Message);
    }

    if (friends == null || friends.Count == 0)
    {
        return NotFound();
    }
    return Ok(friends);
  }

  [HttpPut]
  [Route("InsertFriend")]
  public async Task<IActionResult> InsertFriend(Friends friend)
  {
    bool b =  false;

    try
    {
      b = await _serviceManager.InsertFriend(friend);
    }
    catch( Exception exception )
    {
      return Problem(exception.Message);
    }

    if (!b)
    {
        return NotFound();
    }

    return Ok( $"Friend {friend.FirstName} was added");
  }
}
