using System;
using System.Threading.Tasks;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public interface IIncrementalLoading
	{
		Task LoadMoreData();

		bool ShouldLoadMoreData();
	}
}
