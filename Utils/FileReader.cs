using System.Text;

namespace dotnet_dataflow.Utils;

public class FileReader
{
  private Pipeline _pipeLine { get; set; }

  public FileReader()
  {
    this._pipeLine = new();
  }

  /// <summary>
  /// Read a line in a file
  /// </summary>
  /// <returns></returns>
  public IEnumerable<string> ProcessFile()
  {
    const Int32 BufferSize = 1024;

    using (var fileStream = File.OpenRead("./TestData/data.txt"))
    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
    {
      String line;
      while ((line = streamReader.ReadLine()) != null)
      {
        yield return line;
      }

    }
  }
}