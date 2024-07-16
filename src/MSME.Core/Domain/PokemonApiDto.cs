namespace MSME.Core.Domain;

public class PokemonApiDto
{
  public int Count {get; set;}

  /// <summary>
  ///
  /// </summary> <summary>
  ///
  /// </summary>
  /// <value></value>
  public IEnumerable<Result> Results {get; set;}
}

public class Result
{

  /// <summary>
  /// </summary> <summary>
  ///
  /// </summary>
  /// <value></value>
  public string Name { get; set;}
  /// <summary>
  ///
  /// </summary>
  /// <value></value>
  public string Url { get; set;}

}
