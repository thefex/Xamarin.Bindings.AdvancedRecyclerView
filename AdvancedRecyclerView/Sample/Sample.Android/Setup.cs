using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using Sample.Core;

namespace Sample.Android;

public class Setup : MvxAndroidSetup<App>
{
    protected override ILoggerProvider? CreateLogProvider() => null;

    protected override ILoggerFactory? CreateLogFactory() => null;
}
