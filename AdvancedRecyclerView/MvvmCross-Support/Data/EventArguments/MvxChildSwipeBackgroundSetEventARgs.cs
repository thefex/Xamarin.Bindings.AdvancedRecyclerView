namespace MvvmCross.AdvancedRecyclerView.Data.EventArguments
{
    public class MvxChildSwipeBackgroundSetEventARgs : MvxSwipeBackgroundSetEventArgs
    {
        /// <summary>
        /// Group item position
        /// </summary>
        public override int Position { get; internal set; }
        
        /// <summary>
        /// Child item position
        /// </summary>
        public int ChildPosition { get; internal set; }
    }
}