``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.450 (2004/?/20H1)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.401
  [Host]          : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  core31 RyuJit   : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  net48 LegacyJit : .NET Framework 4.8 (4.8.4200.0), X64 RyuJIT
  net48 RyuJit    : .NET Framework 4.8 (4.8.4200.0), X64 RyuJIT

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
|           Method |             Job |       Jit |       Runtime |      Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |---------------- |---------- |-------------- |----------:|----------:|----------:|-------:|------:|------:|----------:|
|    ForContextInt |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 101.11 ns |  2.906 ns |  4.259 ns | 0.0242 |     - |     - |     152 B |
| ForContextString |   core31 RyuJit |    RyuJit | .NET Core 3.1 |  78.41 ns |  9.751 ns | 14.595 ns | 0.0204 |     - |     - |     128 B |
|   ForContextType |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 120.40 ns |  5.308 ns |  7.613 ns | 0.0203 |     - |     - |     128 B |
|    ForContextInt | net48 LegacyJit | LegacyJit |      .NET 4.8 |  99.17 ns |  1.520 ns |  2.228 ns | 0.0242 |     - |     - |     152 B |
| ForContextString | net48 LegacyJit | LegacyJit |      .NET 4.8 |  63.69 ns |  1.324 ns |  1.982 ns | 0.0204 |     - |     - |     128 B |
|   ForContextType | net48 LegacyJit | LegacyJit |      .NET 4.8 | 150.66 ns | 13.242 ns | 19.820 ns | 0.0203 |     - |     - |     128 B |
|    ForContextInt |    net48 RyuJit |    RyuJit |      .NET 4.8 | 112.46 ns |  7.935 ns | 11.876 ns | 0.0242 |     - |     - |     152 B |
| ForContextString |    net48 RyuJit |    RyuJit |      .NET 4.8 |  63.60 ns |  1.417 ns |  2.077 ns | 0.0204 |     - |     - |     128 B |
|   ForContextType |    net48 RyuJit |    RyuJit |      .NET 4.8 | 142.45 ns | 16.288 ns | 24.379 ns | 0.0204 |     - |     - |     128 B |
