// See https://aka.ms/new-console-template for more information
using dotnet_dataflow.Utils;

Console.WriteLine("Hello world");

Pipeline pipeline = new();

pipeline.ProcessAsync();

Console.ReadKey();

