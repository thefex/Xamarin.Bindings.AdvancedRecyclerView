using System;
using System.Collections.Generic;
using MvvmCross.AdvancedRecyclerView.Data;
using RecordGuard.ListSample.App.Data;

namespace RecordGuard.ListSample.Android.Extensions.Grouping
{
    public class AudioListGroupedDataConverter : MvxExpandableDataConverter
    {
        readonly Dictionary<long, int> _longToSmallIntMap = new Dictionary<long, int>();
        private int currentId = 0;
        
        public override MvxGroupedData ConvertToMvxGroupedData(object item)
        {
            var groupedData = item as GroupedData<DateTime, AudioItem>;

            return new MvxGroupedData()
            {
                GroupItems = groupedData.ChildItems,
                Key = groupedData.Key,
                UniqueId = GetId(groupedData.Key.Ticks)
            };
        }

        protected override long GetChildItemUniqueId(object item)
        {
            var audioItem = item as AudioItem;
            return GetId(audioItem.CreatedDateUtc.Ticks);
        }

        private int GetId(long longId)
        {
            if (!_longToSmallIntMap.ContainsKey(longId))
                _longToSmallIntMap.Add(longId, currentId++);

            return _longToSmallIntMap[longId];
        }
    }
}