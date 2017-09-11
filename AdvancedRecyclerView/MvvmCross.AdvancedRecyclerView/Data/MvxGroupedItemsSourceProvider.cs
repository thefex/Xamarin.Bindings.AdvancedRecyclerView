using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Platform.WeakSubscription;

namespace MvvmCross.AdvancedRecyclerView.Data
{
    internal class MvxGroupedItemsSourceProvider
    {
        private readonly ObservableCollection<object> _observableItemsSource = new ObservableCollection<object>();
        private readonly IList<IDisposable> _collectionChangedDisposables = new List<IDisposable>();
        private readonly Dictionary<MvxGroupedData, IDisposable> _groupedDataDisposables = new Dictionary<MvxGroupedData, IDisposable>();

        public ObservableCollection<object> Source => _observableItemsSource;

        public void Initialize(IEnumerable groupedItems, MvxExpandableDataConverter groupedDataConverter)
        {
            DisposeOldSource();
            AddItems(groupedItems, groupedDataConverter);

            var observableGroups = groupedItems as INotifyCollectionChanged;

            if (observableGroups != null)
            {
                var observableGroupsDisposeSubscription =
                    observableGroups.WeakSubscribe(
                        (sender, args) =>
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

                                        foreach (var childItem in mvxGroupedData.GroupItems)
                                            _observableItemsSource.Remove(childItem);
                                        _observableItemsSource.Remove(mvxGroupedData);

                                        if (_groupedDataDisposables.ContainsKey(mvxGroupedData))
                                        {
                                            _groupedDataDisposables[mvxGroupedData].Dispose();
                                            _groupedDataDisposables.Remove(mvxGroupedData);
                                        }
                                    }
                                    break;
                                default:
                                    throw new NotImplementedException("No move/replace in Grouped Items yet...");
                            }
                        });
                _collectionChangedDisposables.Add(observableGroupsDisposeSubscription);
            }
        }

        private void DisposeOldSource()
        {
            _observableItemsSource.Clear();
            foreach (var disposables in _collectionChangedDisposables)
                disposables.Dispose();
            foreach (var disposable in _groupedDataDisposables.Values)
                disposable.Dispose();

            _groupedDataDisposables.Clear();
            _collectionChangedDisposables.Clear();
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
                        if (isModyfingChildItems)
                            return;
                        
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
                                throw new NotImplementedException("No move/replace in Grouped Items yet...");
                        }
                    }));
                }
            }
        }

        bool isModyfingChildItems;
        private void AddChildItems(MvxGroupedData toGroup, IEnumerable items)
        {
            isModyfingChildItems = true;
            var groupItems = toGroup.GroupItems as IList;
            if (groupItems != null && !groupItems.IsReadOnly)
            {
                foreach (var item in items)
                    groupItems.Add(item);
            }
            isModyfingChildItems = false;
            ChildItemsAdded?.Invoke(toGroup, items);
        }

        private void RemoveChildItems(MvxGroupedData toGroup, IEnumerable itemsToRemove){
            isModyfingChildItems = true;
            var groupItems = toGroup.GroupItems as IList;
            foreach (var itemToRemove in itemsToRemove)
            {
                groupItems.Remove(itemToRemove);
            }
            isModyfingChildItems = false;
            ChildItemsRemoved(toGroup, itemsToRemove);
        }

        private void ResetChildCollection(MvxGroupedData ofGroupedData)
        {
            isModyfingChildItems = true;
            var groupItems = ofGroupedData.GroupItems as IList;
            groupItems.Clear();
            isModyfingChildItems = false;
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
    }
}