``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0


```
|               Method |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|             LogEmpty |  2.790 ns | 0.0326 ns | 0.0273 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| LogEmptyWithEnricher |  2.781 ns | 0.0345 ns | 0.0322 ns |  1.00 |    0.02 |      - |     - |     - |         - |
|               LogMsg |  5.261 ns | 0.1568 ns | 0.1742 ns |  1.90 |    0.07 |      - |     - |     - |         - |
|         LogMsgWithEx |  5.738 ns | 0.0113 ns | 0.0106 ns |  2.06 |    0.02 |      - |     - |     - |         - |
|           LogScalar1 |  8.790 ns | 0.0601 ns | 0.0562 ns |  3.15 |    0.04 |      - |     - |     - |         - |
|           LogScalar2 | 11.663 ns | 0.1396 ns | 0.1306 ns |  4.18 |    0.08 |      - |     - |     - |         - |
|           LogScalar3 | 12.019 ns | 0.0349 ns | 0.0326 ns |  4.31 |    0.04 |      - |     - |     - |         - |
|        LogScalarMany | 20.370 ns | 0.0912 ns | 0.0853 ns |  7.30 |    0.09 | 0.0089 |     - |     - |      28 B |
|     LogScalarStruct1 |  6.928 ns | 0.0596 ns | 0.0557 ns |  2.48 |    0.04 |      - |     - |     - |         - |
|     LogScalarStruct2 |  9.315 ns | 0.0521 ns | 0.0487 ns |  3.34 |    0.03 |      - |     - |     - |         - |
|     LogScalarStruct3 |  9.844 ns | 0.0348 ns | 0.0326 ns |  3.53 |    0.04 |      - |     - |     - |         - |
|  LogScalarStructMany | 28.259 ns | 0.3573 ns | 0.3343 ns | 10.13 |    0.14 | 0.0241 |     - |     - |      76 B |
|   LogScalarBigStruct | 20.839 ns | 0.4120 ns | 0.3854 ns |  7.48 |    0.16 |      - |     - |     - |         - |
|        LogDictionary | 11.699 ns | 0.0423 ns | 0.0375 ns |  4.19 |    0.05 | 0.0051 |     - |     - |      16 B |
|          LogSequence | 11.713 ns | 0.0613 ns | 0.0512 ns |  4.20 |    0.05 | 0.0051 |     - |     - |      16 B |
|         LogAnonymous | 12.135 ns | 0.0393 ns | 0.0349 ns |  4.35 |    0.04 | 0.0051 |     - |     - |      16 B |
|              LogMix2 | 12.227 ns | 0.2869 ns | 0.3415 ns |  4.41 |    0.14 |      - |     - |     - |         - |
|              LogMix3 | 12.675 ns | 0.0374 ns | 0.0349 ns |  4.54 |    0.04 |      - |     - |     - |         - |
|              LogMix4 | 28.788 ns | 0.1270 ns | 0.1188 ns | 10.32 |    0.12 | 0.0255 |     - |     - |      80 B |
|              LogMix5 | 35.224 ns | 0.6995 ns | 0.8327 ns | 12.70 |    0.30 | 0.0305 |     - |     - |      96 B |
|           LogMixMany | 69.626 ns | 1.8298 ns | 2.5652 ns | 25.24 |    1.11 | 0.0534 |     - |     - |     168 B |
