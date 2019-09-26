``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0


```
|                       Method |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                EmptyTemplate |    52.41 ns | 0.1970 ns | 0.1843 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      80 B |
|           SimpleTextTemplate |   179.45 ns | 1.7240 ns | 1.6126 ns |  3.42 |    0.03 | 0.0479 |     - |     - |     252 B |
|  SinglePropertyTokenTemplate |   307.01 ns | 1.9500 ns | 1.7286 ns |  5.86 |    0.05 | 0.0591 |     - |     - |     312 B |
|    ManyPropertyTokenTemplate |   646.69 ns | 6.0752 ns | 5.6827 ns | 12.34 |    0.13 | 0.1230 |     - |     - |     649 B |
|       MultipleTokensTemplate | 1,294.01 ns | 6.6459 ns | 5.8914 ns | 24.69 |    0.13 | 0.2213 |     - |     - |    1166 B |
| DefaultConsoleOutputTemplate | 1,863.49 ns | 5.5981 ns | 4.9626 ns | 35.55 |    0.18 | 0.2728 |     - |     - |    1430 B |
