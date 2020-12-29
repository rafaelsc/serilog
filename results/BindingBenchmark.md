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
|   Method |    Job |       Runtime |      Mean |    Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------- |------- |-------------- |----------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
| BindZero | core31 | .NET Core 3.1 |  42.80 ns | 0.596 ns |  0.892 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|  BindOne | core31 | .NET Core 3.1 | 162.29 ns | 2.865 ns |  4.288 ns |  3.79 |    0.15 | 0.0229 |     - |     - |     144 B |
| BindFive | core31 | .NET Core 3.1 | 455.93 ns | 7.934 ns | 11.875 ns | 10.65 |    0.25 | 0.0687 |     - |     - |     432 B |
|          |        |               |           |          |           |       |         |        |       |       |           |
| BindZero |  net48 |      .NET 4.8 |  50.76 ns | 0.484 ns |  0.725 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|  BindOne |  net48 |      .NET 4.8 | 168.82 ns | 1.991 ns |  2.980 ns |  3.33 |    0.08 | 0.0253 |     - |     - |     160 B |
| BindFive |  net48 |      .NET 4.8 | 505.05 ns | 7.992 ns | 11.962 ns |  9.95 |    0.30 | 0.0706 |     - |     - |     449 B |
|          |        |               |           |          |           |       |         |        |       |       |           |
| BindZero |  net50 | .NET Core 5.0 |  34.00 ns | 0.501 ns |  0.749 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|  BindOne |  net50 | .NET Core 5.0 | 130.79 ns | 1.853 ns |  2.774 ns |  3.85 |    0.14 | 0.0229 |     - |     - |     144 B |
| BindFive |  net50 | .NET Core 5.0 | 377.19 ns | 6.529 ns |  9.773 ns | 11.10 |    0.37 | 0.0687 |     - |     - |     432 B |
