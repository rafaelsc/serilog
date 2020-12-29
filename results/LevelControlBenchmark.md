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
|         Method |    Job |       Runtime |     Mean |     Error |    StdDev | Ratio | RatioSD |
|--------------- |------- |-------------- |---------:|----------:|----------:|------:|--------:|
|            Off | core31 | .NET Core 3.1 | 1.560 ns | 0.0865 ns | 0.1295 ns |  1.00 |    0.00 |
| LevelSwitchOff | core31 | .NET Core 3.1 | 1.697 ns | 0.0285 ns | 0.0426 ns |  1.10 |    0.10 |
| MinimumLevelOn | core31 | .NET Core 3.1 | 7.877 ns | 0.0942 ns | 0.1410 ns |  5.08 |    0.43 |
|  LevelSwitchOn | core31 | .NET Core 3.1 | 8.244 ns | 0.1283 ns | 0.1920 ns |  5.32 |    0.42 |
|                |        |               |          |           |           |       |         |
|            Off |  net48 |      .NET 4.8 | 1.419 ns | 0.0294 ns | 0.0440 ns |  1.00 |    0.00 |
| LevelSwitchOff |  net48 |      .NET 4.8 | 1.374 ns | 0.0871 ns | 0.1304 ns |  0.97 |    0.10 |
| MinimumLevelOn |  net48 |      .NET 4.8 | 8.337 ns | 0.1302 ns | 0.1949 ns |  5.88 |    0.23 |
|  LevelSwitchOn |  net48 |      .NET 4.8 | 8.330 ns | 0.1328 ns | 0.1987 ns |  5.88 |    0.24 |
|                |        |               |          |           |           |       |         |
|            Off |  net50 | .NET Core 5.0 | 1.527 ns | 0.0365 ns | 0.0546 ns |  1.00 |    0.00 |
| LevelSwitchOff |  net50 | .NET Core 5.0 | 1.644 ns | 0.0351 ns | 0.0525 ns |  1.08 |    0.05 |
| MinimumLevelOn |  net50 | .NET Core 5.0 | 7.781 ns | 0.1097 ns | 0.1607 ns |  5.10 |    0.21 |
|  LevelSwitchOn |  net50 | .NET Core 5.0 | 8.155 ns | 0.1483 ns | 0.2220 ns |  5.35 |    0.28 |
