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
|               Method |    Job |       Runtime |       Mean |     Error |    StdDev | Ratio | RatioSD |
|--------------------- |------- |-------------- |-----------:|----------:|----------:|------:|--------:|
|                 Bare | core31 | .NET Core 3.1 |   7.950 ns | 0.1342 ns | 0.2009 ns |  1.00 |    0.00 |
|         PushProperty | core31 | .NET Core 3.1 |  91.979 ns | 1.3021 ns | 1.9489 ns | 11.58 |    0.36 |
|   PushPropertyNested | core31 | .NET Core 3.1 | 189.213 ns | 2.6465 ns | 3.9611 ns | 23.82 |    0.84 |
| PushPropertyEnriched | core31 | .NET Core 3.1 | 163.028 ns | 2.3667 ns | 3.5424 ns | 20.52 |    0.69 |
|                      |        |               |            |           |           |       |         |
|                 Bare |  net48 |      .NET 4.8 |   7.581 ns | 0.1305 ns | 0.1953 ns |  1.00 |    0.00 |
|         PushProperty |  net48 |      .NET 4.8 |  77.405 ns | 1.0883 ns | 1.6289 ns | 10.22 |    0.37 |
|   PushPropertyNested |  net48 |      .NET 4.8 | 150.758 ns | 2.2047 ns | 3.2998 ns | 19.91 |    0.86 |
| PushPropertyEnriched |  net48 |      .NET 4.8 | 156.356 ns | 4.3121 ns | 6.3207 ns | 20.62 |    1.01 |
|                      |        |               |            |           |           |       |         |
|                 Bare |  net50 | .NET Core 5.0 |   7.452 ns | 0.0823 ns | 0.1206 ns |  1.00 |    0.00 |
|         PushProperty |  net50 | .NET Core 5.0 |  89.316 ns | 0.9959 ns | 1.4906 ns | 11.98 |    0.28 |
|   PushPropertyNested |  net50 | .NET Core 5.0 | 178.639 ns | 2.0150 ns | 3.0159 ns | 23.97 |    0.57 |
| PushPropertyEnriched |  net50 | .NET Core 5.0 | 149.010 ns | 1.8473 ns | 2.7649 ns | 20.01 |    0.64 |
