using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Plugin.Messenger;

namespace XamarinMvvmCross_MeetupSample.Core.MessageObserver
{
    public class MessageObserversController : IDisposable
    {
        private readonly IList<IMessageObserver> _messageObservers;
        private readonly IMvxMessenger _messenger;

        public MessageObserversController(IMvxMessenger messenger)
        {
            _messenger = messenger;
            _messageObservers = new List<IMessageObserver>();
        }

        public int Count => _messageObservers.Count;

        public virtual void Dispose()
        {
            StopObserving();
        }

        public MessageObserversController AddObservers(IMessageObserver messageObserver)
        {
            _messageObservers.Add(messageObserver);
            return this;
        }

        public MessageObserversController AddObservers(IEnumerable<IMessageObserver> messageObservers)
        {
            foreach (var observer in messageObservers)
                AddObservers(observer);
            return this;
        }

        public MessageObserversController RemoveObserver(IMessageObserver messageObserver)
        {
            _messageObservers.Remove(messageObserver);
            return this;
        }

        public virtual void StartObserving()
        {
            foreach (var observer in _messageObservers.Where(x => !x.IsObserving).ToList())
                observer.Start(_messenger);
        }

        public virtual void StopObserving()
        {
            foreach (var observer in _messageObservers.Where(x => x.IsObserving).ToList())
                observer.Stop();
        }
    }
}