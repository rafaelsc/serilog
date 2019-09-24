``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.401
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|               Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|             LogEmpty |  3.229 ns | 0.0957 ns | 0.0983 ns |  3.170 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher |  3.075 ns | 0.0325 ns | 0.0304 ns |  3.089 ns |  0.95 |    0.03 |      - |     - |     - |         - |
|               LogMsg |  5.252 ns | 0.0237 ns | 0.0222 ns |  5.255 ns |  1.62 |    0.05 |      - |     - |     - |         - |
|         LogMsgWithEx |  5.372 ns | 0.1362 ns | 0.1996 ns |  5.260 ns |  1.69 |    0.07 |      - |     - |     - |         - |
|           LogScalar1 |  6.363 ns | 0.0826 ns | 0.0773 ns |  6.327 ns |  1.97 |    0.06 |      - |     - |     - |         - |
|           LogScalar2 | 12.711 ns | 0.2958 ns | 0.3846 ns | 12.468 ns |  3.98 |    0.20 |      - |     - |     - |         - |
|           LogScalar3 | 16.373 ns | 0.0899 ns | 0.0841 ns | 16.352 ns |  5.06 |    0.16 |      - |     - |     - |         - |
|        LogScalarMany | 17.395 ns | 0.1602 ns | 0.1498 ns | 17.453 ns |  5.38 |    0.18 | 0.0178 |     - |     - |      56 B |
|     LogScalarStruct1 |  6.838 ns | 0.2441 ns | 0.2283 ns |  6.716 ns |  2.11 |    0.05 |      - |     - |     - |         - |
|     LogScalarStruct2 |  6.109 ns | 0.0619 ns | 0.0579 ns |  6.131 ns |  1.89 |    0.06 |      - |     - |     - |         - |
|     LogScalarStruct3 |  9.571 ns | 0.0355 ns | 0.0314 ns |  9.571 ns |  2.95 |    0.09 |      - |     - |     - |         - |
|  LogScalarStructMany | 27.584 ns | 0.5690 ns | 0.7398 ns | 27.168 ns |  8.56 |    0.25 | 0.0483 |     - |     - |     152 B |
|   LogScalarBigStruct | 22.571 ns | 0.0598 ns | 0.0559 ns | 22.579 ns |  6.98 |    0.22 |      - |     - |     - |         - |
|        LogDictionary |  9.538 ns | 0.2219 ns | 0.3646 ns |  9.311 ns |  2.97 |    0.10 | 0.0102 |     - |     - |      32 B |
|          LogSequence |  9.299 ns | 0.0367 ns | 0.0343 ns |  9.310 ns |  2.87 |    0.09 | 0.0102 |     - |     - |      32 B |
|         LogAnonymous |  9.248 ns | 0.0607 ns | 0.0538 ns |  9.273 ns |  2.85 |    0.09 | 0.0102 |     - |     - |      32 B |
|              LogMix2 | 12.497 ns | 0.3003 ns | 0.3213 ns | 12.345 ns |  3.88 |    0.13 |      - |     - |     - |         - |
|              LogMix3 | 17.372 ns | 0.1299 ns | 0.1151 ns | 17.389 ns |  5.36 |    0.17 |      - |     - |     - |         - |
|              LogMix4 | 30.547 ns | 0.6255 ns | 0.8351 ns | 30.018 ns |  9.46 |    0.31 | 0.0432 |     - |     - |     136 B |
|              LogMix5 | 31.026 ns | 0.2617 ns | 0.2448 ns | 31.083 ns |  9.59 |    0.30 | 0.0533 |     - |     - |     168 B |
|           LogMixMany | 62.913 ns | 0.4066 ns | 0.3803 ns | 62.959 ns | 19.45 |    0.60 | 0.0889 |     - |     - |     280 B |
