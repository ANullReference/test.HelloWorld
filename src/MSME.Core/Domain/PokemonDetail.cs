using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace MSME.Core.Domain;

//if pokemon has multiple types...consider first one..pigetooto is fighting and fire....use fighting.


public class PokemonDetail
{
  public int Id { get; set;}

  public string Name { get; set; }

  public string Type { get; set;}

  public int Win { get; set; }

  public int Losses { get; set; }

  public int Ties { get; set; }

  [JsonIgnore]
  public int Base_Experience { get; set; }
}
