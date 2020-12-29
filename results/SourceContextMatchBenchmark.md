``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.101
  [Host] : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  core22 : .NET Core 2.2.8 (CoreCLR 4.6.28207.03, CoreFX 4.6.28208.02), X64 RyuJIT
  core31 : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  net48  : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  net50  : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT

Jit=RyuJit  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                             Method |    Job |       Runtime |       Mean |    Error |    StdDev |
|----------------------------------- |------- |-------------- |-----------:|---------:|----------:|
|          Filter_MatchingFromSource | core22 | .NET Core 2.2 | 2,816.4 ns | 63.56 ns |  93.17 ns |
|                  Logger_ForContext | core22 | .NET Core 2.2 |   666.1 ns |  7.63 ns |  11.41 ns |
| LevelOverrideMap_GetEffectiveLevel | core22 | .NET Core 2.2 |   138.3 ns |  2.64 ns |   3.95 ns |
|          Filter_MatchingFromSource | core31 | .NET Core 3.1 | 2,609.9 ns | 65.72 ns |  98.36 ns |
|                  Logger_ForContext | core31 | .NET Core 3.1 |   670.8 ns |  8.51 ns |  12.74 ns |
| LevelOverrideMap_GetEffectiveLevel | core31 | .NET Core 3.1 |   129.4 ns |  2.14 ns |   3.14 ns |
|          Filter_MatchingFromSource |  net48 |      .NET 4.8 | 3,581.1 ns | 69.33 ns | 101.62 ns |
|                  Logger_ForContext |  net48 |      .NET 4.8 |   783.8 ns |  7.70 ns |  11.52 ns |
| LevelOverrideMap_GetEffectiveLevel |  net48 |      .NET 4.8 |   247.0 ns |  3.93 ns |   5.88 ns |
|          Filter_MatchingFromSource |  net50 | .NET Core 5.0 | 2,315.3 ns | 56.63 ns |  81.22 ns |
|                  Logger_ForContext |  net50 | .NET Core 5.0 |   514.2 ns |  8.91 ns |  13.34 ns |
| LevelOverrideMap_GetEffectiveLevel |  net50 | .NET Core 5.0 |   131.6 ns |  2.48 ns |   3.71 ns |
