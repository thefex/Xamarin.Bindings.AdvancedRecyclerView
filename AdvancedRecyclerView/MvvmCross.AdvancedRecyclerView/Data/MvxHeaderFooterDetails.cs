using System;
namespace MvvmCross.AdvancedRecyclerView.Data
{
    public class MvxHeaderFooterDetails
    {
        public MvxHeaderFooterDetails()
        {
        }

        public int HeaderLayoutId { get; set; } = -1;

        public int FooterLayoutId { get; set; } = -1;

        public bool HasHeader => HeaderLayoutId != -1;

        public bool HasFooter => FooterLayoutId != -1;
    }
}
