using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace Serilog.PerformanceTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<MessageTemplateParsingBenchmarkCompare>( DefaultConfig.Instance
                                                                                      .AddJob(Job.Default.WithRuntime(ClrRuntime.Net48).WithJit(Jit.LegacyJit).WithId("Net48LegacyJit"))
                                                                                      .AddJob(Job.Default.WithRuntime(ClrRuntime.Net48).WithJit(Jit.RyuJit).WithId("Net48RyuJit"))
                                                                                      .AddJob(Job.Default.WithRuntime(CoreRuntime.Core31).WithJit(Jit.RyuJit).WithId("Core31RyuJit")) );
        }
    }
}
