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
|                         Method |             Job |       Jit |       Runtime |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------------- |---------------- |---------- |-------------- |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|-------:|------:|----------:|
|                  EmptyTemplate |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   193.5 ns |  12.93 ns |  19.36 ns |   195.0 ns |  1.00 |    0.00 | 0.0408 |      - |     - |     256 B |
|             SimpleTextTemplate |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   239.2 ns |   4.62 ns |   6.77 ns |   237.7 ns |  1.25 |    0.14 | 0.0648 |      - |     - |     408 B |
|    SinglePropertyTokenTemplate |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   326.1 ns |   8.01 ns |  11.22 ns |   322.6 ns |  1.70 |    0.19 | 0.0877 |      - |     - |     552 B |
| SingleTextWithPropertyTemplate |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   870.7 ns |  93.21 ns | 139.51 ns |   845.6 ns |  4.52 |    0.71 | 0.1478 |      - |     - |     928 B |
|      ManyPropertyTokenTemplate |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   655.1 ns |  28.39 ns |  42.50 ns |   653.0 ns |  3.41 |    0.34 | 0.1650 |      - |     - |    1040 B |
|         MultipleTokensTemplate |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 1,231.7 ns |  60.05 ns |  88.02 ns | 1,212.8 ns |  6.42 |    0.82 | 0.2823 | 0.0019 |     - |    1776 B |
|   DefaultConsoleOutputTemplate |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 2,227.7 ns | 265.72 ns | 397.71 ns | 2,239.2 ns | 11.70 |    2.76 | 0.3548 |      - |     - |    2240 B |
|                    BigTemplate |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 4,674.2 ns | 204.48 ns | 299.72 ns | 4,712.8 ns | 24.32 |    2.72 | 0.9918 | 0.0229 |     - |    6264 B |
|                                |                 |           |               |            |           |           |            |       |         |        |        |       |           |
|                  EmptyTemplate | net48 LegacyJit | LegacyJit |      .NET 4.8 |   144.4 ns |   6.99 ns |  10.46 ns |   145.4 ns |  1.00 |    0.00 | 0.0420 |      - |     - |     265 B |
|             SimpleTextTemplate | net48 LegacyJit | LegacyJit |      .NET 4.8 |   224.7 ns |   3.98 ns |   5.59 ns |   224.0 ns |  1.58 |    0.11 | 0.0675 |      - |     - |     425 B |
|    SinglePropertyTokenTemplate | net48 LegacyJit | LegacyJit |      .NET 4.8 |   469.2 ns |  39.84 ns |  59.63 ns |   459.0 ns |  3.29 |    0.63 | 0.0896 |      - |     - |     570 B |
| SingleTextWithPropertyTemplate | net48 LegacyJit | LegacyJit |      .NET 4.8 |   617.6 ns |  32.25 ns |  48.27 ns |   608.4 ns |  4.30 |    0.42 | 0.1497 |      - |     - |     947 B |
|      ManyPropertyTokenTemplate | net48 LegacyJit | LegacyJit |      .NET 4.8 |   709.2 ns |  14.47 ns |  20.75 ns |   704.7 ns |  4.97 |    0.35 | 0.1707 |      - |     - |    1075 B |
|         MultipleTokensTemplate | net48 LegacyJit | LegacyJit |      .NET 4.8 | 1,851.3 ns | 236.86 ns | 347.19 ns | 1,651.1 ns | 12.81 |    1.80 | 0.2918 | 0.0019 |     - |    1845 B |
|   DefaultConsoleOutputTemplate | net48 LegacyJit | LegacyJit |      .NET 4.8 | 2,518.2 ns | 249.89 ns | 366.28 ns | 2,427.4 ns | 17.51 |    2.21 | 0.3624 |      - |     - |    2303 B |
|                    BigTemplate | net48 LegacyJit | LegacyJit |      .NET 4.8 | 5,732.1 ns | 149.51 ns | 219.15 ns | 5,753.7 ns | 40.00 |    3.07 | 1.0529 | 0.0229 |     - |    6652 B |
|                                |                 |           |               |            |           |           |            |       |         |        |        |       |           |
|                  EmptyTemplate |    net48 RyuJit |    RyuJit |      .NET 4.8 |   140.1 ns |   4.49 ns |   6.72 ns |   139.7 ns |  1.00 |    0.00 | 0.0420 |      - |     - |     265 B |
|             SimpleTextTemplate |    net48 RyuJit |    RyuJit |      .NET 4.8 |   268.2 ns |  42.13 ns |  63.05 ns |   253.2 ns |  1.92 |    0.47 | 0.0675 |      - |     - |     425 B |
|    SinglePropertyTokenTemplate |    net48 RyuJit |    RyuJit |      .NET 4.8 |   406.9 ns |  19.40 ns |  29.03 ns |   411.5 ns |  2.91 |    0.25 | 0.0901 |      - |     - |     570 B |
| SingleTextWithPropertyTemplate |    net48 RyuJit |    RyuJit |      .NET 4.8 |   593.5 ns |  25.07 ns |  37.53 ns |   591.5 ns |  4.25 |    0.36 | 0.1497 |      - |     - |     947 B |
|      ManyPropertyTokenTemplate |    net48 RyuJit |    RyuJit |      .NET 4.8 |   899.0 ns | 108.22 ns | 161.98 ns |   925.1 ns |  6.46 |    1.33 | 0.1698 |      - |     - |    1075 B |
|         MultipleTokensTemplate |    net48 RyuJit |    RyuJit |      .NET 4.8 | 1,785.5 ns | 178.31 ns | 266.88 ns | 1,719.8 ns | 12.75 |    1.92 | 0.2918 | 0.0019 |     - |    1845 B |
|   DefaultConsoleOutputTemplate |    net48 RyuJit |    RyuJit |      .NET 4.8 | 2,004.3 ns |  95.53 ns | 137.01 ns | 1,929.3 ns | 14.32 |    1.17 | 0.3624 |      - |     - |    2303 B |
|                    BigTemplate |    net48 RyuJit |    RyuJit |      .NET 4.8 | 5,414.2 ns | 145.10 ns | 208.09 ns | 5,316.9 ns | 38.69 |    2.52 | 1.0529 | 0.0229 |     - |    6652 B |
