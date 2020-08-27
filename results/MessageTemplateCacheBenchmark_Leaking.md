``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.450 (2004/?/20H1)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.401
  [Host]          : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  core31 RyuJit   : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  net48 LegacyJit : .NET Framework 4.8 (4.8.4200.0), X64 RyuJIT
  net48 RyuJit    : .NET Framework 4.8 (4.8.4200.0), X64 RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|     Method |             Job |       Jit |       Runtime | Items | OverflowCount | MaxDegreeOfParallelism |       Mean |       Error |     StdDev |  Ratio | RatioSD |
|----------- |---------------- |---------- |-------------- |------ |-------------- |----------------------- |-----------:|------------:|-----------:|-------:|--------:|
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** | **10000** |             **1** |                     **-1** |   **1.738 ms** |   **0.6258 ms** |  **0.0343 ms** |   **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |             1 |                     -1 |   1.607 ms |   1.9019 ms |  0.1042 ms |   0.92 |    0.05 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |             1 |                     -1 |  54.703 ms | 238.5414 ms | 13.0753 ms |  31.40 |    7.03 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |             1 |                     -1 |   5.669 ms |  10.2880 ms |  0.5639 ms |   1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |             1 |                     -1 |  19.993 ms |  11.7262 ms |  0.6428 ms |   3.55 |    0.44 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |             1 |                     -1 |  81.180 ms | 106.8474 ms |  5.8567 ms |  14.35 |    0.49 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |             1 |                     -1 |   4.951 ms |  12.0212 ms |  0.6589 ms |   1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |             1 |                     -1 |  20.888 ms |  51.4790 ms |  2.8217 ms |   4.32 |    1.21 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |             1 |                     -1 |  66.893 ms |  70.6475 ms |  3.8724 ms |  13.67 |    1.90 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** | **10000** |             **1** |                      **1** |   **1.438 ms** |   **3.2705 ms** |  **0.1793 ms** |   **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |             1 |                      1 |   2.703 ms |   4.8247 ms |  0.2645 ms |   1.89 |    0.13 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |             1 |                      1 | 261.613 ms | 294.2387 ms | 16.1282 ms | 184.77 |   34.90 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |             1 |                      1 |   2.225 ms |   1.9634 ms |  0.1076 ms |   1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |             1 |                      1 |   2.258 ms |   3.1987 ms |  0.1753 ms |   1.02 |    0.13 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |             1 |                      1 | 281.308 ms | 264.3044 ms | 14.4874 ms | 126.85 |   12.95 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |             1 |                      1 |   2.041 ms |   1.7979 ms |  0.0986 ms |   1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |             1 |                      1 |   2.033 ms |   0.4625 ms |  0.0253 ms |   1.00 |    0.06 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |             1 |                      1 | 262.904 ms |  18.8776 ms |  1.0347 ms | 129.02 |    5.92 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** | **10000** |            **10** |                     **-1** |   **1.897 ms** |   **3.4104 ms** |  **0.1869 ms** |   **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |            10 |                     -1 |   1.506 ms |   0.5669 ms |  0.0311 ms |   0.80 |    0.10 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |            10 |                     -1 |  60.178 ms |  68.9096 ms |  3.7772 ms |  31.83 |    1.81 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |            10 |                     -1 |   3.580 ms |   5.2593 ms |  0.2883 ms |   1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |            10 |                     -1 |  18.225 ms |   5.0081 ms |  0.2745 ms |   5.11 |    0.36 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |            10 |                     -1 |  80.583 ms | 163.1039 ms |  8.9403 ms |  22.73 |    4.18 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |            10 |                     -1 |   5.785 ms |   9.2181 ms |  0.5053 ms |   1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |            10 |                     -1 |  18.865 ms |   8.7241 ms |  0.4782 ms |   3.28 |    0.38 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |            10 |                     -1 |  82.514 ms | 186.4511 ms | 10.2200 ms |  14.45 |    3.17 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** | **10000** |            **10** |                      **1** |   **1.499 ms** |   **1.7275 ms** |  **0.0947 ms** |   **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |            10 |                      1 |   2.878 ms |   1.1953 ms |  0.0655 ms |   1.92 |    0.08 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |            10 |                      1 | 278.668 ms | 491.8313 ms | 26.9589 ms | 185.62 |    6.30 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |            10 |                      1 |   2.142 ms |   1.3835 ms |  0.0758 ms |   1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |            10 |                      1 |   2.201 ms |   2.5502 ms |  0.1398 ms |   1.03 |    0.07 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |            10 |                      1 | 299.951 ms | 205.6941 ms | 11.2748 ms | 140.24 |    9.95 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |            10 |                      1 |   2.107 ms |   2.6029 ms |  0.1427 ms |   1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |            10 |                      1 |   2.033 ms |   2.2835 ms |  0.1252 ms |   0.97 |    0.13 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |            10 |                      1 | 276.657 ms | 304.8572 ms | 16.7103 ms | 131.42 |    5.46 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** | **10000** |           **100** |                     **-1** |   **2.034 ms** |   **1.4244 ms** |  **0.0781 ms** |   **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |           100 |                     -1 |   2.174 ms |   5.2417 ms |  0.2873 ms |   1.07 |    0.15 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |           100 |                     -1 | 132.468 ms | 430.5882 ms | 23.6020 ms |  65.16 |   11.68 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |           100 |                     -1 |   4.014 ms |   7.0223 ms |  0.3849 ms |   1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |           100 |                     -1 |  19.430 ms |  17.6127 ms |  0.9654 ms |   4.89 |    0.73 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |           100 |                     -1 |  73.236 ms |  97.6815 ms |  5.3543 ms |  18.39 |    2.49 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |           100 |                     -1 |   3.746 ms |   1.7589 ms |  0.0964 ms |   1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |           100 |                     -1 |  20.626 ms |  24.9502 ms |  1.3676 ms |   5.50 |    0.25 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |           100 |                     -1 |  85.932 ms | 421.2909 ms | 23.0924 ms |  22.89 |    5.93 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** | **10000** |           **100** |                      **1** |   **2.159 ms** |   **6.9340 ms** |  **0.3801 ms** |   **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |           100 |                      1 |   3.253 ms |   7.4502 ms |  0.4084 ms |   1.56 |    0.50 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |           100 |                      1 | 339.625 ms | 637.9636 ms | 34.9689 ms | 159.45 |   21.21 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |           100 |                      1 |   2.556 ms |   3.1015 ms |  0.1700 ms |   1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |           100 |                      1 |   2.328 ms |   2.3325 ms |  0.1279 ms |   0.91 |    0.06 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |           100 |                      1 | 300.196 ms | 227.1583 ms | 12.4513 ms | 117.99 |   12.82 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |           100 |                      1 |   2.387 ms |   0.9016 ms |  0.0494 ms |   1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |           100 |                      1 |   2.249 ms |   2.5438 ms |  0.1394 ms |   0.94 |    0.06 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |           100 |                      1 | 306.193 ms | 275.6007 ms | 15.1066 ms | 128.27 |    5.71 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** | **10000** |          **1000** |                     **-1** |   **3.400 ms** |   **5.5213 ms** |  **0.3026 ms** |   **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |          1000 |                     -1 |   3.249 ms |   5.6337 ms |  0.3088 ms |   0.96 |    0.03 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |          1000 |                     -1 | 216.556 ms | 644.8598 ms | 35.3469 ms |  64.65 |   16.31 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |          1000 |                     -1 |   4.400 ms |   6.1242 ms |  0.3357 ms |   1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |          1000 |                     -1 |  18.384 ms |  20.9233 ms |  1.1469 ms |   4.20 |    0.43 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |          1000 |                     -1 | 210.040 ms | 706.7313 ms | 38.7383 ms |  48.35 |   12.44 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |          1000 |                     -1 |   4.215 ms |   5.1144 ms |  0.2803 ms |   1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |          1000 |                     -1 |  18.827 ms |   7.0797 ms |  0.3881 ms |   4.48 |    0.28 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |          1000 |                     -1 | 167.779 ms | 546.6560 ms | 29.9641 ms |  40.10 |    9.12 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** | **10000** |          **1000** |                      **1** |   **1.156 ms** |   **0.2700 ms** |  **0.0148 ms** |   **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |          1000 |                      1 |   2.233 ms |   0.0774 ms |  0.0042 ms |   1.93 |    0.02 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 10000 |          1000 |                      1 | 251.427 ms |  48.7125 ms |  2.6701 ms | 217.61 |    4.56 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |          1000 |                      1 |   1.974 ms |   1.0496 ms |  0.0575 ms |   1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |          1000 |                      1 |   1.923 ms |   0.5707 ms |  0.0313 ms |   0.97 |    0.04 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 | 10000 |          1000 |                      1 | 266.346 ms |  39.6225 ms |  2.1718 ms | 135.02 |    4.23 |
|            |                 |           |               |       |               |                        |            |             |            |        |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |          1000 |                      1 |   1.996 ms |   0.8843 ms |  0.0485 ms |   1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |          1000 |                      1 |   2.618 ms |   8.3816 ms |  0.4594 ms |   1.32 |    0.26 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 | 10000 |          1000 |                      1 | 378.270 ms | 195.1367 ms | 10.6961 ms | 189.64 |    7.59 |
