using System;
using Android.Views;

namespace XamarinMvvmCross_MeetupSample.Droid
{
	public static class ViewExtensions
	{
		// simple dfs over view child tree
		public static View ForEachView<TOfType>(this View view, Action<TOfType> invokeAction) where TOfType : View
		{
			var castedView = view as TOfType;
			if (castedView != null)
				invokeAction(castedView);

			var viewAsViewGroup = view as ViewGroup;
			if (viewAsViewGroup == null)
				return view;

			for (var i = 0; i < viewAsViewGroup.ChildCount; ++i)
			{
				var childView = viewAsViewGroup.GetChildAt(i);
				ForEachView(childView, invokeAction);
			}

			return view;
		}
	}
}
