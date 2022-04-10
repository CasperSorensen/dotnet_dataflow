// See https://aka.ms/new-console-template for more information
using dotnet_dataflow.Utils;

Console.WriteLine("DataFlow program running...");
Console.WriteLine("");

Pipeline pl = new();
await pl.ProcessAsync();