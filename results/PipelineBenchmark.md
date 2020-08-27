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
|                                                 Method |             Job |       Jit |       Runtime |          Mean |         Error |        StdDev |        Median |    Ratio |  RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------------------------------------- |---------------- |---------- |-------------- |--------------:|--------------:|--------------:|--------------:|---------:|---------:|--------:|-------:|------:|----------:|
|                                   EmitLogAIgnoredEvent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |      15.32 ns |      0.840 ns |      1.232 ns |      15.30 ns |     1.00 |     0.00 |       - |      - |     - |         - |
|                                           EmitLogEvent |   core31 RyuJit |    RyuJit | .NET Core 3.1 |     733.10 ns |     10.277 ns |     15.065 ns |     731.58 ns |    48.13 |     3.90 |  0.0582 |      - |     - |     368 B |
|          EmitLogEventWith1Enrich0ForContext0LogContext |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   1,002.75 ns |     76.234 ns |    111.743 ns |     967.48 ns |    65.54 |     6.25 |  0.0801 |      - |     - |     504 B |
|          EmitLogEventWith0Enrich1ForContext0LogContext |   core31 RyuJit |    RyuJit | .NET Core 3.1 |     790.15 ns |     20.202 ns |     29.611 ns |     782.34 ns |    51.83 |     3.77 |  0.0763 |      - |     - |     480 B |
|          EmitLogEventWith0Enrich0ForContext1LogContext |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   1,401.11 ns |     16.661 ns |     23.894 ns |   1,395.28 ns |    91.96 |     7.09 |  0.1678 |      - |     - |    1064 B |
|          EmitLogEventWith1Enrich1ForContext1LogContext |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   1,962.37 ns |    121.452 ns |    181.784 ns |   1,950.18 ns |   128.87 |    15.42 |  0.1717 |      - |     - |    1088 B |
|       EmitLogEventWith10Enrich10ForContext10LogContext |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   7,807.42 ns |    273.012 ns |    408.631 ns |   7,769.15 ns |   512.06 |    48.32 |  0.9155 |      - |     - |    5808 B |
|    EmitLogEventWith100Enrich100ForContext100LogContext |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  15,613.01 ns |    702.654 ns |  1,029.941 ns |  15,576.50 ns | 1,025.32 |   106.12 |  1.5869 |      - |     - |    9960 B |
| EmitLogEventWith1000Enrich1000ForContext1000LogContext |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 125,866.70 ns |  2,667.892 ns |  3,740.011 ns | 125,343.97 ns | 8,220.66 |   536.25 | 14.1602 | 2.6855 |     - |   90194 B |
|                                                        |                 |           |               |               |               |               |               |          |          |         |        |       |           |
|                                   EmitLogAIgnoredEvent | net48 LegacyJit | LegacyJit |      .NET 4.8 |      19.04 ns |      1.067 ns |      1.461 ns |      18.82 ns |     1.00 |     0.00 |       - |      - |     - |         - |
|                                           EmitLogEvent | net48 LegacyJit | LegacyJit |      .NET 4.8 |     762.57 ns |     36.677 ns |     54.897 ns |     743.72 ns |    40.70 |     5.08 |  0.0591 |      - |     - |     377 B |
|          EmitLogEventWith1Enrich0ForContext0LogContext | net48 LegacyJit | LegacyJit |      .NET 4.8 |   1,071.02 ns |    132.485 ns |    185.726 ns |   1,098.80 ns |    56.77 |    12.27 |  0.0801 |      - |     - |     514 B |
|          EmitLogEventWith0Enrich1ForContext0LogContext | net48 LegacyJit | LegacyJit |      .NET 4.8 |   1,055.04 ns |     96.107 ns |    140.872 ns |   1,017.37 ns |    56.21 |     6.60 |  0.0763 |      - |     - |     489 B |
|          EmitLogEventWith0Enrich0ForContext1LogContext | net48 LegacyJit | LegacyJit |      .NET 4.8 |   1,586.24 ns |     45.569 ns |     66.795 ns |   1,581.35 ns |    83.67 |     4.95 |  0.1717 |      - |     - |    1091 B |
|          EmitLogEventWith1Enrich1ForContext1LogContext | net48 LegacyJit | LegacyJit |      .NET 4.8 |   1,808.44 ns |    201.093 ns |    300.986 ns |   1,669.28 ns |    90.00 |    11.49 |  0.1755 |      - |     - |    1115 B |
|       EmitLogEventWith10Enrich10ForContext10LogContext | net48 LegacyJit | LegacyJit |      .NET 4.8 |  10,536.22 ns |    645.448 ns |    946.090 ns |  10,848.75 ns |   563.96 |    55.48 |  0.9003 |      - |     - |    5705 B |
|    EmitLogEventWith100Enrich100ForContext100LogContext | net48 LegacyJit | LegacyJit |      .NET 4.8 |  15,074.11 ns |    551.776 ns |    825.872 ns |  14,953.89 ns |   799.15 |    60.69 |  1.5869 |      - |     - |   10014 B |
| EmitLogEventWith1000Enrich1000ForContext1000LogContext | net48 LegacyJit | LegacyJit |      .NET 4.8 | 141,722.62 ns |  3,422.484 ns |  4,684.735 ns | 140,290.32 ns | 7,486.71 |   655.27 | 14.1602 | 2.1973 |     - |   90338 B |
|                                                        |                 |           |               |               |               |               |               |          |          |         |        |       |           |
|                                   EmitLogAIgnoredEvent |    net48 RyuJit |    RyuJit |      .NET 4.8 |      18.25 ns |      2.161 ns |      3.234 ns |      17.23 ns |     1.00 |     0.00 |       - |      - |     - |         - |
|                                           EmitLogEvent |    net48 RyuJit |    RyuJit |      .NET 4.8 |     849.07 ns |     72.008 ns |    103.272 ns |     833.73 ns |    49.02 |    12.29 |  0.0591 |      - |     - |     377 B |
|          EmitLogEventWith1Enrich0ForContext0LogContext |    net48 RyuJit |    RyuJit |      .NET 4.8 |     813.22 ns |     11.124 ns |     16.305 ns |     810.91 ns |    46.20 |     8.25 |  0.0811 |      - |     - |     514 B |
|          EmitLogEventWith0Enrich1ForContext0LogContext |    net48 RyuJit |    RyuJit |      .NET 4.8 |     927.24 ns |    130.550 ns |    191.359 ns |     804.74 ns |    51.15 |     5.25 |  0.0772 |      - |     - |     489 B |
|          EmitLogEventWith0Enrich0ForContext1LogContext |    net48 RyuJit |    RyuJit |      .NET 4.8 |   1,840.85 ns |     69.085 ns |    103.404 ns |   1,869.61 ns |   104.12 |    19.98 |  0.1717 |      - |     - |    1091 B |
|          EmitLogEventWith1Enrich1ForContext1LogContext |    net48 RyuJit |    RyuJit |      .NET 4.8 |   1,857.86 ns |    198.081 ns |    284.082 ns |   1,737.52 ns |   105.13 |    18.12 |  0.1755 |      - |     - |    1115 B |
|       EmitLogEventWith10Enrich10ForContext10LogContext |    net48 RyuJit |    RyuJit |      .NET 4.8 |  10,962.43 ns |  1,075.617 ns |  1,576.626 ns |  11,096.00 ns |   631.24 |   172.95 |  0.9003 |      - |     - |    5705 B |
|    EmitLogEventWith100Enrich100ForContext100LogContext |    net48 RyuJit |    RyuJit |      .NET 4.8 |  15,500.12 ns |    647.373 ns |    968.958 ns |  15,271.66 ns |   874.93 |   162.35 |  1.5869 |      - |     - |   10014 B |
| EmitLogEventWith1000Enrich1000ForContext1000LogContext |    net48 RyuJit |    RyuJit |      .NET 4.8 | 152,170.96 ns | 11,076.402 ns | 16,235.647 ns | 144,619.53 ns | 8,531.42 | 1,052.21 | 14.1602 | 2.1973 |     - |   90338 B |
