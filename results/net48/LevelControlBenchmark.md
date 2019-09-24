``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0


```
|         Method |      Mean |     Error |    StdDev | Ratio | RatioSD |
|--------------- |----------:|----------:|----------:|------:|--------:|
|            Off |  3.426 ns | 0.0969 ns | 0.1077 ns |  1.00 |    0.00 |
| LevelSwitchOff |  4.277 ns | 0.0196 ns | 0.0183 ns |  1.25 |    0.04 |
| MinimumLevelOn | 10.607 ns | 0.2295 ns | 0.2147 ns |  3.09 |    0.11 |
|  LevelSwitchOn | 10.826 ns | 0.0731 ns | 0.0610 ns |  3.14 |    0.11 |
