using System;
namespace MvvmCross.AdvancedRecyclerView.Data
{
    public class MvxHeaderFooterDetails
    {
        public MvxHeaderFooterDetails()
        {
        }

        public int HeaderLayoutId { get; set; } = 0;

        public int FooterLayoutId { get; set; } = 0;

        public bool HasHeader => HeaderLayoutId != 0;

        public bool HasFooter => FooterLayoutId != 0;
    }
}
