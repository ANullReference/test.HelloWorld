
using MSME.Core.Abstractions;

namespace MSME.Infrastructure;

public class Logger : ILogger
{
  public void Close()
  {
    //close logger close and flush if needed
  }

  public void Error(string messageTemplate, params object[] p)
  {
    Console.WriteLine(messageTemplate, p );
  }
}
