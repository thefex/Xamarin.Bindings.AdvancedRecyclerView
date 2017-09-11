using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace Sample.Swipe
{
    class SwipeTemplateSelector : MvxDefaultTemplateSelector
    {
        public SwipeTemplateSelector() : base(Resource.Layout.swipe_item_template)
        {

        }
    }


}