``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0


```
|               Method |      Mean |     Error |    StdDev | Ratio | RatioSD |
|--------------------- |----------:|----------:|----------:|------:|--------:|
|                 Bare |  10.83 ns | 0.2392 ns | 0.2238 ns |  1.00 |    0.00 |
|         PushProperty |  86.09 ns | 0.5658 ns | 0.5016 ns |  7.95 |    0.19 |
|   PushPropertyNested | 162.35 ns | 1.2812 ns | 1.1984 ns | 15.00 |    0.31 |
| PushPropertyEnriched | 182.37 ns | 5.8896 ns | 7.0112 ns | 17.00 |    0.78 |
