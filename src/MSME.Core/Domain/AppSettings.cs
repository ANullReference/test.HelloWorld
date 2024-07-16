using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSME.Core.Domain;

namespace MSME.Core.Domain;

public class ConnectionStrings
{
  public virtual string ArchilleTest {get; set;}
}

public class Settings
{
  public virtual int MaxPokemonCount { get; set;}
  public virtual string PokemonUrl { get; set;}
  public virtual string[] AcceptedSortByRequest {get; set;}
}

  public class AppSettings
  {
    public virtual ConnectionStrings ConnectionStrings {get; set;}
    public virtual Settings Settings {get; set;}
  }
