``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0


```
|                       Method |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                EmptyTemplate |    63.92 ns |  0.7270 ns |  0.6800 ns |  1.00 |    0.00 | 0.0254 |     - |     - |      80 B |
|           SimpleTextTemplate |   173.94 ns |  1.1248 ns |  0.9392 ns |  2.72 |    0.03 | 0.0775 |     - |     - |     244 B |
|  SinglePropertyTokenTemplate |   422.23 ns |  4.1092 ns |  3.8438 ns |  6.61 |    0.07 | 0.0963 |     - |     - |     304 B |
|    ManyPropertyTokenTemplate |   951.58 ns |  3.1268 ns |  2.4412 ns | 14.84 |    0.16 | 0.2117 |     - |     - |     669 B |
|       MultipleTokensTemplate | 1,924.79 ns | 12.5831 ns | 11.1546 ns | 30.09 |    0.40 | 0.3624 |     - |     - |    1146 B |
| DefaultConsoleOutputTemplate | 2,777.76 ns | 10.7442 ns | 10.0502 ns | 43.46 |    0.47 | 0.4272 |     - |     - |    1350 B |
