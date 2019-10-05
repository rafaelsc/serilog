``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.402
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|                              Method |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------------------ |---------:|----------:|----------:|------:|--------:|-------:|-------:|------:|----------:|
|               MessageTemplateParser | 3.276 us | 0.0637 us | 0.0934 us |  1.00 |    0.00 | 0.7095 | 0.0038 |     - |   4.38 KB |
|  MessageTemplateParserWithSmallMods | 3.029 us | 0.0596 us | 0.0557 us |  0.94 |    0.02 | 0.7019 | 0.0038 |     - |   4.32 KB |
|        MessageTemplateParserSpanArr | 2.471 us | 0.0478 us | 0.0470 us |  0.76 |    0.02 | 0.6943 | 0.0038 |     - |   4.27 KB |
| MessageTemplateParserMemoryIterator | 3.092 us | 0.0599 us | 0.0757 us |  0.95 |    0.03 | 0.6752 | 0.0038 |     - |   4.17 KB |
