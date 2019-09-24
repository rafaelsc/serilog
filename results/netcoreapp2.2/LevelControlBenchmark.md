``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.401
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|         Method |      Mean |     Error |    StdDev | Ratio | RatioSD |
|--------------- |----------:|----------:|----------:|------:|--------:|
|            Off |  2.680 ns | 0.0836 ns | 0.0963 ns |  1.00 |    0.00 |
| LevelSwitchOff |  3.170 ns | 0.0234 ns | 0.0219 ns |  1.18 |    0.04 |
| MinimumLevelOn | 11.495 ns | 0.0894 ns | 0.0837 ns |  4.27 |    0.16 |
|  LevelSwitchOn | 10.866 ns | 0.2478 ns | 0.2755 ns |  4.06 |    0.21 |
