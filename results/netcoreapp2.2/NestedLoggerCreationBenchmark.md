``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.401
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|           Method |     Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |---------:|----------:|----------:|-------:|------:|------:|----------:|
|    ForContextInt | 87.87 ns | 0.6029 ns | 0.5344 ns | 0.0483 |     - |     - |     152 B |
| ForContextString | 55.78 ns | 1.1135 ns | 1.5242 ns | 0.0407 |     - |     - |     128 B |
|   ForContextType | 98.35 ns | 1.0234 ns | 0.8546 ns | 0.0407 |     - |     - |     128 B |
