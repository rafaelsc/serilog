``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.401
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|                       Method |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                EmptyTemplate |    58.16 ns |  0.9536 ns |  0.8453 ns |  1.00 |    0.00 | 0.0483 |     - |     - |     152 B |
|           SimpleTextTemplate |   146.39 ns |  0.6476 ns |  0.6058 ns |  2.52 |    0.04 | 0.1295 |     - |     - |     408 B |
|  SinglePropertyTokenTemplate |   286.63 ns |  2.6850 ns |  2.0963 ns |  4.93 |    0.08 | 0.1779 |     - |     - |     560 B |
|    ManyPropertyTokenTemplate |   585.01 ns |  2.4147 ns |  2.1405 ns | 10.06 |    0.14 | 0.3424 |     - |     - |    1080 B |
|       MultipleTokensTemplate | 1,198.61 ns | 23.7210 ns | 34.0199 ns | 20.49 |    0.48 | 0.5817 |     - |     - |    1832 B |
| DefaultConsoleOutputTemplate | 1,559.82 ns |  7.9583 ns |  7.4442 ns | 26.84 |    0.40 | 0.6657 |     - |     - |    2096 B |
