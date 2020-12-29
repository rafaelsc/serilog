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
|                         Method |    Job |       Runtime |        Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------------- |------- |-------------- |------------:|----------:|----------:|-------:|--------:|-------:|-------:|------:|----------:|
|                  EmptyTemplate | core31 | .NET Core 3.1 |    21.24 ns |  0.468 ns |  0.656 ns |   1.00 |    0.00 | 0.0127 |      - |     - |      80 B |
|             SimpleTextTemplate | core31 | .NET Core 3.1 |   126.50 ns |  1.992 ns |  2.981 ns |   5.95 |    0.22 | 0.0610 |      - |     - |     384 B |
|    SinglePropertyTokenTemplate | core31 | .NET Core 3.1 |   184.30 ns |  2.186 ns |  3.272 ns |   8.69 |    0.24 | 0.0854 |      - |     - |     536 B |
| SingleTextWithPropertyTemplate | core31 | .NET Core 3.1 |   419.32 ns |  3.733 ns |  5.587 ns |  19.76 |    0.66 | 0.1440 | 0.0005 |     - |     904 B |
|      ManyPropertyTokenTemplate | core31 | .NET Core 3.1 |   354.09 ns |  4.717 ns |  6.914 ns |  16.67 |    0.66 | 0.1326 | 0.0005 |     - |     832 B |
|         MultipleTokensTemplate | core31 | .NET Core 3.1 |   725.73 ns |  8.352 ns | 12.501 ns |  34.21 |    1.35 | 0.2308 | 0.0019 |     - |    1448 B |
|   DefaultConsoleOutputTemplate | core31 | .NET Core 3.1 |   915.97 ns | 10.280 ns | 14.744 ns |  43.12 |    1.47 | 0.2575 | 0.0019 |     - |    1624 B |
|                    BigTemplate | core31 | .NET Core 3.1 | 2,531.08 ns | 37.000 ns | 55.380 ns | 119.39 |    5.18 | 0.7019 | 0.0153 |     - |    4424 B |
|                                |        |               |             |           |           |        |         |        |        |       |           |
|                  EmptyTemplate |  net48 |      .NET 4.8 |    26.28 ns |  0.492 ns |  0.736 ns |   1.00 |    0.00 | 0.0140 |      - |     - |      88 B |
|             SimpleTextTemplate |  net48 |      .NET 4.8 |   151.69 ns |  2.379 ns |  3.561 ns |   5.78 |    0.22 | 0.0648 |      - |     - |     409 B |
|    SinglePropertyTokenTemplate |  net48 |      .NET 4.8 |   237.34 ns |  4.126 ns |  6.176 ns |   9.04 |    0.37 | 0.0825 |      - |     - |     522 B |
| SingleTextWithPropertyTemplate |  net48 |      .NET 4.8 |   461.34 ns |  3.420 ns |  5.119 ns |  17.57 |    0.51 | 0.1478 | 0.0005 |     - |     931 B |
|      ManyPropertyTokenTemplate |  net48 |      .NET 4.8 |   473.70 ns |  7.593 ns | 11.364 ns |  18.04 |    0.48 | 0.1383 |      - |     - |     875 B |
|         MultipleTokensTemplate |  net48 |      .NET 4.8 |   944.97 ns | 14.571 ns | 21.809 ns |  35.98 |    1.05 | 0.2422 |      - |     - |    1524 B |
|   DefaultConsoleOutputTemplate |  net48 |      .NET 4.8 | 1,312.40 ns | 17.230 ns | 25.788 ns |  49.98 |    1.56 | 0.2670 | 0.0019 |     - |    1685 B |
|                    BigTemplate |  net48 |      .NET 4.8 | 3,639.28 ns | 28.171 ns | 41.293 ns | 138.55 |    3.97 | 0.7515 | 0.0153 |     - |    4742 B |
|                                |        |               |             |           |           |        |         |        |        |       |           |
|                  EmptyTemplate |  net50 | .NET Core 5.0 |    21.56 ns |  0.271 ns |  0.406 ns |   1.00 |    0.00 | 0.0127 |      - |     - |      80 B |
|             SimpleTextTemplate |  net50 | .NET Core 5.0 |   122.54 ns |  2.865 ns |  4.288 ns |   5.69 |    0.24 | 0.0610 |      - |     - |     384 B |
|    SinglePropertyTokenTemplate |  net50 | .NET Core 5.0 |   176.46 ns |  2.806 ns |  4.200 ns |   8.19 |    0.25 | 0.0854 |      - |     - |     536 B |
| SingleTextWithPropertyTemplate |  net50 | .NET Core 5.0 |   383.00 ns |  3.917 ns |  5.863 ns |  17.77 |    0.37 | 0.1440 | 0.0005 |     - |     904 B |
|      ManyPropertyTokenTemplate |  net50 | .NET Core 5.0 |   343.27 ns |  4.893 ns |  7.324 ns |  15.93 |    0.48 | 0.1326 | 0.0005 |     - |     832 B |
|         MultipleTokensTemplate |  net50 | .NET Core 5.0 |   690.44 ns | 15.199 ns | 21.797 ns |  32.07 |    1.27 | 0.2308 | 0.0019 |     - |    1448 B |
|   DefaultConsoleOutputTemplate |  net50 | .NET Core 5.0 |   865.13 ns |  7.898 ns | 11.821 ns |  40.14 |    0.90 | 0.2584 | 0.0019 |     - |    1624 B |
|                    BigTemplate |  net50 | .NET Core 5.0 | 2,462.47 ns | 36.710 ns | 54.946 ns | 114.28 |    3.72 | 0.7019 | 0.0153 |     - |    4424 B |
