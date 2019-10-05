``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4018.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.8.4018.0


```
|                              Method |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|               MessageTemplateParser | 3.472 us | 0.0368 us | 0.0307 us |  1.00 |    0.00 | 0.5531 |     - |     - |   2.85 KB |
|  MessageTemplateParserWithSmallMods | 3.147 us | 0.0184 us | 0.0163 us |  0.91 |    0.01 | 0.5493 |     - |     - |   2.82 KB |
|        MessageTemplateParserSpanArr | 4.253 us | 0.0842 us | 0.1311 us |  1.22 |    0.05 | 0.5188 |     - |     - |   2.68 KB |
| MessageTemplateParserMemoryIterator | 4.757 us | 0.0769 us | 0.0720 us |  1.37 |    0.02 | 0.5264 |     - |     - |   2.71 KB |
