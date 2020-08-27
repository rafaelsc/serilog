``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.450 (2004/?/20H1)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.401
  [Host]        : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  core22 RyuJit : .NET Core 2.2.8 (CoreCLR 4.6.28207.03, CoreFX 4.6.28208.02), X64 RyuJIT
  core31 RyuJit : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  net48 RyuJit  : .NET Framework 4.8 (4.8.4200.0), X64 RyuJIT

Jit=RyuJit  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                             Method |           Job |       Runtime |       Mean |     Error |    StdDev |
|----------------------------------- |-------------- |-------------- |-----------:|----------:|----------:|
|          Filter_MatchingFromSource | core22 RyuJit | .NET Core 2.2 | 4,735.8 ns | 409.17 ns | 573.60 ns |
|                  Logger_ForContext | core22 RyuJit | .NET Core 2.2 |   792.2 ns |  68.92 ns | 103.16 ns |
| LevelOverrideMap_GetEffectiveLevel | core22 RyuJit | .NET Core 2.2 |   161.3 ns |   1.81 ns |   2.71 ns |
|          Filter_MatchingFromSource | core31 RyuJit | .NET Core 3.1 | 2,523.5 ns |  19.89 ns |  29.77 ns |
|                  Logger_ForContext | core31 RyuJit | .NET Core 3.1 |   739.5 ns |   8.26 ns |  12.11 ns |
| LevelOverrideMap_GetEffectiveLevel | core31 RyuJit | .NET Core 3.1 |   144.5 ns |   2.26 ns |   3.38 ns |
|          Filter_MatchingFromSource |  net48 RyuJit |      .NET 4.8 | 3,518.8 ns |  27.75 ns |  38.91 ns |
|                  Logger_ForContext |  net48 RyuJit |      .NET 4.8 |   874.5 ns |   7.30 ns |  10.69 ns |
| LevelOverrideMap_GetEffectiveLevel |  net48 RyuJit |      .NET 4.8 |   276.1 ns |   3.29 ns |   4.83 ns |
