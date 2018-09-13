using MvvmCross.Plugin.Messenger;

namespace XamarinMvvmCross_MeetupSample.Core.MessageObserver
{
    public abstract class MessageObserver<TMessage> : IMessageObserver where TMessage : MvxMessage
    {
        private readonly bool _shouldSubscribeOnThreadPool;
        private MvxSubscriptionToken subscriptionToken;

        protected MessageObserver(bool shouldSubscribeOnThreadPool = false)
        {
            _shouldSubscribeOnThreadPool = shouldSubscribeOnThreadPool;
        }


        public void Start(IMvxMessenger messenger)
        {
            IsObserving = true;
            subscriptionToken = _shouldSubscribeOnThreadPool
                ? messenger.SubscribeOnThreadPoolThread<TMessage>(HandleMessage)
                : messenger.SubscribeOnMainThread<TMessage>(HandleMessage);
        }

        public void Stop()
        {
            IsObserving = false;
            subscriptionToken?.Dispose();
        }

        public bool IsObserving { get; private set; }

        private void HandleMessage(TMessage messageToHandle)
        {
            if (ShouldHandleMessage(messageToHandle))
                OnMessageArrived(messageToHandle);
        }

        protected abstract void OnMessageArrived(TMessage messageToHandle);

        protected virtual bool ShouldHandleMessage(TMessage message)
            => true;

        public virtual void Dispose()
        {
            Stop();
        }
    }
}
