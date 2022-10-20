using Android.Content;
using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.ViewModels;
using Serilog;
using Serilog.Extensions.Logging;

namespace XamarinMvvmCross_MeetupSample.Droid
{
    public class Setup : MvxAndroidSetup<Core.App>
	{
        public Setup()
        {
        }
          
		protected override IMvxAndroidViewPresenter CreateViewPresenter()
		{
			return new ApplicationPresenter(AndroidViewAssemblies);
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
