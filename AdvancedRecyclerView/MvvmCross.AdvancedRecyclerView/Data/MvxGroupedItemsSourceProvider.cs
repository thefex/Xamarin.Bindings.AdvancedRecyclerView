using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using MvvmCross.WeakSubscription;

namespace MvvmCross.AdvancedRecyclerView.Data
{
    internal class MvxGroupedItemsSourceProvider
    {
        private readonly ObservableCollection<object> _observableItemsSource = new ObservableCollection<object>();
        private readonly Dictionary<MvxGroupedData, IDisposable> _groupedDataDisposables = new Dictionary<MvxGroupedData, IDisposable>();

        public ObservableCollection<object> Source => _observableItemsSource;

        private MvxExpandableDataConverter groupedDataConverter;
        INotifyCollectionChanged oldGroupedDataSource;

        void ObservableGroups_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
			switch (args.Action)
			{
				case NotifyCollectionChangedAction.Reset:
					var enumerableGroupedItems = sender as IEnumerable ?? Enumerable.Empty<object>();
					_observableItemsSource.Clear();
					foreach (var disposables in _groupedDataDisposables.Values)
						disposables.Dispose();

					_groupedDataDisposables.Clear();
					AddItems(enumerableGroupedItems, groupedDataConverter);
					break;
				case NotifyCollectionChangedAction.Add:
					AddItems(args.NewItems, groupedDataConverter);
					break;
				case NotifyCollectionChangedAction.Remove:
					foreach (var item in Enumerable.Cast<object>(args.OldItems))
					{
						var mvxGroupedData = groupedDataConverter.ConvertToMvxGroupedData(item);

						_observableItemsSource.Remove(mvxGroupedData);

						if (_groupedDataDisposables.ContainsKey(mvxGroupedData))
						{
							_groupedDataDisposables[mvxGroupedData].Dispose();
							_groupedDataDisposables.Remove(mvxGroupedData);
						}
					}
					break;
				default:
					ItemsMovedOrReplaced?.Invoke();
					break;
			}
        }

        public void Initialize(IEnumerable groupedItems, MvxExpandableDataConverter groupedDataConverter)
        {
            DisposeOldSource();
            this.groupedDataConverter = groupedDataConverter;
			var observableGroups = groupedItems as INotifyCollectionChanged;
			oldGroupedDataSource = observableGroups;

			if (observableGroups != null)
				observableGroups.CollectionChanged += ObservableGroups_CollectionChanged;

            AddItems(groupedItems, groupedDataConverter);
        }

        private void DisposeOldSource()
        {
			if (oldGroupedDataSource != null)
				oldGroupedDataSource.CollectionChanged -= ObservableGroups_CollectionChanged;
            oldGroupedDataSource = null;

			foreach (var disposable in _groupedDataDisposables.Values)
				disposable.Dispose();

			_groupedDataDisposables.Clear();
            _observableItemsSource.Clear();
        }

        private void AddItems(IEnumerable groupedItems, MvxExpandableDataConverter groupedDataConverter)
        {
            foreach (var mvxGroupable in groupedItems.Cast<object>().Select(groupedDataConverter.ConvertToMvxGroupedData))
            {
                if (!_observableItemsSource.Contains(mvxGroupable))
                    _observableItemsSource.Add(mvxGroupable);

                var childNotifyCollectionChanged = mvxGroupable.GroupItems as INotifyCollectionChanged;

                if (childNotifyCollectionChanged == null)
                    continue;

                if (!_groupedDataDisposables.ContainsKey(mvxGroupable))
                {
                    _groupedDataDisposables.Add(mvxGroupable, childNotifyCollectionChanged.WeakSubscribe((sender, args) =>
                    {
                        switch (args.Action)
                        {
                            case NotifyCollectionChangedAction.Add:
                                AddChildItems(mvxGroupable, args.NewItems);
                                break;
                            case NotifyCollectionChangedAction.Remove:
                                RemoveChildItems(mvxGroupable, args.OldItems);
                                break;
                            case NotifyCollectionChangedAction.Reset:
                                ResetChildCollection(mvxGroupable);
                                break;
                            default:
                                ItemsMovedOrReplaced?.Invoke();
                                break;
                        }
                    }));
                }
            }
        }

        private void AddChildItems(MvxGroupedData toGroup, IEnumerable items)
        {
            ChildItemsAdded?.Invoke(toGroup, items);
        }

        private void RemoveChildItems(MvxGroupedData toGroup, IEnumerable itemsToRemove){
            ChildItemsRemoved(toGroup, itemsToRemove);
        }

        private void ResetChildCollection(MvxGroupedData ofGroupedData)
        {
            ChildItemsCollectionCleared?.Invoke(ofGroupedData);
		}

        private void ClearData()
        {
            _observableItemsSource.Clear();
            foreach (var disposable in _groupedDataDisposables.Values)
                disposable.Dispose();
            _groupedDataDisposables.Clear();
        }

        public event Action<MvxGroupedData, IEnumerable> ChildItemsAdded;
        public event Action<MvxGroupedData, IEnumerable> ChildItemsRemoved;
        public event Action<MvxGroupedData> ChildItemsCollectionCleared;
        public event Action ItemsMovedOrReplaced;
    }
}