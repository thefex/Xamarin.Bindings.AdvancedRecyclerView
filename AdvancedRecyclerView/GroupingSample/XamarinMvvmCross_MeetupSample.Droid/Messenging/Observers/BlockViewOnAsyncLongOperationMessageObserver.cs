using System;
using System.Collections.Generic;
using System.Linq;
using Android.Views;
using XamarinMvvmCross_MeetupSample.Core;

namespace XamarinMvvmCross_MeetupSample.Droid
{
	internal class BlockViewOnAsyncLongOperationMessageObserver : LongRunningAsyncOperationMessageObserver
	{
		private readonly WeakReference<View> _rootView;

		public BlockViewOnAsyncLongOperationMessageObserver(WeakReference<View> rootView)
		{
			_rootView = rootView;
		}

		protected override void OnAsyncOperationStarted()
		{
			base.OnAsyncOperationStarted();
			SetViewState(false);
		}

		protected override void OnAsyncOperationFinished()
		{
			base.OnAsyncOperationFinished();
			SetViewState(true);
		}

		private void SetViewState(bool isEnabled)
		{
			View view = null;
			_rootView.TryGetTarget(out view);

			if (view != null)
				view.Enabled = isEnabled;
		}

		public static IEnumerable<BlockViewOnAsyncLongOperationMessageObserver> BuildObservers(ViewGroup fromViewGroup)
		{
			var viewsToBlock = new List<View>();

			fromViewGroup.ForEachView<View>(view =>
			{
				viewsToBlock.Add(view);
			});

			return
				viewsToBlock.Select(
					view => new BlockViewOnAsyncLongOperationMessageObserver(new WeakReference<View>(view)));
		}
	}
}
