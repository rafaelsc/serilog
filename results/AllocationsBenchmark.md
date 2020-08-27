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
|               Method |             Job |       Jit |       Runtime |          Mean |       Error |      StdDev |        Median |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |---------------- |---------- |-------------- |--------------:|------------:|------------:|--------------:|---------:|--------:|-------:|------:|------:|----------:|
|             LogEmpty |   core31 RyuJit |    RyuJit | .NET Core 3.1 |      9.015 ns |   0.1062 ns |   0.1418 ns |      9.005 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher |   core31 RyuJit |    RyuJit | .NET Core 3.1 |     66.401 ns |   0.7773 ns |   1.1148 ns |     66.283 ns |     7.37 |    0.14 | 0.0038 |     - |     - |      24 B |
|               LogMsg |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    514.779 ns |  15.5766 ns |  22.3395 ns |    506.808 ns |    56.89 |    2.78 | 0.0095 |     - |     - |      64 B |
|         LogMsgWithEx |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    489.979 ns |   5.1234 ns |   7.5098 ns |    490.075 ns |    54.44 |    1.35 | 0.0095 |     - |     - |      64 B |
|           LogScalar1 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    688.858 ns |   5.7613 ns |   8.4448 ns |    690.853 ns |    76.49 |    1.63 | 0.0582 |     - |     - |     368 B |
|           LogScalar2 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    778.858 ns |  11.9084 ns |  17.8240 ns |    777.789 ns |    86.72 |    2.24 | 0.0839 |     - |     - |     528 B |
|           LogScalar3 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    859.874 ns |   9.8519 ns |  14.7458 ns |    859.396 ns |    95.57 |    2.38 | 0.0916 |     - |     - |     576 B |
|        LogScalarMany |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    930.316 ns |  16.7438 ns |  23.4724 ns |    923.688 ns |   103.01 |    2.38 | 0.0992 |     - |     - |     624 B |
|     LogScalarStruct1 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    734.989 ns |   8.6108 ns |  12.8883 ns |    731.133 ns |    81.64 |    2.02 | 0.0620 |     - |     - |     392 B |
|     LogScalarStruct2 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    854.730 ns |  12.1465 ns |  17.8042 ns |    854.371 ns |    94.83 |    2.47 | 0.0916 |     - |     - |     576 B |
|     LogScalarStruct3 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    995.467 ns |  23.2683 ns |  34.1063 ns |    992.091 ns |   110.97 |    3.97 | 0.1030 |     - |     - |     648 B |
|  LogScalarStructMany |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  1,062.137 ns |  15.1680 ns |  22.7028 ns |  1,062.586 ns |   117.59 |    2.69 | 0.1144 |     - |     - |     720 B |
|   LogScalarBigStruct |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    848.017 ns |   9.0703 ns |  13.2951 ns |    843.941 ns |    94.26 |    1.88 | 0.0706 |     - |     - |     448 B |
|        LogDictionary |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  3,073.911 ns |  27.1408 ns |  39.7826 ns |  3,094.782 ns |   341.31 |    6.58 | 0.3395 |     - |     - |    2144 B |
|          LogSequence |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  1,368.514 ns |  16.5327 ns |  24.7453 ns |  1,368.078 ns |   152.30 |    3.25 | 0.1297 |     - |     - |     816 B |
|         LogAnonymous |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  5,340.089 ns |  98.7530 ns | 144.7509 ns |  5,342.215 ns |   590.25 |   20.61 | 0.5417 |     - |     - |    3432 B |
|              LogMix2 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    795.624 ns |   4.7898 ns |   7.0208 ns |    794.946 ns |    88.29 |    1.48 | 0.0877 |     - |     - |     552 B |
|              LogMix3 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    892.415 ns |   7.9610 ns |  11.6691 ns |    892.410 ns |    98.95 |    1.98 | 0.0992 |     - |     - |     624 B |
|              LogMix4 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    965.674 ns |  13.1758 ns |  19.7209 ns |    964.713 ns |   106.59 |    2.43 | 0.1106 |     - |     - |     704 B |
|              LogMix5 |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  1,109.548 ns |  33.9024 ns |  47.5264 ns |  1,086.911 ns |   123.33 |    5.43 | 0.1221 |     - |     - |     776 B |
|           LogMixMany |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10,755.371 ns |  99.4151 ns | 136.0806 ns | 10,735.041 ns | 1,193.37 |   24.80 | 1.0223 |     - |     - |    6449 B |
|                      |                 |           |               |               |             |             |               |          |         |        |       |       |           |
|             LogEmpty | net48 LegacyJit | LegacyJit |      .NET 4.8 |      8.873 ns |   0.0702 ns |   0.0985 ns |      8.858 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher | net48 LegacyJit | LegacyJit |      .NET 4.8 |     72.636 ns |   0.7842 ns |   1.0734 ns |     72.553 ns |     8.19 |    0.17 | 0.0038 |     - |     - |      24 B |
|               LogMsg | net48 LegacyJit | LegacyJit |      .NET 4.8 |    530.643 ns |   5.0170 ns |   7.3538 ns |    531.563 ns |    59.81 |    1.10 | 0.0095 |     - |     - |      64 B |
|         LogMsgWithEx | net48 LegacyJit | LegacyJit |      .NET 4.8 |    527.715 ns |   4.4217 ns |   6.6181 ns |    527.207 ns |    59.40 |    0.82 | 0.0095 |     - |     - |      64 B |
|           LogScalar1 | net48 LegacyJit | LegacyJit |      .NET 4.8 |    729.504 ns |  27.7693 ns |  39.8259 ns |    725.107 ns |    82.11 |    4.72 | 0.0591 |     - |     - |     377 B |
|           LogScalar2 | net48 LegacyJit | LegacyJit |      .NET 4.8 |    804.430 ns |  19.0675 ns |  26.0998 ns |    799.488 ns |    90.64 |    2.83 | 0.0849 |     - |     - |     538 B |
|           LogScalar3 | net48 LegacyJit | LegacyJit |      .NET 4.8 |    941.267 ns |  54.7813 ns |  76.7958 ns |    899.675 ns |   106.08 |    8.52 | 0.0925 |     - |     - |     586 B |
|        LogScalarMany | net48 LegacyJit | LegacyJit |      .NET 4.8 |    943.482 ns |  30.2313 ns |  43.3569 ns |    946.762 ns |   106.62 |    4.72 | 0.1001 |     - |     - |     634 B |
|     LogScalarStruct1 | net48 LegacyJit | LegacyJit |      .NET 4.8 |    721.555 ns |  12.3884 ns |  17.3668 ns |    715.431 ns |    81.33 |    1.81 | 0.0629 |     - |     - |     401 B |
|     LogScalarStruct2 | net48 LegacyJit | LegacyJit |      .NET 4.8 |    882.380 ns |  36.0707 ns |  52.8720 ns |    841.953 ns |    99.07 |    6.37 | 0.0916 |     - |     - |     586 B |
|     LogScalarStruct3 | net48 LegacyJit | LegacyJit |      .NET 4.8 |    949.742 ns |   7.6273 ns |  10.9389 ns |    951.443 ns |   106.99 |    1.67 | 0.1040 |     - |     - |     658 B |
|  LogScalarStructMany | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1,041.363 ns |  11.3183 ns |  16.5902 ns |  1,042.744 ns |   117.30 |    2.01 | 0.1144 |     - |     - |     730 B |
|   LogScalarBigStruct | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1,011.119 ns |   8.5338 ns |  12.5088 ns |  1,011.326 ns |   113.96 |    1.90 | 0.0725 |     - |     - |     457 B |
|        LogDictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |  3,562.122 ns |  83.1218 ns | 116.5251 ns |  3,571.325 ns |   401.49 |   12.92 | 0.3548 |     - |     - |    2247 B |
|          LogSequence | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1,375.562 ns |  11.1566 ns |  16.3531 ns |  1,375.384 ns |   155.09 |    2.03 | 0.1297 |     - |     - |     826 B |
|         LogAnonymous | net48 LegacyJit | LegacyJit |      .NET 4.8 |  6,036.234 ns |  47.3615 ns |  70.8884 ns |  6,036.004 ns |   679.81 |   11.65 | 0.5493 |     - |     - |    3483 B |
|              LogMix2 | net48 LegacyJit | LegacyJit |      .NET 4.8 |    781.478 ns |   4.2711 ns |   6.2605 ns |    780.877 ns |    88.10 |    1.18 | 0.0887 |     - |     - |     562 B |
|              LogMix3 | net48 LegacyJit | LegacyJit |      .NET 4.8 |    949.794 ns |  48.8910 ns |  68.5384 ns |    899.258 ns |   107.04 |    7.53 | 0.1001 |     - |     - |     634 B |
|              LogMix4 | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1,024.431 ns |  42.0121 ns |  60.2525 ns |  1,003.725 ns |   115.23 |    7.20 | 0.1125 |     - |     - |     714 B |
|              LogMix5 | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1,074.292 ns |  21.8695 ns |  32.7332 ns |  1,065.802 ns |   121.20 |    4.03 | 0.1240 |     - |     - |     786 B |
|           LogMixMany | net48 LegacyJit | LegacyJit |      .NET 4.8 | 11,587.197 ns |  81.0635 ns | 118.8218 ns | 11,599.271 ns | 1,305.63 |   21.91 | 1.0376 |     - |     - |    6596 B |
|                      |                 |           |               |               |             |             |               |          |         |        |       |       |           |
|             LogEmpty |    net48 RyuJit |    RyuJit |      .NET 4.8 |      8.693 ns |   0.0798 ns |   0.1195 ns |      8.708 ns |     1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher |    net48 RyuJit |    RyuJit |      .NET 4.8 |     71.109 ns |   0.7990 ns |   1.1959 ns |     70.863 ns |     8.18 |    0.18 | 0.0038 |     - |     - |      24 B |
|               LogMsg |    net48 RyuJit |    RyuJit |      .NET 4.8 |    550.794 ns |  20.9960 ns |  31.4258 ns |    549.115 ns |    63.38 |    3.86 | 0.0095 |     - |     - |      64 B |
|         LogMsgWithEx |    net48 RyuJit |    RyuJit |      .NET 4.8 |    550.235 ns |  22.6189 ns |  33.1545 ns |    528.380 ns |    63.31 |    3.70 | 0.0095 |     - |     - |      64 B |
|           LogScalar1 |    net48 RyuJit |    RyuJit |      .NET 4.8 |    697.812 ns |  21.5290 ns |  32.2236 ns |    702.985 ns |    80.27 |    3.59 | 0.0591 |     - |     - |     377 B |
|           LogScalar2 |    net48 RyuJit |    RyuJit |      .NET 4.8 |    793.603 ns |  26.3213 ns |  38.5814 ns |    809.410 ns |    91.34 |    4.79 | 0.0849 |     - |     - |     538 B |
|           LogScalar3 |    net48 RyuJit |    RyuJit |      .NET 4.8 |    877.865 ns |  32.8804 ns |  49.2139 ns |    877.170 ns |   100.99 |    5.65 | 0.0925 |     - |     - |     586 B |
|        LogScalarMany |    net48 RyuJit |    RyuJit |      .NET 4.8 |    877.620 ns |   5.7637 ns |   8.6268 ns |    877.238 ns |   100.97 |    1.37 | 0.1001 |     - |     - |     634 B |
|     LogScalarStruct1 |    net48 RyuJit |    RyuJit |      .NET 4.8 |    714.628 ns |   5.4780 ns |   8.1993 ns |    713.215 ns |    82.22 |    1.30 | 0.0629 |     - |     - |     401 B |
|     LogScalarStruct2 |    net48 RyuJit |    RyuJit |      .NET 4.8 |    888.932 ns |  34.3326 ns |  51.3874 ns |    890.057 ns |   102.29 |    6.36 | 0.0925 |     - |     - |     586 B |
|     LogScalarStruct3 |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1,034.337 ns |  57.2290 ns |  83.8855 ns |    971.751 ns |   119.01 |    9.50 | 0.1030 |     - |     - |     658 B |
|  LogScalarStructMany |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1,136.752 ns |  35.4592 ns |  50.8545 ns |  1,150.864 ns |   130.78 |    6.25 | 0.1144 |     - |     - |     730 B |
|   LogScalarBigStruct |    net48 RyuJit |    RyuJit |      .NET 4.8 |    875.463 ns |  19.2169 ns |  27.5603 ns |    867.881 ns |   100.70 |    3.22 | 0.0725 |     - |     - |     457 B |
|        LogDictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |  3,444.946 ns |  22.4807 ns |  31.5148 ns |  3,449.770 ns |   396.46 |    7.41 | 0.3548 |     - |     - |    2247 B |
|          LogSequence |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1,382.500 ns |  11.9059 ns |  17.8202 ns |  1,384.201 ns |   159.05 |    2.03 | 0.1297 |     - |     - |     826 B |
|         LogAnonymous |    net48 RyuJit |    RyuJit |      .NET 4.8 |  6,184.710 ns |  33.2221 ns |  47.6462 ns |  6,183.972 ns |   711.49 |   11.76 | 0.5493 |     - |     - |    3483 B |
|              LogMix2 |    net48 RyuJit |    RyuJit |      .NET 4.8 |    781.421 ns |   5.5645 ns |   8.3286 ns |    782.573 ns |    89.91 |    1.74 | 0.0887 |     - |     - |     562 B |
|              LogMix3 |    net48 RyuJit |    RyuJit |      .NET 4.8 |    910.810 ns |   9.8094 ns |  14.6822 ns |    910.744 ns |   104.79 |    2.23 | 0.1001 |     - |     - |     634 B |
|              LogMix4 |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1,033.700 ns |  51.0563 ns |  73.2235 ns |    990.787 ns |   118.89 |    8.29 | 0.1125 |     - |     - |     714 B |
|              LogMix5 |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1,137.874 ns |  57.6592 ns |  84.5161 ns |  1,075.578 ns |   130.97 |   10.18 | 0.1240 |     - |     - |     786 B |
|           LogMixMany |    net48 RyuJit |    RyuJit |      .NET 4.8 | 11,674.275 ns | 152.6165 ns | 228.4291 ns | 11,676.505 ns | 1,343.13 |   30.37 | 1.0376 |     - |     - |    6596 B |
