using System;
using MvvmCross.AdvancedRecyclerView.Data;
using Sample.ViewModels;

namespace Sample.GroupedRelated
{
	public class ItemGroupModelDataConverter : MvxExpandableDataConverter
	{
		protected override long GetChildItemUniqueId(object item)
		{
			return (item as ChildItemModel).UniqueId;
		}

		public override MvxGroupedData ConvertToMvxGroupedData(object item)
		{
			return new MvxGroupedData()
			{
				GroupItems = (item as ItemGroupModel).Child,
				Key = (item as ItemGroupModel).Header,
				UniqueId = (item as ItemGroupModel).UniqueId
			};
		}
	}
}
