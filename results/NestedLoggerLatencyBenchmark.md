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
|       Method |    Job |       Runtime |      Mean |     Error |    StdDev | Ratio | RatioSD |
|------------- |------- |-------------- |----------:|----------:|----------:|------:|--------:|
|   RootLogger | core31 | .NET Core 3.1 |  7.587 ns | 0.1126 ns | 0.1686 ns |  1.00 |    0.00 |
| NestedLogger | core31 | .NET Core 3.1 | 35.543 ns | 1.2158 ns | 1.7821 ns |  4.69 |    0.25 |
|              |        |               |           |           |           |       |         |
|   RootLogger |  net48 |      .NET 4.8 |  8.302 ns | 0.1251 ns | 0.1872 ns |  1.00 |    0.00 |
| NestedLogger |  net48 |      .NET 4.8 | 42.649 ns | 1.0254 ns | 1.5031 ns |  5.14 |    0.22 |
|              |        |               |           |           |           |       |         |
|   RootLogger |  net50 | .NET Core 5.0 |  7.378 ns | 0.2404 ns | 0.3598 ns |  1.00 |    0.00 |
| NestedLogger |  net50 | .NET Core 5.0 | 31.434 ns | 0.9349 ns | 1.3993 ns |  4.27 |    0.26 |
