using System;
using System.Collections;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public class GroupedData
	{
		public GroupedData()
		{
		}

		public string Key { get; set; }

		public IEnumerable Items { get; set; }
	}
}
