using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using DynamicData.Binding;
using MvvmCross.Commands;
using RecordGuard.ListSample.App.Data;

namespace RecordGuard.ListSample.App.ViewModel
{
    public class MainViewModel : ListViewModel<string, AudioItem, GroupedData<DateTime, AudioItem>>
    {
        int i = 0;
        public MainViewModel()
        { 
        }
        
        public override void Prepare(string parameter)
        {
             
        }
        
        protected override Task<IEnumerable<AudioItem>> GetItems(int startIndex)
        { 

            return Task.FromResult(Enumerable.Empty<AudioItem>());
        }

        protected override IObservable<IChangeSet<GroupedData<DateTime, AudioItem>>> GetObservableChangeSet()
        {
            return ItemsSource
                .Connect()
                .Sort(SortExpressionComparer<AudioItem>.Descending(x => x.CreatedDateUtc)) 
                .GroupOn(x => x.CreatedDateUtc.Date)
                .Transform(CreateAudioItemGroup);
        }
   
        private GroupedData<DateTime, AudioItem> CreateAudioItemGroup(IGroup<AudioItem, DateTime> group)
        {
            var audioItemGroup = new GroupedData<DateTime, AudioItem>()
            {
                Key = group.GroupKey
            };

            ReadOnlyObservableCollection<AudioItem> audioItemChildCollection;
            var subscriptions = group.List
                .Connect()
                .Sort(SortExpressionComparer<AudioItem>.Descending(x => x.CreatedDateUtc).ThenByDescending(x => x.Title))
                .ObserveOn(SynchronizationContext.Current)
                .Bind(out audioItemChildCollection)
                .Subscribe();

            DisposableItems.Add(subscriptions);

            audioItemGroup.ChildItems = audioItemChildCollection;
            return audioItemGroup;
        }


        public MvxCommand Record => new MvxCommand(() => {
                i++;
                ItemsSource.Add(new AudioItem
                {
                    AudioUri = new Uri("https://www.insanelab.com"),
                    CreatedDateUtc = DateTime.UtcNow.Subtract(TimeSpan.FromHours(12 * i)),
                    Title = "Audio Test " + i
                });
            }
        );

        public MvxCommand<AudioItem> PinToDelete => new MvxCommand<AudioItem>(item => { ItemsSource.Remove(item); });
    }
}