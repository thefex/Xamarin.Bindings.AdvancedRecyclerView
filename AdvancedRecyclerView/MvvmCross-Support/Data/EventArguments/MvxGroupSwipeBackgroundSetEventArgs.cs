namespace MvvmCross.AdvancedRecyclerView.Data.EventArguments
{
    public class MvxGroupSwipeBackgroundSetEventArgs : MvxSwipeBackgroundSetEventArgs
    {
        /// <summary>
        /// Group item position
        /// </summary>
        public override int Position { get; internal set; }
    }
}