using MvvmCross.Plugin.Messenger;

namespace XamarinMvvmCross_MeetupSample.Core.MessageObserver
{
    public interface IMessageObserver
    {
        bool IsObserving { get; }
        void Start(IMvxMessenger messenger);
        void Stop();
    }
}