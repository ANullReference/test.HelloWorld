using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MSME.Core.Abstractions;
using MSME.Core.Domain;
using MSME.Infrastructure;

namespace MSME.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{

private IServiceManager _serviceManager;
private AppSettings _appSettings;

  public PokemonController (IServiceManager serviceManager, IOptions<AppSettings> options)
  {
    _serviceManager = serviceManager;
    _appSettings = options.Value;
  }


  [HttpGet]
  [Route("tournaments/statistics")] // name from requirements
  public async Task<IActionResult> GetPokemonStatistics(string sortBy, string sortDirection = "desc")
  {
    if (string.IsNullOrEmpty(sortBy))
    {
      return BadRequest("sortBy parameter is required");
    }

    if (!_appSettings.Settings.AcceptedSortByRequest.Contains(sortBy))
    {
      return BadRequest($"sortBy parameter is invalid");
    }

    if (!sortDirection.Equals("asc") && !sortDirection.Equals("desc"))
    {
      return BadRequest($"sortDirection parameter is invalid");
    }

    IEnumerable<PokemonDetail> pokemonDetail;

    try
    {
      pokemonDetail =  await _serviceManager.FetchAllMyPokemon(_appSettings.Settings.MaxPokemonCount);
    }
    catch(Exception exception)
    {
      return Problem(exception.Message);
    }

    if (IsPokemonResultsCountEmpty(pokemonDetail))
    {
        return NotFound();
    }

    return Ok(pokemonDetail.Sort(sortBy,sortDirection));
  }

  private bool IsPokemonResultsCountEmpty(IEnumerable<PokemonDetail> pokemonDetail)
  {
    return pokemonDetail == null || !pokemonDetail.Any();
  }
}

