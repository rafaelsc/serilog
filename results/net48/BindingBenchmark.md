``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0


```
|   Method |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------- |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
| BindZero |  76.36 ns | 0.4639 ns | 0.4339 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|  BindOne | 175.11 ns | 0.6431 ns | 0.5021 ns |  2.30 |    0.02 | 0.0267 |     - |     - |      84 B |
| BindFive | 493.30 ns | 5.5256 ns | 5.1687 ns |  6.46 |    0.08 | 0.0725 |     - |     - |     228 B |
