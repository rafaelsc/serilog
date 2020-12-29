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
|              Method |    Job |       Runtime |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |------- |-------------- |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|           NoMessage | core31 | .NET Core 3.1 |     4.816 ns |  0.2440 ns |  0.3577 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|        NoProperties | core31 | .NET Core 3.1 |     5.454 ns |  0.6364 ns |  0.9525 ns |   1.14 |    0.27 |      - |     - |     - |         - |
| OneSimpleProperties | core31 | .NET Core 3.1 |    48.715 ns |  0.6485 ns |  0.9505 ns |  10.18 |    0.87 |      - |     - |     - |         - |
|    VariedProperties | core31 | .NET Core 3.1 |   283.529 ns |  4.7854 ns |  7.1626 ns |  59.15 |    4.97 | 0.0153 |     - |     - |      96 B |
|   ComplexProperties | core31 | .NET Core 3.1 | 1,221.707 ns | 16.6901 ns | 24.9809 ns | 255.21 |   18.49 | 0.1259 |     - |     - |     800 B |
|                     |        |               |              |            |            |        |         |        |       |       |           |
|           NoMessage |  net48 |      .NET 4.8 |     6.217 ns |  0.0610 ns |  0.0913 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|        NoProperties |  net48 |      .NET 4.8 |     6.255 ns |  0.0679 ns |  0.0974 ns |   1.01 |    0.02 |      - |     - |     - |         - |
| OneSimpleProperties |  net48 |      .NET 4.8 |    77.153 ns |  0.8686 ns |  1.3001 ns |  12.41 |    0.27 | 0.0050 |     - |     - |      32 B |
|    VariedProperties |  net48 |      .NET 4.8 |   345.516 ns |  3.9659 ns |  5.9360 ns |  55.58 |    1.13 | 0.0153 |     - |     - |      96 B |
|   ComplexProperties |  net48 |      .NET 4.8 | 1,743.173 ns | 14.9892 ns | 22.4352 ns | 280.44 |    5.67 | 0.1698 |     - |     - |    1075 B |
|                     |        |               |              |            |            |        |         |        |       |       |           |
|           NoMessage |  net50 | .NET Core 5.0 |     4.854 ns |  0.0584 ns |  0.0875 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|        NoProperties |  net50 | .NET Core 5.0 |     4.631 ns |  0.0554 ns |  0.0829 ns |   0.95 |    0.03 |      - |     - |     - |         - |
| OneSimpleProperties |  net50 | .NET Core 5.0 |    36.417 ns |  0.5323 ns |  0.7967 ns |   7.50 |    0.19 |      - |     - |     - |         - |
|    VariedProperties |  net50 | .NET Core 5.0 |   236.473 ns |  4.3641 ns |  6.5320 ns |  48.73 |    1.63 | 0.0153 |     - |     - |      96 B |
|   ComplexProperties |  net50 | .NET Core 5.0 | 1,064.540 ns | 17.4585 ns | 26.1311 ns | 219.37 |    6.45 | 0.1259 |     - |     - |     800 B |
