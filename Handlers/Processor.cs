namespace dotnet_dataflow.Handlers;

public class Processor
{
  public async Task<string> doSomeAction(string data)
  {
    System.Console.WriteLine("Processing...");
    var newdata = await TransformData(data);
    return newdata;
  }

  private async Task<string> TransformData(string data)
  {
    Thread.Sleep(3000);
    return data = data + " Processor ->";
  }
}
