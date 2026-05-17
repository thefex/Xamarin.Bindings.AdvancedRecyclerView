using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using Sample.Core.Models;

namespace Sample.Android.Adapters.Expandable;

public class SampleExpandableTemplateSelector : MvxExpandableTemplateSelector, IMvxHeaderTemplate, IMvxFooterTemplate
{
    public SampleExpandableTemplateSelector()
        : base(Resource.Layout.item_group_header)
    {
    }

    public int HeaderLayoutId { get; set; }
    public int FooterLayoutId { get; set; }

    protected override int GetChildItemViewType(object forItemObject) => 0;

    protected override int GetChildItemLayoutId(int fromViewType)
        => Resource.Layout.item_expandable_child;
}
