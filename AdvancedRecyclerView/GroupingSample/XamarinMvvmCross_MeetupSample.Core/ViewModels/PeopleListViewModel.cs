using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Core.ViewModels;
using PropertyChanged;
using XamarinMvvmCross_MeetupSample.Core.Services;
using XamarinMvvmCross_MeetupSample.Core.ViewModels;

namespace XamarinMvvmCross_MeetupSample.Core
{
    [AddINotifyPropertyChangedInterface]
    public class PeopleListViewModel : BaseMvxViewModel, IIncrementalLoading
    {
        protected readonly IList<IDisposable> DisposableItems = new List<IDisposable>();
        readonly MockedDataGenerator mockedDataGenerator = new MockedDataGenerator();
        SourceList<Person> _itemsSource = new SourceList<Person>();

        public PeopleListViewModel()
        {
        }

        public ReadOnlyObservableCollection<GroupedData> Items { get; private set; }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            BuildAndSetObservable();
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();

            var itemsToDispose = DisposableItems.ToList();
            DisposableItems.Clear();
            foreach (var disposableItem in itemsToDispose)
                disposableItem.Dispose();
        }

        public override async System.Threading.Tasks.Task Load()
        {
            await base.Load();
            _itemsSource.AddRange(mockedDataGenerator.GenerateMockedPersonList(0));

			BuildAndSetObservable();
        }

        protected virtual void BuildAndSetObservable()
        {
            if (DisposableItems.Count > 0)
                return;

            var personComparer = Comparer<Person>.Create((x, y) =>
            {
                return x.ToString().CompareTo(y.ToString());
            });

            ReadOnlyObservableCollection<GroupedData> observableCollection;
            DisposableItems.Add(_itemsSource
                                .Connect()
                                .Sort(personComparer)
                                .Distinct()
                                .GroupOn(x => x.GroupName)
                                .Transform(CreatePersonGroup)
                                .ObserveOn(SynchronizationContext.Current)
                                .Bind(out observableCollection)
                                .DisposeMany()
                                .Subscribe());

            Items = observableCollection;
        }

        private GroupedData CreatePersonGroup(IGroup<Person, string> group)
        {
            var personGroup = new GroupedData() { Key = group.GroupKey };

            ReadOnlyObservableCollection<Person> personItemsCollection;
            var subscriptions = group.List
                  .Connect()
                  .ObserveOn(SynchronizationContext.Current)
                  .Bind(out personItemsCollection)
                  .Subscribe();
            DisposableItems.Add(subscriptions);

            personGroup.Items = personItemsCollection;
            return personGroup;
        }

        public Task LoadMoreData()
        {
            _itemsSource.AddRange(mockedDataGenerator.GenerateMockedPersonList(Items.Sum(x => x.Items.Count())));
            return Task.FromResult(true);
        }

        public bool ShouldLoadMoreData()
        {
            return _itemsSource.Count < 75;
        }

        public MvxCommand<Person> PeopleTapped => new MvxExceptionGuardedCommand<Person>((x) =>
        {
            ServicesLocation.Messenger.Publish(new ToastMvxMessage(this, $"{x.ToString()} has been selected."));
        });

        public MvxCommand AddItems => new MvxExceptionGuardedCommand(() =>
        {
            _itemsSource.AddRange(mockedDataGenerator.GenerateMockedPersonList(Items.Sum(x => x.Items.Count())));
        });
    }
}
