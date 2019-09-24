``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.401
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|   Method |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------- |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
| BindZero |  62.28 ns | 1.6499 ns | 1.9641 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|  BindOne | 196.18 ns | 0.9418 ns | 0.7864 ns |  3.13 |    0.10 | 0.0455 |     - |     - |     144 B |
| BindFive | 509.94 ns | 2.8304 ns | 2.6476 ns |  8.14 |    0.28 | 0.1364 |     - |     - |     432 B |
