``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.401
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|       Method |     Mean |     Error |    StdDev | Ratio | RatioSD |
|------------- |---------:|----------:|----------:|------:|--------:|
|   RootLogger | 11.30 ns | 0.2444 ns | 0.2510 ns |  1.00 |    0.00 |
| NestedLogger | 52.13 ns | 1.0718 ns | 1.3936 ns |  4.60 |    0.17 |
