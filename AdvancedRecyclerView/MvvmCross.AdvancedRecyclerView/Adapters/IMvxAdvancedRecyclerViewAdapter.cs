using System;
using System.Collections;
using System.Collections.Generic;

namespace MvvmCross.AdvancedRecyclerView.Adapters
{
    public interface IMvxAdvancedRecyclerViewAdapter
    {
        IEnumerable ItemsSource { get; set; }
    }
}
