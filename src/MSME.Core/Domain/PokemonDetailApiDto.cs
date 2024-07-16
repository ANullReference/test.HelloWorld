using System.Diagnostics.Contracts;

namespace MSME.Core.Domain;

  public class PokemonDetailApiDto
  {
      public int Id {get; set;}

      public string Name {get; set;}

      public int Base_Experience {get; set;}
      public List<MyType> Types { get; set; }
  }

  public class MyType
  {
      public int Slot { get; set; }
      public Type2 Type { get; set; }
  }

  public class Type2
  {
      public string Name { get; set; }
      public string Url { get; set; }
  }
