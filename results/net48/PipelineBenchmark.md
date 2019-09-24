``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4010.0


```
|               Method |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
| EmitLogAIgnoredEvent |     9.824 ns |  0.0524 ns |  0.0464 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|         EmitLogEvent | 1,729.193 ns | 32.4376 ns | 28.7551 ns | 176.03 |    3.14 | 0.0687 |     - |     - |     216 B |
