using System;
using System.Collections.Generic;
using MvvmCross.AdvancedRecyclerView.Data;
using XamarinMvvmCross_MeetupSample.Core;

namespace XamarinMvvmCross_MeetupSample.Droid
{
	public class PeopleGroupedDataConverter : MvxExpandableDataConverter
	{
        long index = 0;
        Dictionary<string, long> _indexMap = new Dictionary<string, long>();

		public PeopleGroupedDataConverter()
		{
		}

        public override MvxGroupedData ConvertToMvxGroupedData(object item)
        {
			var groupedItem = item as GroupedData;

			return new MvxGroupedData()
			{
                GroupItems = groupedItem.Items,
				Key = groupedItem.Key,
                UniqueId = GetChildItemUniqueId("MvxGroupedData" + groupedItem.Key)
			};   
        }

        protected override long GetChildItemUniqueId(object item)
        {
            var key = item.ToString();

            if (_indexMap.ContainsKey(key))
                return _indexMap[key];

            _indexMap.Add(key, index++);
            return _indexMap[key];
        }
    }
}
