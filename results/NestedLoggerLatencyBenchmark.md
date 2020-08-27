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
|       Method |             Job |       Jit |       Runtime |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |
|------------- |---------------- |---------- |-------------- |---------:|---------:|---------:|---------:|------:|--------:|
|   RootLogger |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 11.46 ns | 0.558 ns | 0.835 ns | 11.45 ns |  1.00 |    0.00 |
| NestedLogger |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 38.51 ns | 0.335 ns | 0.502 ns | 38.34 ns |  3.38 |    0.23 |
|              |                 |           |               |          |          |          |          |       |         |
|   RootLogger | net48 LegacyJit | LegacyJit |      .NET 4.8 | 11.43 ns | 0.069 ns | 0.100 ns | 11.43 ns |  1.00 |    0.00 |
| NestedLogger | net48 LegacyJit | LegacyJit |      .NET 4.8 | 45.73 ns | 1.396 ns | 2.002 ns | 45.23 ns |  4.00 |    0.19 |
|              |                 |           |               |          |          |          |          |       |         |
|   RootLogger |    net48 RyuJit |    RyuJit |      .NET 4.8 | 12.99 ns | 1.823 ns | 2.672 ns | 11.47 ns |  1.00 |    0.00 |
| NestedLogger |    net48 RyuJit |    RyuJit |      .NET 4.8 | 60.03 ns | 4.368 ns | 6.124 ns | 59.38 ns |  4.90 |    0.96 |
