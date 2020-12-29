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
|               Method |    Job |       Runtime |          Mean |       Error |      StdDev |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |-------------- |--------------:|------------:|------------:|---------:|--------:|-------:|------:|------:|----------:|
|             LogEmpty | core31 | .NET Core 3.1 |      6.011 ns |   0.1626 ns |   0.2434 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher | core31 | .NET Core 3.1 |     61.725 ns |   1.5863 ns |   2.3743 ns |    10.29 |    0.58 | 0.0038 |     - |     - |      24 B |
|               LogMsg | core31 | .NET Core 3.1 |    440.301 ns |   3.5348 ns |   5.2907 ns |    73.36 |    2.77 | 0.0100 |     - |     - |      64 B |
|         LogMsgWithEx | core31 | .NET Core 3.1 |    438.741 ns |   4.0690 ns |   5.9643 ns |    72.96 |    2.40 | 0.0100 |     - |     - |      64 B |
|           LogScalar1 | core31 | .NET Core 3.1 |    651.587 ns |  18.1949 ns |  26.6698 ns |   108.31 |    4.48 | 0.0582 |     - |     - |     368 B |
|           LogScalar2 | core31 | .NET Core 3.1 |    704.230 ns |  11.3482 ns |  16.9854 ns |   117.30 |    4.27 | 0.0658 |     - |     - |     416 B |
|           LogScalar3 | core31 | .NET Core 3.1 |    789.872 ns |  14.8103 ns |  22.1674 ns |   131.68 |    7.65 | 0.0734 |     - |     - |     464 B |
|        LogScalarMany | core31 | .NET Core 3.1 |    839.167 ns |  10.8113 ns |  15.5053 ns |   139.53 |    6.43 | 0.0992 |     - |     - |     624 B |
|     LogScalarStruct1 | core31 | .NET Core 3.1 |    675.981 ns |   9.4834 ns |  13.9006 ns |   112.47 |    5.61 | 0.0620 |     - |     - |     392 B |
|     LogScalarStruct2 | core31 | .NET Core 3.1 |    768.602 ns |   8.8382 ns |  12.9549 ns |   127.84 |    5.05 | 0.0734 |     - |     - |     464 B |
|     LogScalarStruct3 | core31 | .NET Core 3.1 |    879.306 ns |  12.5567 ns |  18.7943 ns |   146.49 |    5.98 | 0.0849 |     - |     - |     536 B |
|  LogScalarStructMany | core31 | .NET Core 3.1 |    983.875 ns |  16.3507 ns |  23.4497 ns |   163.60 |    8.25 | 0.1144 |     - |     - |     720 B |
|   LogScalarBigStruct | core31 | .NET Core 3.1 |    791.998 ns |   7.0871 ns |  10.1641 ns |   131.68 |    5.87 | 0.0706 |     - |     - |     448 B |
|        LogDictionary | core31 | .NET Core 3.1 |  2,899.813 ns |  46.6396 ns |  68.3638 ns |   482.37 |   22.43 | 0.3395 |     - |     - |    2144 B |
|          LogSequence | core31 | .NET Core 3.1 |  1,264.326 ns |  18.3392 ns |  27.4493 ns |   210.72 |   10.51 | 0.1297 |     - |     - |     816 B |
|         LogAnonymous | core31 | .NET Core 3.1 |  4,928.725 ns |  94.6427 ns | 141.6567 ns |   820.97 |   33.65 | 0.5417 |     - |     - |    3432 B |
|              LogMix2 | core31 | .NET Core 3.1 |    724.278 ns |  12.3150 ns |  18.4325 ns |   120.73 |    6.67 | 0.0696 |     - |     - |     440 B |
|              LogMix3 | core31 | .NET Core 3.1 |    796.768 ns |   8.2674 ns |  12.3742 ns |   132.77 |    5.89 | 0.0811 |     - |     - |     512 B |
|              LogMix4 | core31 | .NET Core 3.1 |    884.814 ns |  10.8773 ns |  16.2806 ns |   147.47 |    7.25 | 0.1116 |     - |     - |     704 B |
|              LogMix5 | core31 | .NET Core 3.1 |    974.551 ns |  19.6738 ns |  29.4469 ns |   162.30 |    5.95 | 0.1221 |     - |     - |     776 B |
|           LogMixMany | core31 | .NET Core 3.1 |  9,660.993 ns | 177.3194 ns | 265.4034 ns | 1,608.96 |   57.36 | 1.0223 |     - |     - |    6448 B |
|                      |        |               |               |             |             |          |         |        |       |       |           |
|             LogEmpty |  net48 |      .NET 4.8 |      5.725 ns |   0.0903 ns |   0.1351 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher |  net48 |      .NET 4.8 |     69.573 ns |   1.7010 ns |   2.5460 ns |    12.16 |    0.53 | 0.0038 |     - |     - |      24 B |
|               LogMsg |  net48 |      .NET 4.8 |    496.976 ns |   7.6752 ns |  11.4878 ns |    86.85 |    2.41 | 0.0095 |     - |     - |      64 B |
|         LogMsgWithEx |  net48 |      .NET 4.8 |    498.200 ns |   8.2139 ns |  12.2942 ns |    87.07 |    2.88 | 0.0095 |     - |     - |      64 B |
|           LogScalar1 |  net48 |      .NET 4.8 |    625.129 ns |   9.0957 ns |  13.6140 ns |   109.25 |    3.28 | 0.0591 |     - |     - |     377 B |
|           LogScalar2 |  net48 |      .NET 4.8 |    700.454 ns |  11.6148 ns |  17.3846 ns |   122.44 |    4.52 | 0.0668 |     - |     - |     425 B |
|           LogScalar3 |  net48 |      .NET 4.8 |    774.586 ns |  10.9293 ns |  16.3585 ns |   135.40 |    4.75 | 0.0744 |     - |     - |     473 B |
|        LogScalarMany |  net48 |      .NET 4.8 |    806.962 ns |  10.3663 ns |  15.1948 ns |   141.05 |    4.06 | 0.1001 |     - |     - |     634 B |
|     LogScalarStruct1 |  net48 |      .NET 4.8 |    671.438 ns |   7.2140 ns |  10.7976 ns |   117.37 |    4.08 | 0.0629 |     - |     - |     401 B |
|     LogScalarStruct2 |  net48 |      .NET 4.8 |    770.146 ns |   7.8543 ns |  11.7560 ns |   134.61 |    3.91 | 0.0744 |     - |     - |     473 B |
|     LogScalarStruct3 |  net48 |      .NET 4.8 |    878.931 ns |   8.3505 ns |  12.4986 ns |   153.63 |    4.48 | 0.0858 |     - |     - |     546 B |
|  LogScalarStructMany |  net48 |      .NET 4.8 |    960.555 ns |  14.7257 ns |  22.0407 ns |   167.92 |    6.63 | 0.1144 |     - |     - |     730 B |
|   LogScalarBigStruct |  net48 |      .NET 4.8 |    763.989 ns |   8.1253 ns |  12.1616 ns |   133.52 |    3.61 | 0.0725 |     - |     - |     457 B |
|        LogDictionary |  net48 |      .NET 4.8 |  3,235.512 ns |  28.2850 ns |  42.3356 ns |   565.48 |   14.50 | 0.3548 |     - |     - |    2247 B |
|          LogSequence |  net48 |      .NET 4.8 |  1,304.499 ns |  16.7936 ns |  25.1359 ns |   228.03 |    7.79 | 0.1297 |     - |     - |     826 B |
|         LogAnonymous |  net48 |      .NET 4.8 |  5,558.829 ns |  88.9678 ns | 133.1628 ns |   971.31 |   23.82 | 0.5493 |     - |     - |    3483 B |
|              LogMix2 |  net48 |      .NET 4.8 |    714.451 ns |   8.5590 ns |  12.8106 ns |   124.85 |    2.99 | 0.0706 |     - |     - |     449 B |
|              LogMix3 |  net48 |      .NET 4.8 |    823.895 ns |   8.7236 ns |  13.0571 ns |   144.00 |    4.22 | 0.0820 |     - |     - |     522 B |
|              LogMix4 |  net48 |      .NET 4.8 |    905.985 ns |   7.9830 ns |  11.9485 ns |   158.36 |    4.61 | 0.1135 |     - |     - |     714 B |
|              LogMix5 |  net48 |      .NET 4.8 |    999.302 ns |  23.6672 ns |  35.4240 ns |   174.64 |    7.11 | 0.1240 |     - |     - |     786 B |
|           LogMixMany |  net48 |      .NET 4.8 | 10,563.706 ns | 151.5484 ns | 226.8305 ns | 1,845.94 |   45.49 | 1.0376 |     - |     - |    6596 B |
|                      |        |               |               |             |             |          |         |        |       |       |           |
|             LogEmpty |  net50 | .NET Core 5.0 |      5.646 ns |   0.0522 ns |   0.0782 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher |  net50 | .NET Core 5.0 |     48.867 ns |   0.7346 ns |   1.0995 ns |     8.66 |    0.21 | 0.0038 |     - |     - |      24 B |
|               LogMsg |  net50 | .NET Core 5.0 |    257.072 ns |   4.6593 ns |   6.9738 ns |    45.54 |    1.51 | 0.0100 |     - |     - |      64 B |
|         LogMsgWithEx |  net50 | .NET Core 5.0 |    255.673 ns |   4.6860 ns |   6.8687 ns |    45.23 |    1.15 | 0.0100 |     - |     - |      64 B |
|           LogScalar1 |  net50 | .NET Core 5.0 |    366.243 ns |   5.0056 ns |   7.4922 ns |    64.87 |    1.47 | 0.0596 |     - |     - |     376 B |
|           LogScalar2 |  net50 | .NET Core 5.0 |    407.215 ns |   4.6742 ns |   6.9962 ns |    72.13 |    1.58 | 0.0672 |     - |     - |     424 B |
|           LogScalar3 |  net50 | .NET Core 5.0 |    469.308 ns |   7.5770 ns |  11.3410 ns |    83.13 |    2.15 | 0.0749 |     - |     - |     472 B |
|        LogScalarMany |  net50 | .NET Core 5.0 |    523.761 ns |   9.2394 ns |  13.8291 ns |    92.78 |    2.87 | 0.1001 |     - |     - |     632 B |
|     LogScalarStruct1 |  net50 | .NET Core 5.0 |    398.590 ns |   4.2841 ns |   6.4122 ns |    70.61 |    1.49 | 0.0634 |     - |     - |     400 B |
|     LogScalarStruct2 |  net50 | .NET Core 5.0 |    479.123 ns |   6.8993 ns |  10.3266 ns |    84.87 |    1.99 | 0.0749 |     - |     - |     472 B |
|     LogScalarStruct3 |  net50 | .NET Core 5.0 |    581.604 ns |  10.6494 ns |  15.9395 ns |   103.02 |    3.06 | 0.0858 |     - |     - |     544 B |
|  LogScalarStructMany |  net50 | .NET Core 5.0 |    645.390 ns |   8.2525 ns |  12.3520 ns |   114.33 |    2.88 | 0.1154 |     - |     - |     728 B |
|   LogScalarBigStruct |  net50 | .NET Core 5.0 |    492.926 ns |   7.8639 ns |  11.7704 ns |    87.32 |    2.44 | 0.0725 |     - |     - |     456 B |
|        LogDictionary |  net50 | .NET Core 5.0 |  2,407.212 ns |  32.5375 ns |  48.7005 ns |   426.43 |   11.31 | 0.3471 |     - |     - |    2200 B |
|          LogSequence |  net50 | .NET Core 5.0 |    916.991 ns |   8.1708 ns |  12.2296 ns |   162.44 |    3.18 | 0.1307 |     - |     - |     824 B |
|         LogAnonymous |  net50 | .NET Core 5.0 |  4,331.018 ns |  62.5379 ns |  93.6037 ns |   767.18 |   19.05 | 0.5493 |     - |     - |    3472 B |
|              LogMix2 |  net50 | .NET Core 5.0 |    441.355 ns |   3.6644 ns |   5.4847 ns |    78.18 |    1.49 | 0.0710 |     - |     - |     448 B |
|              LogMix3 |  net50 | .NET Core 5.0 |    513.457 ns |   8.7764 ns |  13.1362 ns |    90.95 |    2.71 | 0.0820 |     - |     - |     520 B |
|              LogMix4 |  net50 | .NET Core 5.0 |    585.005 ns |   8.0997 ns |  11.8724 ns |   103.52 |    2.69 | 0.1135 |     - |     - |     712 B |
|              LogMix5 |  net50 | .NET Core 5.0 |    643.145 ns |   7.7826 ns |  11.6486 ns |   113.92 |    2.42 | 0.1249 |     - |     - |     784 B |
|           LogMixMany |  net50 | .NET Core 5.0 |  8,116.281 ns | 136.3315 ns | 204.0546 ns | 1,437.79 |   44.34 | 1.0376 |     - |     - |    6537 B |
