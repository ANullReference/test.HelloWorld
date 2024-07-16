using MSME.Core.Domain;
using MSME.Infrastructure.Data.POCO;

namespace MSME.Infrastructure;

public static class Extensions
{
  public static PokemonDetail ToPokemonDetail(this PokemonDetailApiDto pokemonDetailApiDto )
  {
    if (pokemonDetailApiDto == null)
    {
      return null;
    }

    PokemonDetail pokemonDetail = new PokemonDetail();
    pokemonDetail.Name = pokemonDetailApiDto.Name;
    pokemonDetail.Type = pokemonDetailApiDto.Types[0].Type.Name; //per requirement....grab first
    pokemonDetail.Id = pokemonDetailApiDto.Id;
    pokemonDetail.Base_Experience = pokemonDetailApiDto.Base_Experience;

    return pokemonDetail;
  }

  public static IEnumerable<PokemonDetail>? Sort(this IEnumerable<PokemonDetail> pokemonDetails, string sortBy, string sortDirection)
  {
    if (pokemonDetails == null || !pokemonDetails.Any())
    {
      return null;
    }

    if ("name".Equals(sortBy) )
    {
      if (sortDirection.Equals("desc"))
      {
        pokemonDetails = pokemonDetails.OrderByDescending(o => o.Name).ToList();
      }
      else
      {
        pokemonDetails = pokemonDetails.OrderBy(o => o.Name).ToList();
      }
    }
    else if ("wins".Equals(sortBy) )
    {
      if (sortDirection.Equals("desc"))
      {
        pokemonDetails = pokemonDetails.OrderByDescending(o => o.Win).ToList();
      }
      else
      {
        pokemonDetails = pokemonDetails.OrderBy(o => o.Win).ToList();
      }
    }
    else if ("losses".Equals(sortBy) )
    {
      if (sortDirection.Equals("desc"))
      {
        pokemonDetails = pokemonDetails.OrderByDescending(o => o.Losses).ToList();
      }
      else
      {
        pokemonDetails = pokemonDetails.OrderBy(o => o.Losses).ToList();
      }
    }
    else if ("id".Equals(sortBy) )
    {
      if (sortDirection.Equals("desc"))
      {
        pokemonDetails = pokemonDetails.OrderByDescending(o => o.Id).ToList();
      }
      else
      {
        pokemonDetails = pokemonDetails.OrderBy(o => o.Id).ToList();
      }
    }
    else if ("ties".Equals(sortBy) )
    {
      if (sortDirection.Equals("desc"))
      {
        pokemonDetails = pokemonDetails.OrderByDescending(o => o.Ties).ToList();
      }
      else
      {
        pokemonDetails = pokemonDetails.OrderBy(o => o.Ties).ToList();
      }
    }

    return pokemonDetails;
  }
}
