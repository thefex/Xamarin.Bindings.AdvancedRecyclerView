using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace RecordGuard.ListSample.App.ViewModel
{
    public abstract class ListViewModel<TInitParams, TApiDataModel, TListDataModel> : MvxViewModel<TInitParams>
        where TInitParams : class
    {
        protected readonly IList<IDisposable> DisposableItems = new List<IDisposable>();
        private bool _isListLoaded;

        private ReadOnlyObservableCollection<TListDataModel> _items;

        protected ListViewModel()
        {
        }

        protected virtual int ItemsCount => Items.Count;
        protected SourceList<TApiDataModel> ItemsSource { get; } = new SourceList<TApiDataModel>();

        public ReadOnlyObservableCollection<TListDataModel> Items
        {
            get => _items;
            private set => SetProperty(ref _items, value);
        }

        public bool HasAnyItems => Items.Count > 0;
        public bool ShouldPresentEmptyView => !HasAnyItems && IsListLoaded;
     
        public bool IsListLoaded
        {
            get => _isListLoaded;
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

        public async Task Load()
        { 
            IsListLoaded = false;
            
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

        public override void ViewDestroy(bool viewFinishing = true)
        {
            base.ViewDestroy(viewFinishing);
            foreach (var item in DisposableItems)
                item?.Dispose();
            DisposableItems.Clear();
        }
    }
}