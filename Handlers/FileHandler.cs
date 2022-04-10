namespace dotnet_dataflow.Handlers;

public class FileHandler
{
  public async Task<string> doSomeAction(string data)
  {
    Console.WriteLine("Filehandler: processing line. " + data);
    var newdata = await TransformData(data);
    return newdata;
  }

  private async Task<string> TransformData(string data)
  {
    Thread.Sleep(1000);
    return data = data + " FileHandler ->";
  }
}
