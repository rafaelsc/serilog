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
|         Method |             Job |       Jit |       Runtime |     Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |---------------- |---------- |-------------- |---------:|----------:|----------:|-------:|------:|------:|----------:|
| FormatToOutput |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 1.058 μs | 0.0709 μs | 0.1061 μs | 0.0267 |     - |     - |     168 B |
| FormatToOutput | net48 LegacyJit | LegacyJit |      .NET 4.8 | 1.229 μs | 0.0263 μs | 0.0385 μs | 0.1049 |     - |     - |     666 B |
| FormatToOutput |    net48 RyuJit |    RyuJit |      .NET 4.8 | 1.428 μs | 0.1563 μs | 0.2242 μs | 0.1049 |     - |     - |     666 B |
