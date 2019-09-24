``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]   : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0
  ShortRun : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                     Method |        Mean |        Error |     StdDev |  Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 |   Allocated |
|--------------------------- |------------:|-------------:|-----------:|-------:|--------:|----------:|------:|------:|------------:|
| SimulateAAppWithoutSerilog |    279.2 us |     22.16 us |   1.215 us |   1.00 |    0.00 |   41.5039 |     - |     - |   128.27 KB |
| SimulateAAppWithSerilogOff |  1,598.2 us |     43.74 us |   2.398 us |   5.72 |    0.02 |  347.6563 |     - |     - |  1071.64 KB |
|  SimulateAAppWithSerilogOn | 93,080.9 us | 17,832.58 us | 977.464 us | 333.36 |    2.36 | 9166.6667 |     - |     - | 28336.94 KB |
