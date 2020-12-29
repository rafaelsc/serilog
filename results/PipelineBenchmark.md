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
|                                                 Method |    Job |       Runtime |           Mean |         Error |         StdDev |     Ratio |  RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------------------------------------- |------- |-------------- |---------------:|--------------:|---------------:|----------:|---------:|--------:|--------:|------:|----------:|
|                                   EmitLogAIgnoredEvent | core31 | .NET Core 3.1 |      14.808 ns |     0.3580 ns |      0.5359 ns |      1.00 |     0.00 |       - |       - |     - |         - |
|                                           EmitLogEvent | core31 | .NET Core 3.1 |     620.481 ns |     8.6490 ns |     12.9454 ns |     41.96 |     1.91 |  0.0582 |       - |     - |     368 B |
|          EmitLogEventWith1Enrich0ForContext0LogContext | core31 | .NET Core 3.1 |     685.742 ns |     7.5603 ns |     11.3159 ns |     46.38 |     2.09 |  0.0620 |       - |     - |     392 B |
|          EmitLogEventWith0Enrich1ForContext0LogContext | core31 | .NET Core 3.1 |     664.181 ns |     9.0177 ns |     13.4973 ns |     44.90 |     1.56 |  0.0582 |       - |     - |     368 B |
|          EmitLogEventWith0Enrich0ForContext1LogContext | core31 | .NET Core 3.1 |   1,165.631 ns |    21.9711 ns |     32.8853 ns |     78.81 |     3.59 |  0.1507 |       - |     - |     952 B |
|          EmitLogEventWith1Enrich1ForContext1LogContext | core31 | .NET Core 3.1 |   1,317.310 ns |    15.5613 ns |     23.2915 ns |     89.05 |     3.12 |  0.1717 |       - |     - |    1088 B |
|       EmitLogEventWith10Enrich10ForContext10LogContext | core31 | .NET Core 3.1 |   6,105.005 ns |    61.5035 ns |     92.0556 ns |    412.83 |    17.08 |  0.9613 |  0.0076 |     - |    6032 B |
|    EmitLogEventWith100Enrich100ForContext100LogContext | core31 | .NET Core 3.1 |  52,200.903 ns |   468.2604 ns |    700.8701 ns |  3,529.57 |   134.97 |  8.9111 |  0.6714 |     - |   55920 B |
| EmitLogEventWith1000Enrich1000ForContext1000LogContext | core31 | .NET Core 3.1 | 539,506.478 ns | 7,366.5132 ns | 11,025.8500 ns | 36,488.77 | 1,756.00 | 86.9141 | 34.1797 |     - |  550831 B |
|                                                        |        |               |                |               |                |           |          |         |         |       |           |
|                                   EmitLogAIgnoredEvent |  net48 |      .NET 4.8 |      14.611 ns |     0.5341 ns |      0.7994 ns |      1.00 |     0.00 |       - |       - |     - |         - |
|                                           EmitLogEvent |  net48 |      .NET 4.8 |     634.235 ns |     7.8151 ns |     11.6973 ns |     43.55 |     2.71 |  0.0591 |       - |     - |     377 B |
|          EmitLogEventWith1Enrich0ForContext0LogContext |  net48 |      .NET 4.8 |     745.380 ns |    33.1301 ns |     49.5876 ns |     51.28 |     5.68 |  0.0629 |       - |     - |     401 B |
|          EmitLogEventWith0Enrich1ForContext0LogContext |  net48 |      .NET 4.8 |     730.268 ns |    35.8734 ns |     53.6936 ns |     50.01 |     2.88 |  0.0591 |       - |     - |     377 B |
|          EmitLogEventWith0Enrich0ForContext1LogContext |  net48 |      .NET 4.8 |   1,363.215 ns |    15.9707 ns |     23.9042 ns |     93.55 |     5.01 |  0.1545 |       - |     - |     979 B |
|          EmitLogEventWith1Enrich1ForContext1LogContext |  net48 |      .NET 4.8 |   1,507.087 ns |    16.7009 ns |     24.4800 ns |    103.16 |     5.74 |  0.1755 |       - |     - |    1115 B |
|       EmitLogEventWith10Enrich10ForContext10LogContext |  net48 |      .NET 4.8 |   7,116.734 ns |    67.5037 ns |     96.8118 ns |    487.02 |    28.80 |  0.9384 |       - |     - |    5929 B |
|    EmitLogEventWith100Enrich100ForContext100LogContext |  net48 |      .NET 4.8 |  64,079.637 ns |   925.4695 ns |  1,385.1992 ns |  4,398.19 |   254.27 |  8.6670 |  0.8545 |     - |   55241 B |
| EmitLogEventWith1000Enrich1000ForContext1000LogContext |  net48 |      .NET 4.8 | 688,667.135 ns | 7,631.1341 ns | 11,421.9222 ns | 47,262.15 | 2,515.27 | 86.9141 | 27.3438 |     - |  551390 B |
|                                                        |        |               |                |               |                |           |          |         |         |       |           |
|                                   EmitLogAIgnoredEvent |  net50 | .NET Core 5.0 |       7.416 ns |     0.1161 ns |      0.1738 ns |      1.00 |     0.00 |       - |       - |     - |         - |
|                                           EmitLogEvent |  net50 | .NET Core 5.0 |     365.319 ns |     4.4247 ns |      6.6226 ns |     49.28 |     1.28 |  0.0596 |       - |     - |     376 B |
|          EmitLogEventWith1Enrich0ForContext0LogContext |  net50 | .NET Core 5.0 |     421.206 ns |     3.3843 ns |      5.0655 ns |     56.82 |     1.51 |  0.0634 |       - |     - |     400 B |
|          EmitLogEventWith0Enrich1ForContext0LogContext |  net50 | .NET Core 5.0 |     409.790 ns |     4.8601 ns |      7.2743 ns |     55.28 |     1.58 |  0.0596 |       - |     - |     376 B |
|          EmitLogEventWith0Enrich0ForContext1LogContext |  net50 | .NET Core 5.0 |     805.044 ns |     9.5350 ns |     14.2716 ns |    108.62 |     3.64 |  0.1526 |       - |     - |     960 B |
|          EmitLogEventWith1Enrich1ForContext1LogContext |  net50 | .NET Core 5.0 |     901.645 ns |     8.7952 ns |     13.1643 ns |    121.63 |     2.97 |  0.1745 |       - |     - |    1096 B |
|       EmitLogEventWith10Enrich10ForContext10LogContext |  net50 | .NET Core 5.0 |   4,763.303 ns |    73.3285 ns |    109.7546 ns |    642.78 |    26.02 |  0.9613 |  0.0076 |     - |    6040 B |
|    EmitLogEventWith100Enrich100ForContext100LogContext |  net50 | .NET Core 5.0 |  41,074.712 ns |   528.7483 ns |    791.4056 ns |  5,540.54 |   140.81 |  8.9111 |  0.6714 |     - |   55928 B |
| EmitLogEventWith1000Enrich1000ForContext1000LogContext |  net50 | .NET Core 5.0 | 431,288.040 ns | 4,157.5387 ns |  6,222.8082 ns | 58,186.30 | 1,682.89 | 87.4023 | 34.6680 |     - |  550832 B |
