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
|                       Method |             Job |       Jit |       Runtime |       Mean |      Error |     StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |---------------- |---------- |-------------- |-----------:|-----------:|-----------:|-------:|------:|------:|----------:|
|     TemplateWithNoProperties |   core31 RyuJit |    RyuJit | .NET Core 3.1 |   5.650 ns |  0.3957 ns |  0.5801 ns |      - |     - |     - |         - |
| TemplateWithVariedProperties |   core31 RyuJit |    RyuJit | .NET Core 3.1 | 360.585 ns | 16.9100 ns | 24.7864 ns | 0.0153 |     - |     - |      96 B |
|     TemplateWithNoProperties | net48 LegacyJit | LegacyJit |      .NET 4.8 |   5.854 ns |  0.2564 ns |  0.3677 ns |      - |     - |     - |         - |
| TemplateWithVariedProperties | net48 LegacyJit | LegacyJit |      .NET 4.8 | 441.629 ns | 43.9386 ns | 65.7652 ns | 0.0153 |     - |     - |      96 B |
|     TemplateWithNoProperties |    net48 RyuJit |    RyuJit |      .NET 4.8 |   7.211 ns |  0.5697 ns |  0.8351 ns |      - |     - |     - |         - |
| TemplateWithVariedProperties |    net48 RyuJit |    RyuJit |      .NET 4.8 | 409.771 ns | 10.6417 ns | 15.9280 ns | 0.0153 |     - |     - |      96 B |
