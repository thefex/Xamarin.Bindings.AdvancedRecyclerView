using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RecordGuard.ListSample.Data;

namespace RecordGuard.ListSample.ViewModel
{
    public class MainViewModel : AbstractBaseListViewModel<string, AudioItem, GroupedData<DateTime, SelectableItem<AudioItem>>>
    {
        public MainViewModel()
        { 
        }
 
        protected override Task<IEnumerable<AudioItem>> GetItems(int startIndex)
        {
            if (startIndex == 0)
            {
                var audioItems = new List<AudioItem>();

                for (var i = 0; i < 0; ++i)
                    audioItems.Add(new AudioItem
                    {
                        AudioUri = new Uri("http://www.onet.pl"),
                        CreatedDateUtc = DateTime.UtcNow.Subtract(TimeSpan.FromHours(12 * i)),
                        Title = "Audio Test " + i
                    });

                return Task.FromResult(audioItems as IEnumerable<AudioItem>);
            }

            return Task.FromResult(Enumerable.Empty<AudioItem>());
        }

        protected override IObservable<IChangeSet<GroupedData<DateTime, SelectableItem<AudioItem>>>> GetObservableChangeSet()
        {
            return ItemsSource
                .Connect()
                .Transform(x => new SelectableItem<AudioItem>() { Item = x})

                .Sort(SortExpressionComparer<SelectableItem<AudioItem>>.Descending(x => x.Item.CreatedDateUtc)) 
                .GroupOn(x => x.Item.CreatedDateUtc.Date)
                .Transform(CreateAudioItemGroup);
        }
   
        private GroupedData<DateTime, AudioItem> CreateAudioItemGroup(IGroup<SelectableItem<AudioItem>, DateTime> group)
        {
            var audioItemGroup = new GroupedData<DateTime, SelectableItem<AudioItem>>()
            {
                Key = group.GroupKey
            };

            ReadOnlyObservableCollection<SelectableItem<AudioItem>> audioItemChildCollection;
            var subscriptions = group.List
                .Connect()
                .Sort(SortExpressionComparer<SelectableItem<AudioItem>>.Descending(x => x.Item.CreatedDateUtc).ThenByDescending(x => x.Item.Title))
                .ObserveOn(SynchronizationContext.Current)
                .Bind(out audioItemChildCollection)
                .Subscribe();

            DisposableItems.Add(subscriptions);

            audioItemGroup.ChildItems = audioItemChildCollection;
            return audioItemGroup;
        }

        
        public MvxCommand Record => new MvxCommand(() => 
                System.Diagnostics.Debug.WriteLine("Record")            
            );
    }
    
     public abstract class AbstractBaseListViewModel<TInitParams, TApiDataModel, TListDataModel> : MvxViewModel<TInitParams>
        where TInitParams : class
    {
        protected readonly IList<IDisposable> DisposableItems = new List<IDisposable>();
        private bool _firstLoadingViewEnabled = true;
        private bool _isDataFetchInProgress;
        private bool _isListLoaded;
        private bool _isRefreshingInProgress;

        private ReadOnlyObservableCollection<TListDataModel> _items;

        private bool isViewModelLoaded;


        protected AbstractBaseListViewModel()
        {
        }

        protected virtual int ItemsCount => Items.Count;
        protected SourceList<TApiDataModel> ItemsSource { get; } = new SourceList<TApiDataModel>();

        public ReadOnlyObservableCollection<TListDataModel> Items
        {
            get { return _items; }
            private set { SetProperty(ref _items, value); }
        }

        public bool HasAnyItems => Items.Count > 0;
        public bool ShouldPresentEmptyView => !HasAnyItems && IsListLoaded;
     
        public bool IsListLoaded
        {
            get { return _isListLoaded; }
            set
            {
                SetProperty(ref _isListLoaded, value);
                RaisePropertyChanged(() => ShouldPresentEmptyView);
            }
        }     

        public virtual MvxCommand<TApiDataModel> ItemTapped { get; } = new MvxCommand<TApiDataModel>(itemModel => { });

        public virtual async Task LoadMoreItems()
        {
            foreach (var item in await LoadItems().ConfigureAwait(false))
                ItemsSource.Add(item);
        }

        public async Task<IEnumerable<TApiDataModel>> LoadItems()
        {
            try
            {
                var items = await GetItems(ItemsCount).ConfigureAwait(false);
                return items;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
                return Enumerable.Empty<TApiDataModel>();
            }
        }

        protected abstract Task<IEnumerable<TApiDataModel>> GetItems(int startIndex);

        protected virtual void BuildAndSetObservable()
        {
            if (DisposableItems.Count > 0)
                return;
            ReadOnlyObservableCollection<TListDataModel> observableCollection;
            DisposableItems.Add(GetObservableChangeSet()
                .ObserveOn(SynchronizationContext.Current)
                .Bind(out observableCollection)
                .DisposeMany()
                .Subscribe());
            DisposableItems.Add(
                ItemsSource
                    .CountChanged
                    .ObserveOn(SynchronizationContext.Current)
                    .Subscribe(count =>
                        {
                            RaisePropertyChanged(() => HasAnyItems);
                            RaisePropertyChanged(() => ShouldPresentEmptyView);
                        }
                    ));
            Items = observableCollection;
        }

        protected abstract IObservable<IChangeSet<TListDataModel>> GetObservableChangeSet();

        public override async Task Load()
        {
            if (isViewModelLoaded)
                return;
            isViewModelLoaded = true;
            IsListLoaded = false;
            await base.Load();
            BuildAndSetObservable();
            foreach (var item in await LoadItems().ConfigureAwait(false))
                ItemsSource.Add(item);
            IsListLoaded = true;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            BuildAndSetObservable();

        }

        public override void Dispose()
        {
            base.Dispose();
            foreach (var item in DisposableItems)
                item?.Dispose();
            DisposableItems.Clear();
        }
    }
}