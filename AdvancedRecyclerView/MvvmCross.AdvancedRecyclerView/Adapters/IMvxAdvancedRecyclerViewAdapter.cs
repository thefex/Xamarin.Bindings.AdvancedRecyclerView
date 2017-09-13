using System;
using System.Collections;
using System.Collections.Generic;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MvvmCross.AdvancedRecyclerView.Adapters
{
    public interface IMvxAdvancedRecyclerViewAdapter
    {
        IEnumerable ItemsSource { get; set; }
    }
}
