``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.101
  [Host] : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  core31 : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  net48  : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  net50  : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT

Jit=RyuJit  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|           Method |    Job |       Runtime |     Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |------- |-------------- |---------:|---------:|---------:|-------:|------:|------:|----------:|
|    ForContextInt | core31 | .NET Core 3.1 | 83.48 ns | 1.096 ns | 1.640 ns | 0.0242 |     - |     - |     152 B |
| ForContextString | core31 | .NET Core 3.1 | 52.89 ns | 0.494 ns | 0.739 ns | 0.0204 |     - |     - |     128 B |
|   ForContextType | core31 | .NET Core 3.1 | 85.63 ns | 1.105 ns | 1.653 ns | 0.0204 |     - |     - |     128 B |
|    ForContextInt |  net48 |      .NET 4.8 | 83.58 ns | 1.171 ns | 1.753 ns | 0.0242 |     - |     - |     152 B |
| ForContextString |  net48 |      .NET 4.8 | 52.99 ns | 0.394 ns | 0.590 ns | 0.0204 |     - |     - |     128 B |
|   ForContextType |  net48 |      .NET 4.8 | 97.32 ns | 1.056 ns | 1.581 ns | 0.0204 |     - |     - |     128 B |
|    ForContextInt |  net50 | .NET Core 5.0 | 60.50 ns | 0.910 ns | 1.362 ns | 0.0242 |     - |     - |     152 B |
| ForContextString |  net50 | .NET Core 5.0 | 39.03 ns | 0.553 ns | 0.811 ns | 0.0204 |     - |     - |     128 B |
|   ForContextType |  net50 | .NET Core 5.0 | 74.89 ns | 1.939 ns | 2.903 ns | 0.0204 |     - |     - |     128 B |
