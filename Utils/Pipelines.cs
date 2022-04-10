using System.Threading.Tasks.Dataflow;
using dotnet_dataflow.Handlers;

namespace dotnet_dataflow.Utils;

public class Pipeline
{
  public Pipeline()
  {

  }

  /// <summary>
  /// Pipeline example
  /// </summary>
  /// <returns></returns>
  public async void ProcessAsync()
  {

    // how many things can be processed at once
    var options = new ExecutionDataflowBlockOptions
    {
      MaxDegreeOfParallelism = 2
    };

    Console.WriteLine("Processing data...");
    var processor = new Processor();
    var fileHandler = new FileHandler();
    var ftpHandler = new FtpHandler();

    var ProcessorBlock = new TransformBlock<string, string>(processor.doSomeAction, options);
    var FileHandlerBlock = new TransformBlock<string, string>(fileHandler.doSomeAction, options);
    var ftpHandlerBlock = new ActionBlock<string>(ftpHandler.doSomeAction, options);

    DataflowLinkOptions linkOptions = new() { PropagateCompletion = true };

    ProcessorBlock.LinkTo(FileHandlerBlock, linkOptions);
    FileHandlerBlock.LinkTo(ftpHandlerBlock, linkOptions);

    List<string> data = new()
    {
      "Rugbrød",
      "leverpostej",
      "sildemad",
      "Øl",
      "frokost"
    };

    foreach (var entry in data)
    {
      ProcessorBlock.Post(entry);
    }

    ProcessorBlock.Complete();

    await ftpHandlerBlock.Completion;
  }

}