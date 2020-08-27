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
|               Method |             Job |       Jit |       Runtime |      Mean |      Error |     StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |---------------- |---------- |-------------- |----------:|-----------:|-----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|             LogEmpty |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  2.316 ns |  0.0244 ns |  0.0365 ns |  2.309 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  2.812 ns |  0.0439 ns |  0.0630 ns |  2.847 ns |  1.21 |    0.03 |      - |     - |     - |         - |
|               LogMsg |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  4.303 ns |  0.1728 ns |  0.2479 ns |  4.372 ns |  1.86 |    0.12 |      - |     - |     - |         - |
|         LogMsgWithEx |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  4.179 ns |  0.1159 ns |  0.1625 ns |  4.233 ns |  1.80 |    0.08 |      - |     - |     - |         - |
|           LogScalar1 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  6.542 ns |  0.1608 ns |  0.2306 ns |  6.489 ns |  2.82 |    0.11 |      - |     - |     - |         - |
|           LogScalar2 |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 11.843 ns |  0.0631 ns |  0.0924 ns | 11.821 ns |  5.11 |    0.08 |      - |     - |     - |         - |
|           LogScalar3 |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 15.386 ns |  0.1501 ns |  0.2152 ns | 15.362 ns |  6.64 |    0.15 |      - |     - |     - |         - |
|        LogScalarMany |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 22.150 ns |  0.2611 ns |  0.3907 ns | 22.123 ns |  9.57 |    0.24 | 0.0089 |     - |     - |      56 B |
|     LogScalarStruct1 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  5.396 ns |  0.0277 ns |  0.0406 ns |  5.396 ns |  2.33 |    0.04 |      - |     - |     - |         - |
|     LogScalarStruct2 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  5.756 ns |  0.0383 ns |  0.0549 ns |  5.761 ns |  2.48 |    0.05 |      - |     - |     - |         - |
|     LogScalarStruct3 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  8.905 ns |  0.0849 ns |  0.1190 ns |  8.898 ns |  3.85 |    0.08 |      - |     - |     - |         - |
|  LogScalarStructMany |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 34.145 ns |  2.3311 ns |  3.4891 ns | 33.021 ns | 14.74 |    1.46 | 0.0242 |     - |     - |     152 B |
|   LogScalarBigStruct |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 21.443 ns |  0.1354 ns |  0.1897 ns | 21.419 ns |  9.26 |    0.18 |      - |     - |     - |         - |
|        LogDictionary |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10.992 ns |  0.3029 ns |  0.4439 ns | 11.043 ns |  4.75 |    0.21 | 0.0051 |     - |     - |      32 B |
|          LogSequence |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10.971 ns |  0.2572 ns |  0.3688 ns | 10.914 ns |  4.73 |    0.18 | 0.0051 |     - |     - |      32 B |
|         LogAnonymous |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10.573 ns |  0.1997 ns |  0.2864 ns | 10.611 ns |  4.56 |    0.15 | 0.0051 |     - |     - |      32 B |
|              LogMix2 |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 12.227 ns |  0.2140 ns |  0.3000 ns | 12.271 ns |  5.28 |    0.17 |      - |     - |     - |         - |
|              LogMix3 |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 15.456 ns |  0.3029 ns |  0.4534 ns | 15.432 ns |  6.68 |    0.23 |      - |     - |     - |         - |
|              LogMix4 |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 30.072 ns |  0.3752 ns |  0.5616 ns | 30.064 ns | 12.99 |    0.33 | 0.0216 |     - |     - |     136 B |
|              LogMix5 |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 36.035 ns |  0.3576 ns |  0.5352 ns | 35.923 ns | 15.56 |    0.32 | 0.0268 |     - |     - |     168 B |
|           LogMixMany |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 64.984 ns |  0.7479 ns |  1.0726 ns | 65.052 ns | 28.04 |    0.64 | 0.0446 |     - |     - |     280 B |
|                      |                 |           |               |           |            |            |           |       |         |        |       |       |           |
|             LogEmpty | net48 LegacyJit | LegacyJit |      .NET 4.8 |  2.846 ns |  0.0318 ns |  0.0475 ns |  2.849 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher | net48 LegacyJit | LegacyJit |      .NET 4.8 |  2.862 ns |  0.0421 ns |  0.0603 ns |  2.864 ns |  1.01 |    0.02 |      - |     - |     - |         - |
|               LogMsg | net48 LegacyJit | LegacyJit |      .NET 4.8 |  4.600 ns |  0.0493 ns |  0.0692 ns |  4.593 ns |  1.62 |    0.04 |      - |     - |     - |         - |
|         LogMsgWithEx | net48 LegacyJit | LegacyJit |      .NET 4.8 |  3.932 ns |  0.0631 ns |  0.0925 ns |  3.929 ns |  1.38 |    0.04 |      - |     - |     - |         - |
|           LogScalar1 | net48 LegacyJit | LegacyJit |      .NET 4.8 |  9.329 ns |  0.0638 ns |  0.0955 ns |  9.341 ns |  3.28 |    0.07 |      - |     - |     - |         - |
|           LogScalar2 | net48 LegacyJit | LegacyJit |      .NET 4.8 | 14.053 ns |  0.3988 ns |  0.5969 ns | 14.058 ns |  4.94 |    0.21 |      - |     - |     - |         - |
|           LogScalar3 | net48 LegacyJit | LegacyJit |      .NET 4.8 | 18.757 ns |  0.3023 ns |  0.4238 ns | 18.817 ns |  6.59 |    0.15 |      - |     - |     - |         - |
|        LogScalarMany | net48 LegacyJit | LegacyJit |      .NET 4.8 | 20.311 ns |  0.3764 ns |  0.5633 ns | 20.267 ns |  7.14 |    0.23 | 0.0089 |     - |     - |      56 B |
|     LogScalarStruct1 | net48 LegacyJit | LegacyJit |      .NET 4.8 |  7.000 ns |  0.0722 ns |  0.1058 ns |  7.003 ns |  2.46 |    0.05 |      - |     - |     - |         - |
|     LogScalarStruct2 | net48 LegacyJit | LegacyJit |      .NET 4.8 |  7.774 ns |  0.0624 ns |  0.0915 ns |  7.760 ns |  2.73 |    0.05 |      - |     - |     - |         - |
|     LogScalarStruct3 | net48 LegacyJit | LegacyJit |      .NET 4.8 | 11.392 ns |  0.2002 ns |  0.2872 ns | 11.349 ns |  4.00 |    0.11 |      - |     - |     - |         - |
|  LogScalarStructMany | net48 LegacyJit | LegacyJit |      .NET 4.8 | 31.770 ns |  1.1102 ns |  1.6617 ns | 31.356 ns | 11.17 |    0.63 | 0.0242 |     - |     - |     152 B |
|   LogScalarBigStruct | net48 LegacyJit | LegacyJit |      .NET 4.8 | 23.857 ns |  0.2008 ns |  0.2749 ns | 23.902 ns |  8.38 |    0.13 |      - |     - |     - |         - |
|        LogDictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10.820 ns |  0.5417 ns |  0.7770 ns | 10.541 ns |  3.80 |    0.27 | 0.0051 |     - |     - |      32 B |
|          LogSequence | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10.436 ns |  0.0894 ns |  0.1338 ns | 10.421 ns |  3.67 |    0.07 | 0.0051 |     - |     - |      32 B |
|         LogAnonymous | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10.369 ns |  0.1112 ns |  0.1664 ns | 10.343 ns |  3.64 |    0.08 | 0.0051 |     - |     - |      32 B |
|              LogMix2 | net48 LegacyJit | LegacyJit |      .NET 4.8 | 14.089 ns |  0.2268 ns |  0.3395 ns | 14.095 ns |  4.95 |    0.14 |      - |     - |     - |         - |
|              LogMix3 | net48 LegacyJit | LegacyJit |      .NET 4.8 | 19.073 ns |  0.6998 ns |  1.0474 ns | 19.264 ns |  6.70 |    0.35 |      - |     - |     - |         - |
|              LogMix4 | net48 LegacyJit | LegacyJit |      .NET 4.8 | 29.655 ns |  0.6842 ns |  1.0240 ns | 29.510 ns | 10.42 |    0.42 | 0.0216 |     - |     - |     136 B |
|              LogMix5 | net48 LegacyJit | LegacyJit |      .NET 4.8 | 36.288 ns |  0.9229 ns |  1.3235 ns | 35.694 ns | 12.75 |    0.58 | 0.0268 |     - |     - |     168 B |
|           LogMixMany | net48 LegacyJit | LegacyJit |      .NET 4.8 | 67.375 ns |  1.9826 ns |  2.8434 ns | 67.286 ns | 23.66 |    1.03 | 0.0446 |     - |     - |     281 B |
|                      |                 |           |               |           |            |            |           |       |         |        |       |       |           |
|             LogEmpty |    net48 RyuJit |    RyuJit |      .NET 4.8 |  2.850 ns |  0.0410 ns |  0.0589 ns |  2.847 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher |    net48 RyuJit |    RyuJit |      .NET 4.8 |  2.853 ns |  0.0361 ns |  0.0540 ns |  2.851 ns |  1.00 |    0.03 |      - |     - |     - |         - |
|               LogMsg |    net48 RyuJit |    RyuJit |      .NET 4.8 |  4.644 ns |  0.0505 ns |  0.0691 ns |  4.648 ns |  1.63 |    0.04 |      - |     - |     - |         - |
|         LogMsgWithEx |    net48 RyuJit |    RyuJit |      .NET 4.8 |  3.951 ns |  0.0524 ns |  0.0734 ns |  3.961 ns |  1.39 |    0.04 |      - |     - |     - |         - |
|           LogScalar1 |    net48 RyuJit |    RyuJit |      .NET 4.8 |  9.408 ns |  0.0608 ns |  0.0910 ns |  9.425 ns |  3.30 |    0.08 |      - |     - |     - |         - |
|           LogScalar2 |    net48 RyuJit |    RyuJit |      .NET 4.8 | 13.857 ns |  0.3229 ns |  0.4833 ns | 13.756 ns |  4.88 |    0.17 |      - |     - |     - |         - |
|           LogScalar3 |    net48 RyuJit |    RyuJit |      .NET 4.8 | 18.352 ns |  0.6063 ns |  0.8887 ns | 17.979 ns |  6.45 |    0.28 |      - |     - |     - |         - |
|        LogScalarMany |    net48 RyuJit |    RyuJit |      .NET 4.8 | 20.422 ns |  0.5738 ns |  0.8411 ns | 20.259 ns |  7.16 |    0.37 | 0.0089 |     - |     - |      56 B |
|     LogScalarStruct1 |    net48 RyuJit |    RyuJit |      .NET 4.8 |  7.472 ns |  0.2219 ns |  0.3183 ns |  7.550 ns |  2.62 |    0.14 |      - |     - |     - |         - |
|     LogScalarStruct2 |    net48 RyuJit |    RyuJit |      .NET 4.8 |  8.318 ns |  0.3916 ns |  0.5617 ns |  8.100 ns |  2.92 |    0.21 |      - |     - |     - |         - |
|     LogScalarStruct3 |    net48 RyuJit |    RyuJit |      .NET 4.8 | 11.288 ns |  0.1418 ns |  0.1941 ns | 11.266 ns |  3.97 |    0.11 |      - |     - |     - |         - |
|  LogScalarStructMany |    net48 RyuJit |    RyuJit |      .NET 4.8 | 31.152 ns |  0.8449 ns |  1.2385 ns | 30.943 ns | 10.94 |    0.50 | 0.0242 |     - |     - |     152 B |
|   LogScalarBigStruct |    net48 RyuJit |    RyuJit |      .NET 4.8 | 24.160 ns |  0.3282 ns |  0.4601 ns | 24.061 ns |  8.49 |    0.25 |      - |     - |     - |         - |
|        LogDictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 | 11.281 ns |  0.1039 ns |  0.1524 ns | 11.255 ns |  3.96 |    0.09 | 0.0051 |     - |     - |      32 B |
|          LogSequence |    net48 RyuJit |    RyuJit |      .NET 4.8 | 23.452 ns |  5.0102 ns |  7.4991 ns | 22.571 ns |  7.87 |    2.26 | 0.0051 |     - |     - |      32 B |
|         LogAnonymous |    net48 RyuJit |    RyuJit |      .NET 4.8 | 25.658 ns |  3.6008 ns |  5.3894 ns | 26.798 ns |  9.19 |    1.80 | 0.0051 |     - |     - |      32 B |
|              LogMix2 |    net48 RyuJit |    RyuJit |      .NET 4.8 | 17.166 ns |  1.5232 ns |  2.2798 ns | 17.660 ns |  6.02 |    0.79 |      - |     - |     - |         - |
|              LogMix3 |    net48 RyuJit |    RyuJit |      .NET 4.8 | 17.521 ns |  0.1908 ns |  0.2675 ns | 17.476 ns |  6.15 |    0.14 |      - |     - |     - |         - |
|              LogMix4 |    net48 RyuJit |    RyuJit |      .NET 4.8 | 42.327 ns |  1.7445 ns |  2.6110 ns | 41.947 ns | 14.89 |    0.99 | 0.0216 |     - |     - |     136 B |
|              LogMix5 |    net48 RyuJit |    RyuJit |      .NET 4.8 | 59.430 ns |  7.3287 ns | 10.7423 ns | 56.777 ns | 20.95 |    3.80 | 0.0268 |     - |     - |     168 B |
|           LogMixMany |    net48 RyuJit |    RyuJit |      .NET 4.8 | 87.269 ns | 12.6780 ns | 18.5833 ns | 77.532 ns | 30.77 |    6.26 | 0.0446 |     - |     - |     281 B |
