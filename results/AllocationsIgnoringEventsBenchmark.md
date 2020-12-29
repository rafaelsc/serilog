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
|               Method |    Job |       Runtime |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |-------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|             LogEmpty | core31 | .NET Core 3.1 |  1.536 ns | 0.1019 ns | 0.1526 ns |  1.539 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher | core31 | .NET Core 3.1 |  1.591 ns | 0.0613 ns | 0.0917 ns |  1.585 ns |  1.04 |    0.08 |      - |     - |     - |         - |
|               LogMsg | core31 | .NET Core 3.1 |  2.063 ns | 0.0294 ns | 0.0440 ns |  2.075 ns |  1.36 |    0.13 |      - |     - |     - |         - |
|         LogMsgWithEx | core31 | .NET Core 3.1 |  2.260 ns | 0.0490 ns | 0.0734 ns |  2.251 ns |  1.48 |    0.14 |      - |     - |     - |         - |
|           LogScalar1 | core31 | .NET Core 3.1 |  6.438 ns | 0.1386 ns | 0.2075 ns |  6.428 ns |  4.23 |    0.42 |      - |     - |     - |         - |
|           LogScalar2 | core31 | .NET Core 3.1 | 11.788 ns | 0.3021 ns | 0.4522 ns | 11.623 ns |  7.77 |    1.04 |      - |     - |     - |         - |
|           LogScalar3 | core31 | .NET Core 3.1 | 12.330 ns | 0.2041 ns | 0.2992 ns | 12.353 ns |  8.09 |    0.96 |      - |     - |     - |         - |
|        LogScalarMany | core31 | .NET Core 3.1 | 16.856 ns | 0.3385 ns | 0.5067 ns | 16.913 ns | 11.10 |    1.34 | 0.0089 |     - |     - |      56 B |
|     LogScalarStruct1 | core31 | .NET Core 3.1 |  6.840 ns | 0.5595 ns | 0.8374 ns |  6.201 ns |  4.54 |    0.97 |      - |     - |     - |         - |
|     LogScalarStruct2 | core31 | .NET Core 3.1 |  5.598 ns | 0.0939 ns | 0.1406 ns |  5.591 ns |  3.68 |    0.35 |      - |     - |     - |         - |
|     LogScalarStruct3 | core31 | .NET Core 3.1 |  5.973 ns | 0.1126 ns | 0.1685 ns |  5.984 ns |  3.93 |    0.41 |      - |     - |     - |         - |
|  LogScalarStructMany | core31 | .NET Core 3.1 | 25.799 ns | 0.2193 ns | 0.3283 ns | 25.817 ns | 16.96 |    1.73 | 0.0242 |     - |     - |     152 B |
|   LogScalarBigStruct | core31 | .NET Core 3.1 | 20.088 ns | 0.2339 ns | 0.3501 ns | 20.130 ns | 13.20 |    1.23 |      - |     - |     - |         - |
|        LogDictionary | core31 | .NET Core 3.1 |  7.632 ns | 0.0873 ns | 0.1306 ns |  7.636 ns |  5.02 |    0.54 | 0.0051 |     - |     - |      32 B |
|          LogSequence | core31 | .NET Core 3.1 |  7.606 ns | 0.0574 ns | 0.0859 ns |  7.597 ns |  5.00 |    0.51 | 0.0051 |     - |     - |      32 B |
|         LogAnonymous | core31 | .NET Core 3.1 |  7.632 ns | 0.1437 ns | 0.2151 ns |  7.625 ns |  5.02 |    0.54 | 0.0051 |     - |     - |      32 B |
|              LogMix2 | core31 | .NET Core 3.1 | 11.086 ns | 0.1198 ns | 0.1794 ns | 11.161 ns |  7.29 |    0.74 |      - |     - |     - |         - |
|              LogMix3 | core31 | .NET Core 3.1 | 12.100 ns | 0.3658 ns | 0.5475 ns | 11.934 ns |  7.93 |    0.54 |      - |     - |     - |         - |
|              LogMix4 | core31 | .NET Core 3.1 | 24.618 ns | 0.2429 ns | 0.3636 ns | 24.662 ns | 16.19 |    1.67 | 0.0217 |     - |     - |     136 B |
|              LogMix5 | core31 | .NET Core 3.1 | 29.590 ns | 0.5902 ns | 0.8834 ns | 29.569 ns | 19.46 |    2.05 | 0.0268 |     - |     - |     168 B |
|           LogMixMany | core31 | .NET Core 3.1 | 55.901 ns | 0.8472 ns | 1.2681 ns | 55.676 ns | 36.80 |    4.20 | 0.0446 |     - |     - |     280 B |
|                      |        |               |           |           |           |           |       |         |        |       |       |           |
|             LogEmpty |  net48 |      .NET 4.8 |  1.687 ns | 0.0318 ns | 0.0476 ns |  1.691 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher |  net48 |      .NET 4.8 |  1.704 ns | 0.0370 ns | 0.0554 ns |  1.709 ns |  1.01 |    0.04 |      - |     - |     - |         - |
|               LogMsg |  net48 |      .NET 4.8 |  1.996 ns | 0.0256 ns | 0.0375 ns |  1.997 ns |  1.18 |    0.03 |      - |     - |     - |         - |
|         LogMsgWithEx |  net48 |      .NET 4.8 |  2.315 ns | 0.0668 ns | 0.1000 ns |  2.298 ns |  1.37 |    0.08 |      - |     - |     - |         - |
|           LogScalar1 |  net48 |      .NET 4.8 |  7.885 ns | 0.1584 ns | 0.2371 ns |  7.926 ns |  4.68 |    0.21 |      - |     - |     - |         - |
|           LogScalar2 |  net48 |      .NET 4.8 | 13.973 ns | 0.0999 ns | 0.1400 ns | 13.971 ns |  8.29 |    0.28 |      - |     - |     - |         - |
|           LogScalar3 |  net48 |      .NET 4.8 | 14.508 ns | 0.4312 ns | 0.6453 ns | 14.569 ns |  8.61 |    0.46 |      - |     - |     - |         - |
|        LogScalarMany |  net48 |      .NET 4.8 | 15.537 ns | 0.2650 ns | 0.3967 ns | 15.440 ns |  9.22 |    0.38 | 0.0089 |     - |     - |      56 B |
|     LogScalarStruct1 |  net48 |      .NET 4.8 |  7.761 ns | 0.1367 ns | 0.2046 ns |  7.757 ns |  4.60 |    0.18 |      - |     - |     - |         - |
|     LogScalarStruct2 |  net48 |      .NET 4.8 |  7.253 ns | 0.1103 ns | 0.1617 ns |  7.232 ns |  4.30 |    0.16 |      - |     - |     - |         - |
|     LogScalarStruct3 |  net48 |      .NET 4.8 |  7.513 ns | 0.1876 ns | 0.2807 ns |  7.483 ns |  4.46 |    0.22 |      - |     - |     - |         - |
|  LogScalarStructMany |  net48 |      .NET 4.8 | 22.334 ns | 0.3007 ns | 0.4500 ns | 22.398 ns | 13.25 |    0.56 | 0.0242 |     - |     - |     152 B |
|   LogScalarBigStruct |  net48 |      .NET 4.8 | 22.188 ns | 0.2854 ns | 0.4272 ns | 22.291 ns | 13.17 |    0.50 |      - |     - |     - |         - |
|        LogDictionary |  net48 |      .NET 4.8 |  7.664 ns | 0.1417 ns | 0.2121 ns |  7.677 ns |  4.55 |    0.19 | 0.0051 |     - |     - |      32 B |
|          LogSequence |  net48 |      .NET 4.8 |  7.774 ns | 0.0801 ns | 0.1199 ns |  7.778 ns |  4.61 |    0.15 | 0.0051 |     - |     - |      32 B |
|         LogAnonymous |  net48 |      .NET 4.8 |  7.752 ns | 0.1164 ns | 0.1742 ns |  7.774 ns |  4.60 |    0.18 | 0.0051 |     - |     - |      32 B |
|              LogMix2 |  net48 |      .NET 4.8 | 13.860 ns | 0.1851 ns | 0.2771 ns | 13.813 ns |  8.22 |    0.27 |      - |     - |     - |         - |
|              LogMix3 |  net48 |      .NET 4.8 | 13.664 ns | 0.1761 ns | 0.2637 ns | 13.615 ns |  8.11 |    0.29 |      - |     - |     - |         - |
|              LogMix4 |  net48 |      .NET 4.8 | 22.861 ns | 0.2993 ns | 0.4480 ns | 22.998 ns | 13.57 |    0.57 | 0.0217 |     - |     - |     136 B |
|              LogMix5 |  net48 |      .NET 4.8 | 27.727 ns | 0.2188 ns | 0.3138 ns | 27.855 ns | 16.45 |    0.55 | 0.0268 |     - |     - |     168 B |
|           LogMixMany |  net48 |      .NET 4.8 | 52.005 ns | 0.4149 ns | 0.6211 ns | 52.030 ns | 30.85 |    0.94 | 0.0446 |     - |     - |     281 B |
|                      |        |               |           |           |           |           |       |         |        |       |       |           |
|             LogEmpty |  net50 | .NET Core 5.0 |  1.653 ns | 0.0321 ns | 0.0480 ns |  1.658 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher |  net50 | .NET Core 5.0 |  1.633 ns | 0.0332 ns | 0.0497 ns |  1.639 ns |  0.99 |    0.03 |      - |     - |     - |         - |
|               LogMsg |  net50 | .NET Core 5.0 |  1.949 ns | 0.0293 ns | 0.0438 ns |  1.961 ns |  1.18 |    0.04 |      - |     - |     - |         - |
|         LogMsgWithEx |  net50 | .NET Core 5.0 |  2.412 ns | 0.0709 ns | 0.1061 ns |  2.382 ns |  1.46 |    0.08 |      - |     - |     - |         - |
|           LogScalar1 |  net50 | .NET Core 5.0 |  7.108 ns | 0.1379 ns | 0.2064 ns |  7.050 ns |  4.30 |    0.18 |      - |     - |     - |         - |
|           LogScalar2 |  net50 | .NET Core 5.0 |  7.605 ns | 0.1918 ns | 0.2811 ns |  7.588 ns |  4.61 |    0.23 |      - |     - |     - |         - |
|           LogScalar3 |  net50 | .NET Core 5.0 |  8.256 ns | 0.1745 ns | 0.2611 ns |  8.246 ns |  5.00 |    0.21 |      - |     - |     - |         - |
|        LogScalarMany |  net50 | .NET Core 5.0 | 11.048 ns | 0.2109 ns | 0.3157 ns | 11.039 ns |  6.69 |    0.27 | 0.0089 |     - |     - |      56 B |
|     LogScalarStruct1 |  net50 | .NET Core 5.0 |  5.501 ns | 0.0771 ns | 0.1154 ns |  5.496 ns |  3.33 |    0.12 |      - |     - |     - |         - |
|     LogScalarStruct2 |  net50 | .NET Core 5.0 |  5.879 ns | 0.2577 ns | 0.3858 ns |  5.946 ns |  3.56 |    0.24 |      - |     - |     - |         - |
|     LogScalarStruct3 |  net50 | .NET Core 5.0 |  6.019 ns | 0.1504 ns | 0.2252 ns |  5.944 ns |  3.65 |    0.17 |      - |     - |     - |         - |
|  LogScalarStructMany |  net50 | .NET Core 5.0 | 19.484 ns | 0.2761 ns | 0.4132 ns | 19.476 ns | 11.80 |    0.45 | 0.0242 |     - |     - |     152 B |
|   LogScalarBigStruct |  net50 | .NET Core 5.0 |  8.227 ns | 0.1954 ns | 0.2925 ns |  8.258 ns |  4.98 |    0.23 |      - |     - |     - |         - |
|        LogDictionary |  net50 | .NET Core 5.0 |  5.878 ns | 0.0644 ns | 0.0963 ns |  5.886 ns |  3.56 |    0.11 | 0.0051 |     - |     - |      32 B |
|          LogSequence |  net50 | .NET Core 5.0 |  6.029 ns | 0.0763 ns | 0.1143 ns |  6.027 ns |  3.65 |    0.13 | 0.0051 |     - |     - |      32 B |
|         LogAnonymous |  net50 | .NET Core 5.0 |  6.052 ns | 0.0898 ns | 0.1345 ns |  6.067 ns |  3.67 |    0.13 | 0.0051 |     - |     - |      32 B |
|              LogMix2 |  net50 | .NET Core 5.0 |  6.667 ns | 0.1450 ns | 0.2170 ns |  6.638 ns |  4.04 |    0.17 |      - |     - |     - |         - |
|              LogMix3 |  net50 | .NET Core 5.0 |  7.900 ns | 0.2135 ns | 0.3195 ns |  7.908 ns |  4.78 |    0.24 |      - |     - |     - |         - |
|              LogMix4 |  net50 | .NET Core 5.0 | 17.114 ns | 0.2537 ns | 0.3798 ns | 16.973 ns | 10.36 |    0.38 | 0.0217 |     - |     - |     136 B |
|              LogMix5 |  net50 | .NET Core 5.0 | 22.242 ns | 0.2763 ns | 0.4135 ns | 22.264 ns | 13.47 |    0.50 | 0.0268 |     - |     - |     168 B |
|           LogMixMany |  net50 | .NET Core 5.0 | 44.145 ns | 0.4768 ns | 0.7137 ns | 44.135 ns | 26.74 |    1.10 | 0.0446 |     - |     - |     280 B |
