``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.401
  [Host]   : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  ShortRun : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                     Method |        Mean |        Error |       StdDev |  Ratio | RatioSD |      Gen 0 | Gen 1 | Gen 2 |  Allocated |
|--------------------------- |------------:|-------------:|-------------:|-------:|--------:|-----------:|------:|------:|-----------:|
| SimulateAAppWithoutSerilog |    163.9 us |    183.88 us |    10.079 us |   1.00 |    0.00 |    12.4512 |     - |     - |   39.16 KB |
| SimulateAAppWithSerilogOff |  1,771.0 us |     45.39 us |     2.488 us |  10.84 |    0.65 |   878.9063 |     - |     - | 2702.01 KB |
|  SimulateAAppWithSerilogOn | 68,021.3 us | 43,834.06 us | 2,402.693 us | 416.08 |   27.48 | 15500.0000 |     - |     - |   47684 KB |
