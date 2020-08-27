``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.450 (2004/?/20H1)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.401
  [Host]          : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  core31 RyuJit   : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  net48 LegacyJit : .NET Framework 4.8 (4.8.4200.0), X64 RyuJIT
  net48 RyuJit    : .NET Framework 4.8 (4.8.4200.0), X64 RyuJIT

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
|   Method |             Job |       Jit |       Runtime |      Mean |      Error |     StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------- |---------------- |---------- |-------------- |----------:|-----------:|-----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
| BindZero |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  57.52 ns |   3.287 ns |   4.819 ns |  57.03 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|  BindOne |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 207.53 ns |   7.515 ns |  11.247 ns | 206.32 ns |  3.63 |    0.29 | 0.0229 |     - |     - |     144 B |
| BindFive |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 674.25 ns | 102.378 ns | 143.520 ns | 575.25 ns | 11.92 |    3.40 | 0.0687 |     - |     - |     432 B |
|          |                 |           |               |           |            |            |           |       |         |        |       |       |           |
| BindZero | net48 LegacyJit | LegacyJit |      .NET 4.8 |  85.94 ns |  13.043 ns |  19.118 ns |  82.81 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|  BindOne | net48 LegacyJit | LegacyJit |      .NET 4.8 | 226.81 ns |  26.433 ns |  39.564 ns | 206.32 ns |  2.72 |    0.52 | 0.0253 |     - |     - |     160 B |
| BindFive | net48 LegacyJit | LegacyJit |      .NET 4.8 | 811.30 ns |  83.573 ns | 125.088 ns | 812.03 ns |  9.88 |    2.81 | 0.0706 |     - |     - |     449 B |
|          |                 |           |               |           |            |            |           |       |         |        |       |       |           |
| BindZero |    net48 RyuJit |    RyuJit |      .NET 4.8 |  83.58 ns |  14.826 ns |  22.190 ns |  74.01 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|  BindOne |    net48 RyuJit |    RyuJit |      .NET 4.8 | 310.96 ns |  88.830 ns | 132.956 ns | 237.54 ns |  3.95 |    1.78 | 0.0253 |     - |     - |     160 B |
| BindFive |    net48 RyuJit |    RyuJit |      .NET 4.8 | 789.32 ns |  89.095 ns | 127.777 ns | 771.85 ns |  9.84 |    2.65 | 0.0706 |     - |     - |     449 B |
