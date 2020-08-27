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
|               Method |             Job |       Jit |       Runtime |      Mean |     Error |    StdDev | Ratio | RatioSD |
|--------------------- |---------------- |---------- |-------------- |----------:|----------:|----------:|------:|--------:|
|                 Bare |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  14.30 ns |  2.302 ns |  3.301 ns |  1.00 |    0.00 |
|         PushProperty |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 142.91 ns |  9.007 ns | 12.626 ns | 10.56 |    2.48 |
|   PushPropertyNested |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 255.26 ns | 16.369 ns | 24.500 ns | 19.04 |    5.51 |
| PushPropertyEnriched |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 274.63 ns | 23.137 ns | 32.435 ns | 19.95 |    3.33 |
|                      |                 |           |               |           |           |           |       |         |
|                 Bare | net48 LegacyJit | LegacyJit |      .NET 4.8 |  12.50 ns |  0.905 ns |  1.298 ns |  1.00 |    0.00 |
|         PushProperty | net48 LegacyJit | LegacyJit |      .NET 4.8 | 100.31 ns |  3.504 ns |  5.245 ns |  8.06 |    0.92 |
|   PushPropertyNested | net48 LegacyJit | LegacyJit |      .NET 4.8 | 270.56 ns | 27.812 ns | 41.628 ns | 22.01 |    3.51 |
| PushPropertyEnriched | net48 LegacyJit | LegacyJit |      .NET 4.8 | 206.16 ns | 11.300 ns | 16.914 ns | 16.65 |    1.18 |
|                      |                 |           |               |           |           |           |       |         |
|                 Bare |    net48 RyuJit |    RyuJit |      .NET 4.8 |  11.24 ns |  0.087 ns |  0.130 ns |  1.00 |    0.00 |
|         PushProperty |    net48 RyuJit |    RyuJit |      .NET 4.8 | 122.42 ns | 17.339 ns | 25.416 ns | 10.90 |    2.29 |
|   PushPropertyNested |    net48 RyuJit |    RyuJit |      .NET 4.8 | 227.30 ns | 17.588 ns | 25.780 ns | 20.24 |    2.39 |
| PushPropertyEnriched |    net48 RyuJit |    RyuJit |      .NET 4.8 | 193.80 ns |  7.331 ns | 10.514 ns | 17.25 |    0.91 |
