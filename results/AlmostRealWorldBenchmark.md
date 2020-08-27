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
|                     Method |             Job |       Jit |       Runtime |        Mean |        Error |      StdDev |  Ratio | RatioSD |     Gen 0 |    Gen 1 | Gen 2 |   Allocated |
|--------------------------- |---------------- |---------- |-------------- |------------:|-------------:|------------:|-------:|--------:|----------:|---------:|------:|------------:|
| SimulateAAppWithoutSerilog |   core31 RyuJit |    RyuJit | .NET Core 3.1 |    146.2 μs |     166.2 μs |     9.11 μs |   1.00 |    0.00 |    6.3477 |   0.7324 |     - |    39.16 KB |
| SimulateAAppWithSerilogOff |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  2,010.3 μs |     214.4 μs |    11.75 μs |  13.79 |    0.89 |  437.5000 |  54.6875 |     - |  2702.13 KB |
|  SimulateAAppWithSerilogOn |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 60,894.3 μs |  19,341.2 μs | 1,060.16 μs | 417.34 |   21.70 | 6000.0000 | 111.1111 |     - | 37205.15 KB |
|                            |                 |           |               |             |              |             |        |         |           |          |       |             |
| SimulateAAppWithoutSerilog | net48 LegacyJit | LegacyJit |      .NET 4.8 |    263.6 μs |     219.2 μs |    12.01 μs |   1.00 |    0.00 |   20.7520 |   3.4180 |     - |   128.52 KB |
| SimulateAAppWithSerilogOff | net48 LegacyJit | LegacyJit |      .NET 4.8 |  1,799.3 μs |   1,105.3 μs |    60.59 μs |   6.84 |    0.48 |  326.1719 |  54.6875 |     - |  2015.72 KB |
|  SimulateAAppWithSerilogOn | net48 LegacyJit | LegacyJit |      .NET 4.8 | 68,769.7 μs |  39,073.7 μs | 2,141.76 μs | 261.45 |   20.26 | 6250.0000 | 125.0000 |     - | 38738.83 KB |
|                            |                 |           |               |             |              |             |        |         |           |          |       |             |
| SimulateAAppWithoutSerilog |    net48 RyuJit |    RyuJit |      .NET 4.8 |    232.0 μs |     141.2 μs |     7.74 μs |   1.00 |    0.00 |   20.7520 |   3.4180 |     - |   128.52 KB |
| SimulateAAppWithSerilogOff |    net48 RyuJit |    RyuJit |      .NET 4.8 |  2,540.6 μs |   1,338.9 μs |    73.39 μs |  10.96 |    0.30 |  326.1719 |  54.6875 |     - |  2015.72 KB |
|  SimulateAAppWithSerilogOn |    net48 RyuJit |    RyuJit |      .NET 4.8 | 97,483.4 μs | 106,719.7 μs | 5,849.67 μs | 420.49 |   28.12 | 6200.0000 | 200.0000 |     - | 38740.02 KB |
