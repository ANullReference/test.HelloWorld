using System.Reflection.Metadata.Ecma335;
using MSME.Core.Abstractions;
using MSME.Core.Domain;

namespace MSME.Infrastructure;

public class PokemonRuleEngine : IPokemonRuleEngine
{
  //   1. water beats fire;
// 2. fire beats grass;
// 3. grass beats electric;
// 4. electric beats water;

// 5. ghost beats psychic;
// 6. psychic beats fighting;
// 7. fighting beats dark;
// 8. dark beats ghost;

  public async Task<bool> Fight(PokemonDetail left, PokemonDetail right)
  {
    if (left.Type.Equals("water") &&  right.Type.Equals("fire"))
    {
      left.Win++;
      right.Losses++;
    }
    else if (left.Type.Equals("fire") &&  right.Type.Equals("grass"))
    {
      left.Win++;
      right.Losses++;
    }
    else if (left.Type.Equals("grass") &&  right.Type.Equals("electric"))
    {
      left.Win++;
      right.Losses++;
    }
    else if (left.Type.Equals("electric") &&  right.Type.Equals("water"))
    {
      left.Win++;
      right.Losses++;
    }
    else if (left.Type.Equals("ghost") &&  right.Type.Equals("psychic"))
    {
      left.Win++;
      right.Losses++;
    }
    else if (left.Type.Equals("psychic") &&  right.Type.Equals("fighting"))
    {
      left.Win++;
      right.Losses++;
    }
    else if (left.Type.Equals("fighting") &&  right.Type.Equals("dark"))
    {
      left.Win++;
      right.Losses++;
    }
    else if (left.Type.Equals("dark") &&  right.Type.Equals("ghost"))
    {
      left.Win++;
      right.Losses++;
    }
    else if (left.Base_Experience > right.Base_Experience)
    {
      left.Win++;
      right.Losses++;
    }
    else if (left.Base_Experience < right.Base_Experience)
    {
      left.Losses++;
      right.Win++;
    }
    else
    {
      left.Ties++;
      right.Ties++;
    }

    return await Task.FromResult(true);
  }
}
