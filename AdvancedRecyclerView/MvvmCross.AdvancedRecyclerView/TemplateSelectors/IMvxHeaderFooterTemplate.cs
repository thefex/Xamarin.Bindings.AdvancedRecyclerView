using System;
namespace MvvmCross.AdvancedRecyclerView.TemplateSelectors
{
    public interface IMvxHeaderFooterTemplate 
    {
        int HeaderLayoutId { get; set; }

        int FooterLayoutId { get; set; }
    }
}
