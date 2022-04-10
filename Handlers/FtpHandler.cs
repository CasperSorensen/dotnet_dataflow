namespace dotnet_dataflow.Handlers;

public class FtpHandler
{

  /// <summary>
  /// Saves a file to disk
  /// </summary>
  /// <returns></returns>
  public async void doSomeAction(string data)
  {
    Console.WriteLine("FtpHandler: Sending file...");
    var newdata = await TransformData(data);
    Console.WriteLine(newdata);

  }

  private async Task<string> TransformData(string data)
  {
    Thread.Sleep(1000);
    return data = data + " FtpHandler ->";
  }
}
