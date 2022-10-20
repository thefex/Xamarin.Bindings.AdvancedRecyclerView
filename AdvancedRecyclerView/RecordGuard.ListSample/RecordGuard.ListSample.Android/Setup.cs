using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using RecordGuard.ListSample.App;
using Serilog;
using Serilog.Extensions.Logging;

namespace RecordGuard.ListSample.Android
{
    public class Setup : MvxAndroidSetup<AppSetup>
    {
        public Setup()
        {

        }

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel
                .Verbose()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}