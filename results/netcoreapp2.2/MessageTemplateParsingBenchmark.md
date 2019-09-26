``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.402
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|                       Method |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                EmptyTemplate |    50.52 ns |  0.4554 ns |  0.4260 ns |  1.00 |    0.00 | 0.0241 |     - |     - |     152 B |
|           SimpleTextTemplate |   127.61 ns |  0.8965 ns |  0.8386 ns |  2.53 |    0.03 | 0.0646 |     - |     - |     408 B |
|  SinglePropertyTokenTemplate |   261.93 ns |  1.0344 ns |  0.9676 ns |  5.18 |    0.04 | 0.0887 |     - |     - |     560 B |
|    ManyPropertyTokenTemplate |   507.84 ns |  5.3679 ns |  5.0211 ns | 10.05 |    0.12 | 0.1707 |     - |     - |    1080 B |
|       MultipleTokensTemplate | 1,007.00 ns |  5.9273 ns |  5.5444 ns | 19.93 |    0.20 | 0.2899 |     - |     - |    1832 B |
| DefaultConsoleOutputTemplate | 1,336.16 ns | 11.4630 ns | 10.7225 ns | 26.45 |    0.33 | 0.3319 |     - |     - |    2096 B |
