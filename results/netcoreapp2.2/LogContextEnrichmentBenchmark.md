``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.401
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|               Method |      Mean |     Error |    StdDev | Ratio | RatioSD |
|--------------------- |----------:|----------:|----------:|------:|--------:|
|                 Bare |  11.04 ns | 0.0342 ns | 0.0303 ns |  1.00 |    0.00 |
|         PushProperty | 102.66 ns | 0.4538 ns | 0.4023 ns |  9.30 |    0.05 |
|   PushPropertyNested | 210.15 ns | 4.1230 ns | 5.2143 ns | 19.19 |    0.54 |
| PushPropertyEnriched | 180.87 ns | 0.7695 ns | 0.7198 ns | 16.38 |    0.09 |
