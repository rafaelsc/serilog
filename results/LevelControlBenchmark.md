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
|         Method |             Job |       Jit |       Runtime |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|--------------- |---------------- |---------- |-------------- |----------:|----------:|----------:|----------:|------:|--------:|
|            Off |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  3.699 ns | 0.9503 ns | 1.3929 ns |  2.981 ns |  1.00 |    0.00 |
| LevelSwitchOff |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  3.811 ns | 0.3173 ns | 0.4750 ns |  3.824 ns |  1.15 |    0.36 |
| MinimumLevelOn |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 11.452 ns | 0.2761 ns | 0.4047 ns | 11.353 ns |  3.40 |    0.86 |
|  LevelSwitchOn |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 13.035 ns | 1.4752 ns | 2.1157 ns | 13.565 ns |  3.86 |    0.93 |
|                |                 |           |               |           |           |           |           |       |         |
|            Off | net48 LegacyJit | LegacyJit |      .NET 4.8 |  3.933 ns | 0.3106 ns | 0.4455 ns |  3.822 ns |  1.00 |    0.00 |
| LevelSwitchOff | net48 LegacyJit | LegacyJit |      .NET 4.8 |  3.647 ns | 0.0646 ns | 0.0884 ns |  3.647 ns |  0.94 |    0.12 |
| MinimumLevelOn | net48 LegacyJit | LegacyJit |      .NET 4.8 | 14.531 ns | 2.5508 ns | 3.8180 ns | 13.357 ns |  3.77 |    1.31 |
|  LevelSwitchOn | net48 LegacyJit | LegacyJit |      .NET 4.8 | 11.723 ns | 0.6413 ns | 0.9399 ns | 11.401 ns |  3.01 |    0.28 |
|                |                 |           |               |           |           |           |           |       |         |
|            Off |    net48 RyuJit |    RyuJit |      .NET 4.8 |  3.369 ns | 0.0320 ns | 0.0470 ns |  3.366 ns |  1.00 |    0.00 |
| LevelSwitchOff |    net48 RyuJit |    RyuJit |      .NET 4.8 |  4.793 ns | 0.7618 ns | 1.1403 ns |  4.499 ns |  1.41 |    0.35 |
| MinimumLevelOn |    net48 RyuJit |    RyuJit |      .NET 4.8 | 13.108 ns | 0.7265 ns | 1.0874 ns | 13.166 ns |  3.91 |    0.30 |
|  LevelSwitchOn |    net48 RyuJit |    RyuJit |      .NET 4.8 | 11.181 ns | 0.2511 ns | 0.3680 ns | 11.109 ns |  3.32 |    0.11 |
