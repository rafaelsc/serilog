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
|     Method |             Job |       Jit |       Runtime | Items | MaxDegreeOfParallelism |        Mean |        Error |     StdDev | Ratio | RatioSD |
|----------- |---------------- |---------- |-------------- |------ |----------------------- |------------:|-------------:|-----------:|------:|--------:|
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** |    **10** |                     **-1** |   **286.54 μs** |   **198.030 μs** |  **10.855 μs** |  **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    10 |                     -1 |    37.40 μs |     9.150 μs |   0.502 μs |  0.13 |    0.01 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    10 |                     -1 |    51.06 μs |    39.597 μs |   2.170 μs |  0.18 |    0.00 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |    10 |                     -1 |   893.44 μs |   762.661 μs |  41.804 μs |  1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 |    10 |                     -1 |    68.96 μs |    52.766 μs |   2.892 μs |  0.08 |    0.00 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 |    10 |                     -1 |    65.50 μs |    77.765 μs |   4.263 μs |  0.07 |    0.01 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |    10 |                     -1 |   730.66 μs |   596.795 μs |  32.712 μs |  1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 |    10 |                     -1 |    62.73 μs |    55.119 μs |   3.021 μs |  0.09 |    0.01 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 |    10 |                     -1 |    53.63 μs |    12.879 μs |   0.706 μs |  0.07 |    0.00 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** |    **10** |                      **1** |    **70.33 μs** |    **58.915 μs** |   **3.229 μs** |  **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    10 |                      1 |   113.77 μs |    21.853 μs |   1.198 μs |  1.62 |    0.08 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    10 |                      1 |   107.38 μs |    13.514 μs |   0.741 μs |  1.53 |    0.06 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |    10 |                      1 |   128.50 μs |   232.394 μs |  12.738 μs |  1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 |    10 |                      1 |   102.53 μs |   177.904 μs |   9.751 μs |  0.80 |    0.00 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 |    10 |                      1 |    93.55 μs |    90.875 μs |   4.981 μs |  0.73 |    0.06 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |    10 |                      1 |   118.37 μs |    74.826 μs |   4.101 μs |  1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 |    10 |                      1 |   105.43 μs |   151.146 μs |   8.285 μs |  0.89 |    0.08 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 |    10 |                      1 |   105.07 μs |   110.704 μs |   6.068 μs |  0.89 |    0.02 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** |    **20** |                     **-1** |   **509.14 μs** | **1,575.592 μs** |  **86.364 μs** |  **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    20 |                     -1 |    94.35 μs |    77.134 μs |   4.228 μs |  0.19 |    0.04 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    20 |                     -1 |    78.81 μs |    20.922 μs |   1.147 μs |  0.16 |    0.02 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |    20 |                     -1 | 1,177.93 μs | 1,674.818 μs |  91.802 μs |  1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 |    20 |                     -1 |    84.25 μs |    38.279 μs |   2.098 μs |  0.07 |    0.01 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 |    20 |                     -1 |    80.50 μs |    47.656 μs |   2.612 μs |  0.07 |    0.00 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |    20 |                     -1 | 1,004.30 μs | 1,137.913 μs |  62.373 μs |  1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 |    20 |                     -1 |    73.78 μs |    56.696 μs |   3.108 μs |  0.07 |    0.00 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 |    20 |                     -1 |    71.50 μs |    42.160 μs |   2.311 μs |  0.07 |    0.00 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** |    **20** |                      **1** |   **124.95 μs** |     **6.901 μs** |   **0.378 μs** |  **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    20 |                      1 |   227.52 μs |    64.488 μs |   3.535 μs |  1.82 |    0.03 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    20 |                      1 |   215.18 μs |    58.161 μs |   3.188 μs |  1.72 |    0.03 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |    20 |                      1 |   225.46 μs |   136.013 μs |   7.455 μs |  1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 |    20 |                      1 |   186.93 μs |    73.649 μs |   4.037 μs |  0.83 |    0.04 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 |    20 |                      1 |   197.04 μs |   226.017 μs |  12.389 μs |  0.88 |    0.07 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |    20 |                      1 |   234.59 μs |   104.754 μs |   5.742 μs |  1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 |    20 |                      1 |   251.59 μs |   335.829 μs |  18.408 μs |  1.07 |    0.10 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 |    20 |                      1 |   321.43 μs |   602.333 μs |  33.016 μs |  1.37 |    0.15 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** |    **50** |                     **-1** | **1,214.14 μs** | **1,172.293 μs** |  **64.257 μs** |  **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    50 |                     -1 |   215.76 μs |   145.426 μs |   7.971 μs |  0.18 |    0.02 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    50 |                     -1 |   184.65 μs |   108.784 μs |   5.963 μs |  0.15 |    0.01 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |    50 |                     -1 | 1,816.58 μs | 2,510.047 μs | 137.584 μs |  1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 |    50 |                     -1 |   190.58 μs |   131.147 μs |   7.189 μs |  0.11 |    0.00 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 |    50 |                     -1 |   167.16 μs |    79.487 μs |   4.357 μs |  0.09 |    0.01 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |    50 |                     -1 | 1,652.11 μs | 1,499.696 μs |  82.203 μs |  1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 |    50 |                     -1 |   165.28 μs |   106.156 μs |   5.819 μs |  0.10 |    0.01 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 |    50 |                     -1 |   148.53 μs |    69.320 μs |   3.800 μs |  0.09 |    0.01 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** |    **50** |                      **1** |   **342.11 μs** |    **64.534 μs** |   **3.537 μs** |  **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    50 |                      1 |   593.67 μs |    91.109 μs |   4.994 μs |  1.74 |    0.03 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    50 |                      1 |   545.48 μs |   118.091 μs |   6.473 μs |  1.59 |    0.03 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |    50 |                      1 |   600.38 μs |   818.488 μs |  44.864 μs |  1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 |    50 |                      1 |   487.26 μs |   580.766 μs |  31.834 μs |  0.81 |    0.07 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 |    50 |                      1 |   506.04 μs |   524.805 μs |  28.766 μs |  0.85 |    0.11 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |    50 |                      1 |   557.96 μs |   120.733 μs |   6.618 μs |  1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 |    50 |                      1 |   486.22 μs |   368.626 μs |  20.206 μs |  0.87 |    0.03 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 |    50 |                      1 |   458.56 μs |   190.564 μs |  10.445 μs |  0.82 |    0.03 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** |   **100** |                     **-1** | **1,095.68 μs** | **1,185.036 μs** |  **64.956 μs** |  **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   100 |                     -1 |   374.65 μs |    80.370 μs |   4.405 μs |  0.34 |    0.02 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   100 |                     -1 |   316.59 μs |   391.531 μs |  21.461 μs |  0.29 |    0.00 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |   100 |                     -1 | 3,337.81 μs | 6,068.511 μs | 332.636 μs |  1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 |   100 |                     -1 |   347.87 μs |   124.524 μs |   6.826 μs |  0.10 |    0.01 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 |   100 |                     -1 |   366.29 μs |   384.410 μs |  21.071 μs |  0.11 |    0.02 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |   100 |                     -1 | 3,036.77 μs | 4,404.881 μs | 241.446 μs |  1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 |   100 |                     -1 |   293.36 μs |   429.975 μs |  23.568 μs |  0.10 |    0.01 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 |   100 |                     -1 |   274.47 μs |   351.909 μs |  19.289 μs |  0.09 |    0.01 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** |   **100** |                      **1** |   **768.45 μs** |   **771.564 μs** |  **42.292 μs** |  **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   100 |                      1 | 1,160.20 μs |   210.965 μs |  11.564 μs |  1.51 |    0.08 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   100 |                      1 | 1,052.10 μs |    75.637 μs |   4.146 μs |  1.37 |    0.07 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |   100 |                      1 | 1,066.95 μs |   227.351 μs |  12.462 μs |  1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 |   100 |                      1 |   938.69 μs |   400.399 μs |  21.947 μs |  0.88 |    0.03 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 |   100 |                      1 |   958.48 μs | 1,086.871 μs |  59.575 μs |  0.90 |    0.05 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |   100 |                      1 | 1,097.16 μs |   468.838 μs |  25.699 μs |  1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 |   100 |                      1 |   944.72 μs |   779.568 μs |  42.731 μs |  0.86 |    0.06 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 |   100 |                      1 |   933.04 μs |   517.880 μs |  28.387 μs |  0.85 |    0.04 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** |  **1000** |                     **-1** | **1,177.24 μs** |   **677.695 μs** |  **37.147 μs** |  **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  1000 |                     -1 |   296.74 μs |   192.392 μs |  10.546 μs |  0.25 |    0.02 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  1000 |                     -1 |   324.02 μs |   626.115 μs |  34.319 μs |  0.27 |    0.02 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1000 |                     -1 | 3,750.83 μs | 2,516.470 μs | 137.936 μs |  1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1000 |                     -1 |   421.57 μs |   595.310 μs |  32.631 μs |  0.11 |    0.01 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1000 |                     -1 |   435.28 μs |   161.893 μs |   8.874 μs |  0.12 |    0.00 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1000 |                     -1 | 2,959.55 μs | 1,957.885 μs | 107.318 μs |  1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1000 |                     -1 |   329.37 μs |   293.348 μs |  16.079 μs |  0.11 |    0.01 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1000 |                     -1 |   343.68 μs |   139.345 μs |   7.638 μs |  0.12 |    0.01 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| **Dictionary** |   **core31 RyuJit** |    **RyuJit** | **.NET Core 3.1** |  **1000** |                      **1** |   **856.20 μs** | **1,823.335 μs** |  **99.943 μs** |  **1.00** |    **0.00** |
|  Hashtable |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  1000 |                      1 | 1,197.46 μs | 1,135.859 μs |  62.260 μs |  1.41 |    0.09 |
| Concurrent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  1000 |                      1 | 1,151.70 μs | 1,036.883 μs |  56.835 μs |  1.35 |    0.13 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1000 |                      1 | 1,149.74 μs |   772.059 μs |  42.319 μs |  1.00 |    0.00 |
|  Hashtable | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1000 |                      1 | 1,317.28 μs | 2,102.082 μs | 115.222 μs |  1.14 |    0.07 |
| Concurrent | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1000 |                      1 | 1,198.82 μs | 1,681.411 μs |  92.164 μs |  1.05 |    0.12 |
|            |                 |           |               |       |                        |             |              |            |       |         |
| Dictionary |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1000 |                      1 | 1,142.83 μs | 1,887.806 μs | 103.477 μs |  1.00 |    0.00 |
|  Hashtable |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1000 |                      1 | 1,068.93 μs | 1,124.273 μs |  61.625 μs |  0.94 |    0.08 |
| Concurrent |    net48 RyuJit |    RyuJit |      .NET 4.8 |  1000 |                      1 | 1,254.20 μs | 1,433.286 μs |  78.563 μs |  1.11 |    0.15 |
