namespace MSME.Core.Abstractions;

public interface ILogger
{
  public void Error(string messageTemplate, params object[]  p);

  public void Close();
}
