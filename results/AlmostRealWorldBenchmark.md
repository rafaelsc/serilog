``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.101
  [Host]           : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  core22 RyuJit    : .NET Core 2.2.8 (CoreCLR 4.6.28207.03, CoreFX 4.6.28208.02), X64 RyuJIT
  core31 RyuJit    : .NET Core 3.1.10 (CoreCLR 4.700.20.51601, CoreFX 4.700.20.51901), X64 RyuJIT
  net462 LegacyJit : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  net462 RyuJit    : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  net472 LegacyJit : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  net472 RyuJit    : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  net48 LegacyJit  : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  net48 RyuJit     : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  net50 RyuJit     : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
|                     Method |              Job |       Jit |       Runtime |        Mean |        Error |      StdDev |  Ratio | RatioSD |     Gen 0 |    Gen 1 | Gen 2 |   Allocated |
|--------------------------- |----------------- |---------- |-------------- |------------:|-------------:|------------:|-------:|--------:|----------:|---------:|------:|------------:|
| SimulateAAppWithoutSerilog |    core22 RyuJit |    RyuJit | .NET Core 2.2 |    148.6 μs |     45.95 μs |     2.52 μs |   1.00 |    0.00 |    6.3477 |   0.4883 |     - |    39.16 KB |
| SimulateAAppWithSerilogOff |    core22 RyuJit |    RyuJit | .NET Core 2.2 |  1,479.4 μs |    740.27 μs |    40.58 μs |   9.96 |    0.40 |  439.4531 |  48.8281 |     - |  2702.13 KB |
|  SimulateAAppWithSerilogOn |    core22 RyuJit |    RyuJit | .NET Core 2.2 | 54,980.8 μs | 26,325.26 μs | 1,442.98 μs | 369.86 |    3.96 | 7800.0000 | 100.0000 |     - | 48456.43 KB |
|                            |                  |           |               |             |              |             |        |         |           |          |       |             |
| SimulateAAppWithoutSerilog |    core31 RyuJit |    RyuJit | .NET Core 3.1 |    136.2 μs |     15.56 μs |     0.85 μs |   1.00 |    0.00 |    6.3477 |   0.7324 |     - |    39.16 KB |
| SimulateAAppWithSerilogOff |    core31 RyuJit |    RyuJit | .NET Core 3.1 |  1,462.4 μs |    455.27 μs |    24.95 μs |  10.73 |    0.12 |  439.4531 |  54.6875 |     - |  2702.13 KB |
|  SimulateAAppWithSerilogOn |    core31 RyuJit |    RyuJit | .NET Core 3.1 | 53,823.6 μs | 34,178.68 μs | 1,873.45 μs | 395.08 |   12.58 | 7800.0000 | 100.0000 |     - | 47987.01 KB |
|                            |                  |           |               |             |              |             |        |         |           |          |       |             |
| SimulateAAppWithoutSerilog | net462 LegacyJit | LegacyJit |    .NET 4.6.2 |    193.5 μs |     18.34 μs |     1.01 μs |   1.00 |    0.00 |   20.7520 |   3.4180 |     - |   128.52 KB |
| SimulateAAppWithSerilogOff | net462 LegacyJit | LegacyJit |    .NET 4.6.2 |  1,392.4 μs |    518.62 μs |    28.43 μs |   7.20 |    0.17 |  326.1719 |  54.6875 |     - |  2015.72 KB |
|  SimulateAAppWithSerilogOn | net462 LegacyJit | LegacyJit |    .NET 4.6.2 | 57,883.1 μs | 25,222.05 μs | 1,382.51 μs | 299.18 |    8.35 | 8000.0000 | 222.2222 |     - | 49552.13 KB |
|                            |                  |           |               |             |              |             |        |         |           |          |       |             |
| SimulateAAppWithoutSerilog |    net462 RyuJit |    RyuJit |    .NET 4.6.2 |    205.5 μs |     76.98 μs |     4.22 μs |   1.00 |    0.00 |   20.7520 |   3.4180 |     - |   128.52 KB |
| SimulateAAppWithSerilogOff |    net462 RyuJit |    RyuJit |    .NET 4.6.2 |  1,406.9 μs |    845.01 μs |    46.32 μs |   6.85 |    0.32 |  326.1719 |  54.6875 |     - |  2015.72 KB |
|  SimulateAAppWithSerilogOn |    net462 RyuJit |    RyuJit |    .NET 4.6.2 | 59,197.8 μs | 41,704.97 μs | 2,285.99 μs | 288.15 |   13.72 | 8000.0000 | 222.2222 |     - | 49553.01 KB |
|                            |                  |           |               |             |              |             |        |         |           |          |       |             |
| SimulateAAppWithoutSerilog | net472 LegacyJit | LegacyJit |    .NET 4.7.2 |    195.7 μs |     25.49 μs |     1.40 μs |   1.00 |    0.00 |   20.7520 |   3.4180 |     - |   128.52 KB |
| SimulateAAppWithSerilogOff | net472 LegacyJit | LegacyJit |    .NET 4.7.2 |  1,396.0 μs |    662.17 μs |    36.30 μs |   7.13 |    0.16 |  326.1719 |  54.6875 |     - |  2015.72 KB |
|  SimulateAAppWithSerilogOn | net472 LegacyJit | LegacyJit |    .NET 4.7.2 | 59,096.6 μs | 37,644.43 μs | 2,063.42 μs | 302.03 |   12.56 | 8000.0000 | 222.2222 |     - | 49552.83 KB |
|                            |                  |           |               |             |              |             |        |         |           |          |       |             |
| SimulateAAppWithoutSerilog |    net472 RyuJit |    RyuJit |    .NET 4.7.2 |    196.9 μs |     67.76 μs |     3.71 μs |   1.00 |    0.00 |   20.7520 |   3.4180 |     - |   128.52 KB |
| SimulateAAppWithSerilogOff |    net472 RyuJit |    RyuJit |    .NET 4.7.2 |  1,389.5 μs |    370.63 μs |    20.32 μs |   7.06 |    0.19 |  326.1719 |  54.6875 |     - |  2015.72 KB |
|  SimulateAAppWithSerilogOn |    net472 RyuJit |    RyuJit |    .NET 4.7.2 | 59,195.6 μs | 20,670.68 μs | 1,133.03 μs | 300.69 |    7.98 | 8000.0000 | 222.2222 |     - | 49552.76 KB |
|                            |                  |           |               |             |              |             |        |         |           |          |       |             |
| SimulateAAppWithoutSerilog |  net48 LegacyJit | LegacyJit |      .NET 4.8 |    197.6 μs |     45.31 μs |     2.48 μs |   1.00 |    0.00 |   20.7520 |   3.4180 |     - |   128.52 KB |
| SimulateAAppWithSerilogOff |  net48 LegacyJit | LegacyJit |      .NET 4.8 |  1,406.0 μs |    455.99 μs |    24.99 μs |   7.12 |    0.14 |  326.1719 |  54.6875 |     - |  2015.72 KB |
|  SimulateAAppWithSerilogOn |  net48 LegacyJit | LegacyJit |      .NET 4.8 | 57,983.8 μs | 16,289.22 μs |   892.87 μs | 293.45 |    2.96 | 8000.0000 | 222.2222 |     - | 49552.87 KB |
|                            |                  |           |               |             |              |             |        |         |           |          |       |             |
| SimulateAAppWithoutSerilog |     net48 RyuJit |    RyuJit |      .NET 4.8 |    197.8 μs |     97.06 μs |     5.32 μs |   1.00 |    0.00 |   20.7520 |   3.4180 |     - |   128.52 KB |
| SimulateAAppWithSerilogOff |     net48 RyuJit |    RyuJit |      .NET 4.8 |  1,396.1 μs |    483.33 μs |    26.49 μs |   7.07 |    0.32 |  326.1719 |  54.6875 |     - |  2015.72 KB |
|  SimulateAAppWithSerilogOn |     net48 RyuJit |    RyuJit |      .NET 4.8 | 59,416.3 μs | 18,297.30 μs | 1,002.94 μs | 300.68 |   12.96 | 8000.0000 | 222.2222 |     - | 49552.96 KB |
|                            |                  |           |               |             |              |             |        |         |           |          |       |             |
| SimulateAAppWithoutSerilog |     net50 RyuJit |    RyuJit | .NET Core 5.0 |    162.6 μs |    105.20 μs |     5.77 μs |   1.00 |    0.00 |    6.3477 |   0.7324 |     - |    39.16 KB |
| SimulateAAppWithSerilogOff |     net50 RyuJit |    RyuJit | .NET Core 5.0 |  1,433.9 μs |    608.19 μs |    33.34 μs |   8.83 |    0.47 |  439.4531 |  54.6875 |     - |  2702.13 KB |
|  SimulateAAppWithSerilogOn |     net50 RyuJit |    RyuJit | .NET Core 5.0 | 39,103.2 μs | 15,403.29 μs |   844.31 μs | 240.72 |   11.15 | 7857.1429 | 142.8571 |     - | 48456.32 KB |
