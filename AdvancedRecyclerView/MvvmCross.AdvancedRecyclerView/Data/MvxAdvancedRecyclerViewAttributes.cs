using System;
namespace MvvmCross.AdvancedRecyclerView.Data
{
    public class MvxAdvancedRecyclerViewAttributes
    {
        public MvxAdvancedRecyclerViewAttributes()
        {
        }

		public string TemplateSelectorClassName { get; set; }

		public int FooterLayoutId { get; set; }
        public int HeaderLayoutId { get; set; }
 
        public string GroupedDataConverterClassName { get; set; }

        public string GroupExpandControllerClassName { get; set; }
    }
}
