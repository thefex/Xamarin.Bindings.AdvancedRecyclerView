using MvvmCross.AdvancedRecyclerView.TemplateSelectors;

namespace RecordGuard.ListSample.Android.Extensions.TemplateSelectors
{
    public class AudioItemTemplateSelector : MvxExpandableTemplateSelector
    {
        public AudioItemTemplateSelector() : base(Resource.Layout.audio_item_template_group_header)
        {
        }

        protected override int GetChildItemViewType(object forItemObject)
        {
            return Resource.Layout.audio_item_template;
        }

        protected override int GetChildItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }
    }
}