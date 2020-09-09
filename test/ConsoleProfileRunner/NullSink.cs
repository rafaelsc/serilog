using Serilog.Core;
using Serilog.Events;

namespace ConsoleProfileRunner
{
    class NullSink : ILogEventSink
    {
        public void Emit(LogEvent logEvent)
        {
        }
    }
}
