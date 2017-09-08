using System;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;

namespace Sample.GroupedRelated
{
    public class AppGroupTemplateSelector : MvxDefaultExpandableTemplateSelector
    {
        public AppGroupTemplateSelector() : base(Resource.Layout.expand_group_template, Resource.Layout.expand_child_template)
        {
        }

    }
}
