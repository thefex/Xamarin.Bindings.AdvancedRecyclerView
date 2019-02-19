using MvvmCross;
using MvvmCross.Plugin.Messenger;

namespace XamarinMvvmCross_MeetupSample.Core.Services
{
    public static class ServicesLocation
    {
        public static IMvxMessenger Messenger => Mvx.Resolve<IMvxMessenger>();

		public static ExceptionGuardService ExceptionGuard => Mvx.Resolve<ExceptionGuardService>();
    }
}