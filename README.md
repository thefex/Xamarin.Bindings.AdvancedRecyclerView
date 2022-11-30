# *Xamarin.Bindings.AdvancedRecyclerView*
Xamarin Android binding library for: https://github.com/h6ah4i/android-advancedrecyclerview with MvvmCross support.

**MvvmCross.AdvancedRecyclerView** currently has MvvmCross DataBinding support for:
- expandable/grouped lists
- swipe (for both non expandable and grouped lists)
- header/footer support for both - expandable and non-grouped lists

Read more our case study with MvvmCros.AdvancedRecyclerView: https://insanelab.com/blog/mobile-development/xamarin-android-advanced-lists-in-mvvmcross/ 

# *Changelog*
MvvmCross.AdvancedRecyclerView

v 2.1.0.3

- Non Expandable Advanced Recycler View fix (for ex. swipe without grouping) - fixed a bug which caused item datacontext ('blank items') to be nullified. Introduced with some MvvmCross.RecyclerView package update (7.x/8.x+?)

v 2.1.0.2

- Support for both Mvvmcross 8.0.2 and MvvmCross 7.1.2 (nuspec update).

- Fixed crash when using inside ViewPager2. 

<b>NOTE: You need to call AdvancedRecyclerView.OnViewDestroy() on Acitivty/Fragment OnViewDestroy() manually now!</b>


v 2.1.0.0

Support for MvvmCross 8.2, updated to fully support AndroidX.

Uses custom AndroidRecyclerView build - so it supports AndroidX.RecyclerView v1.2.14+ packages.

Thanks to https://github.com/alexshikov for providing PR of update to AndroidX (adjusted it to Mvx 8)

v 1.16.2

Temporary workaround when using both AndroidX and support libraries. Issue #16 

v 1.16.1

Fixed bug with click commands acting twice on MvxNonExpandable RecyclerView/ADapter.

v 1.16.0

Updated MvvmCross to 6.4.2 

v 1.15.2 

- Swipe features can be customized (enabled/disabled/different percetange of swipe) now based on ViewHolder/DataModel property (see point X below)

v 1.14.0

- BREAKING CHANGE, see docs - Refactored Swipe to Dismiss feature (easier implementation)

- BUGFIX - possible application crash with grouping / grouping sometimes created invalid groups (duplicated groups)

- Added Swipe to Dismiss support on Grouped lists (group/child)

- Docs adjustments

v 1.12.0

- Update to MvvmCross 6.0+

v 1.11.1

- fixed random crashes/list stopped working in ExpandableRecyclerView to work when group child collection changes


# *Documentation*
As you can see in the documentation of Android Recycler View java library, it offers various RecyclerView extensions such as grouping, swipe-to-delete, header/footer and so on...

In documentation I will focus on those currently supported as MvvmCross bindings - available in *MvvmCross.AdvancedRecyclerView* nuget package.

Using **MvvmCross.AdvancedRecyclerView** is similar to orginal MvvmCross RecyclerView library.

Use cases:

# I. I want to add header, footer to non grouped list with simple, one item layout.

1. In your old RecyclerView/MvxRecyclerView .axml layout use:

```xml
<mvvmcross.advancedrecyclerview.MvxAdvancedNonExpandableRecyclerView 
    android:id="@+id/RecyclerView"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    local:MvxHeaderLayoutId="@layout/list_header_layout"
    local:MvxFooterLayoutId="@layout/list_footer_layout"
    local:MvxItemTemplate="@layout/yourLayoutName" 
    local:MvxUniqueItemIdProvider="@string/stringWithFullClassName"
    local:MvxBind="ItemsSource Items; ItemClick ItemClickCommand" />
```

2. Add header and footer layout. Both of those layouts get datacontext set to your current fragment/activity ViewModel. Layout name should be equal to **local:MvxHeaderLayoutId/local:MvxFooterLayoutId** you have set in previous step.

3. Implement of **IMvxItemUniqueIdProvider** interface.

**AdvancedRecyclerView** internally needs to assign unique id to each item - implementation of **IMvxItemUniqueIdProvider** should return unique id from your datacontext.

Sample:
https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/blob/master/AdvancedRecyclerView/Sample/Swipe/SwipeExampleUniqueIdProvider.cs

4. You should create an appropiate string in your strings.xml file - which would have key/value equal to your UniqueItemIdProvider full class name (like in **MvxRecyclerView Template Selector** - which I have created by the way :P )

Sample:
https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/blob/master/AdvancedRecyclerView/Sample/Resources/values/Strings.xml

String should have form of: Namespace.ClassName, AssemblyName

5. You are done :)

# II. I want to add header, footer to non grouped list with multiple item layouts.

1. Change your RecyclerView .axml:

```xml
<mvvmcross.advancedrecyclerview.MvxAdvancedNonExpandableRecyclerView
    android:id="@+id/RecyclerView"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    local:MvxHeaderLayoutId="@layout/list_header_layout"
    local:MvxFooterLayoutId="@layout/list_footer_layout"
    local:MvxTemplateSelector="@string/itemTemplateSelectorClassLikeInMvxRecyclerView" 
    local:MvxUniqueItemIdProvider="@string/stringWithFullClassName"
    local:MvxBind="ItemsSource Items; ItemClick ItemClickCommand" />
```

Just use **MvxTemplateSelector** like you would use with orginal **MvxRecyclerView**

2. Your **MvxTemplateSelector** should implement two interfaces - **IMvxHeaderTemplate, IMvxFooterTemplate** (if you want both, footer and header).

Sample implementation:

```cs
public class MyTemplateSelector : MvxTemplateSelector<MyCustomObject>, IMvxFooterTemplate, IMvxHeaderTemplate
{
    public int HeaderLayoutId { get; set; }
    public int FooterLayoutId { get; set; }

    public override int GetItemLayoutId(int fromViewType)
    {
        if (fromViewType == 0)
            return Resource.Layout.not_special_layout;

        return Resource.Layout.special_layout;
    }

    protected override int SelectItemViewType(MyCustomObject forItemObject)
    {
        return myCustomObject.IsSpecialTemplate ? 0 : 1;
    }
}
```

3. You are done :)

# III. Ok, great - I want to add swipe support to previous example

Well, that's a bit complex due to way how it has been implemented in **AdvancedRecyclerView**.

1. First of all, your item layout should contains two views - one of them will be visible during swipe/after swiped.

Look at example:
https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/blob/master/AdvancedRecyclerView/Sample/Resources/layout/swipe_item_template.axml

We've got an layout which has two containers: *underSwipe* and the default *container*.

2. When we have created an appropiate layout, lets implement special abstract class - called: **MvxSwipeableTemplate**.
According to that interface, **AdvancedRecyclerView** picks: 

- in which direction swiping works (from left to right, from right to left, from top to bottom and so on..)
- what is the view which represented swiped content,
- what is the default view - in not swiping state
- SwipeResultActionFactory - what are actions after pinning to edge? (should we move to this direction or unpin?)
- degree of swipe to left/right/up/bottom - (how much can we swipe in each direction? values of range [-1, 1] 

Sample implementation:

```cs
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;

namespace Sample.Swipe
{
    public class SwipeableTemplate : MvxSwipeableTemplate
    {
        public override int SwipeContainerViewGroupId => Resource.Id.container;

        public override int UnderSwipeContainerViewGroupId => Resource.Id.underSwipe;

        public override int SwipeReactionType => SwipeableItemConstants.ReactionCanSwipeBothH;

        public override float MaxLeftSwipeAmount => -1f;

        public override MvxSwipeResultActionFactory SwipeResultActionFactory => new SwipeResultActionFactory();
    }

    public class SwipeResultActionFactory : MvxSwipeResultActionFactory
    {
        public override SwipeResultAction GetSwipeLeftResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new MvxSwipeToDirectionResultAction(itemProvider, SwipeDirection.FromLeft);
        }

        public override SwipeResultAction GetSwipeRightResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new MvxSwipeUnpinResultAction(itemProvider);
        }

        public override SwipeResultAction GetUnpinSwipeResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new MvxSwipeUnpinResultAction(itemProvider);
        }
    }
}
```

**SwipeableItemConstants** represents constants related to swiping direction.

3. Lets update our base layout.

```xml
<mvvmcross.advancedrecyclerview.MvxAdvancedNonExpandableRecyclerView
    android:id="@+id/RecyclerView"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    local:MvxHeaderLayoutId="@layout/list_header_layout"
    local:MvxFooterLayoutId="@layout/list_footer_layout"
    local:MvxTemplateSelector="@string/itemTemplateSelectorClassLikeInMvxRecyclerView" 
    local:MvxSwipeableTemplate="@string/SwipeableTemplate"
    local:MvxUniqueItemIdProvider="@string/stringWithFullClassName"
    local:MvxBind="ItemsSource Items; ItemClick ItemClickCommand" />
```

Where **MvxSwipeableTemplate** is a string with full class name (as usual - in **MvxTemplateSelector** style)

Please, see https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/tree/master/AdvancedRecyclerView/RecordGuard.ListSample/RecordGuard.ListSample.Android for sample (grouped sample but this is the same, the only difference is usage of MvxSwipeableTemplate attribute)

Please check https://github.com/h6ah4i/android-advancedrecyclerview documentation as well.

# IV. Ok, fine. This time I need grouped, non-expandable lists.

Lets start from scratch.

1. Implement AdvancedRecyclerView layout - this time using **MvxAdvancedExpandableRecyclerView** 

```xml
<mvvmcross.advancedrecyclerview.MvxAdvancedExpandableRecyclerView
    android:id="@+id/recyclerView"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    local:MvxHeaderLayoutId="@layout/person_list_header"
    local:MvxFooterLayoutId="@layout/person_list_footer"
    local:MvxGroupedDataConverter="@string/person_grouped_data_converter"
    local:MvxGroupExpandController="@string/person_group_expand_controller"
    local:MvxTemplateSelector="@string/special_person_item_template_selector"
    local:MvxBind="ItemsSource Items; ChildItemClick PeopleTapped" />
```

For header/footers nothing changes with grouped lists.

However... we have an additional properties there which will be described in next subsections.

2. We have to implement **MvxExpandableDataConverter** - it is used to convert your Items DataSource to grouped data source -> **MvxGroupedData**

Sample implementation:

```cs
public class PeopleGroupedDataConverter : MvxExpandableDataConverter
{
    long index = 0;
    Dictionary<string, long> _indexMap = new Dictionary<string, long>();

    public PeopleGroupedDataConverter()
    {
    }

    public override MvxGroupedData ConvertToMvxGroupedData(object item)
    {
        var groupedItem = item as GroupedData;

        return new MvxGroupedData()
        {
            GroupItems = groupedItem.Items,
            Key = groupedItem.Key,
            UniqueId = GetChildItemUniqueId("MvxGroupedData" + groupedItem.Key)
        };   
    }

    protected override long GetChildItemUniqueId(object item)
    {
        var key = item.ToString();

        if (_indexMap.ContainsKey(key))
            return _indexMap[key];

        _indexMap.Add(key, index++);

        return _indexMap[key];
    }
}
```

Our ViewModel/DataModel contains item which has: Child items (items inside group), Key (object to which every group layout datacontext will be bound), Unique Id for every group.
Besides that - we have to return unique id for each child item - AdvancedRecyclerView uses it internally.

3. We have to implement **MvxGroupExpandController** - this controls how expand/collapse feature behaves. We can block expand/collapse for some groups.
We can also set should all groups be expanded on start.

If you want to use default implementation - all groups can be expanded/collapsed, all groups are expanded by default just use:
"@string/DefaultMvxGroupExpandController".

Below I have presented sample code of MvxGroupExpandController which forbiddes expanding.

```cs
public class PeopleGroupExpandController : MvxGroupExpandController
{
    public PeopleGroupExpandController()
    {
    }

    public override bool CanCollapseGroup(MvxGroupDetails groupDetails)
    {
        return false;
    }

    public override bool CanExpandGroup(MvxGroupDetails groupDetails)
    {
        return false;
    }

    public override bool OnHookGroupCollapse(MvxHookGroupExpandCollapseArgs groupItemDetails)
    {
        return true;
    }

    public override bool OnHookGroupExpand(MvxHookGroupExpandCollapseArgs groupItemDetails)
    {
        return true;
    }
}
```

4. We have also implement special **MvxTemplateSelector** - with support for groups, which is **MvxExpandableTemplateSelector**

Sample implementation:

```cs
public class PeopleListTemplateSelector : MvxExpandableTemplateSelector, IMvxHeaderTemplate, IMvxFooterTemplate
{
    public PeopleListTemplateSelector() : base(Resource.Layout.person_group_header)
    {
    }

    public int HeaderLayoutId { get; set; }
    public int FooterLayoutId { get; set; }

    protected override int GetChildItemLayoutId(int fromViewType)
    {
        return fromViewType == 1 ? Resource.Layout.special_person_layout : Resource.Layout.person_layout;
    }

    protected override int GetChildItemViewType(object forItemObject)
    {
        var person = forItemObject as Person;

        return person.IsSpecialPerson ? 1 : 2;
    } 
}
```

5. You are done :)

# V. That's nice. However I want to change my grouped lists to expandable/collapsable lists.
Just change your RecyclerView **MvxGroupExpandController** attribute to: "@string/DefaultMvxGroupExpandController". 

```diff
<mvvmcross.advancedrecyclerview.MvxAdvancedExpandableRecyclerView
        android:id="@+id/recyclerView"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        local:MvxHeaderLayoutId="@layout/person_list_header"
        local:MvxFooterLayoutId="@layout/person_list_footer"
        local:MvxGroupedDataConverter="@string/person_grouped_data_converter"
+       local:MvxGroupExpandController="@string/DefaultMvxGroupExpandController"
        local:MvxTemplateSelector="@string/special_person_item_template_selector"
        local:MvxBind="ItemsSource Items; ChildItemClick PeopleTapped" />
```

# VI. My client is VERY CREATIVE and changed app requiement once again. He thinks that only one section should be expanded at the one time (so called Accordion Expandable Lists)

That's easy. The Accordion like Expand Controller is ready (https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/blob/master/AdvancedRecyclerView/MvvmCross.AdvancedRecyclerView/Utils/AccordionMvxGroupExpandController.cs)

Just change Expand Controller attribute:

```diff
<mvvmcross.advancedrecyclerview.MvxAdvancedExpandableRecyclerView
        android:id="@+id/recyclerView"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        local:MvxHeaderLayoutId="@layout/person_list_header"
        local:MvxFooterLayoutId="@layout/person_list_footer"
        local:MvxGroupedDataConverter="@string/person_grouped_data_converter"
+       local:MvxGroupExpandController="@string/AccordionMvxGroupExpandController"
        local:MvxTemplateSelector="@string/special_person_item_template_selector"
        local:MvxBind="ItemsSource Items; ChildItemClick PeopleTapped" />
```

# VI. OK! How about adding swiping to grouped lists ?
Please, see point III and following sample: https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/tree/master/AdvancedRecyclerView/RecordGuard.ListSample/RecordGuard.ListSample.Android

Use: MvxGroupSwipeableTemplate or MvxChildSwipeableTemplate attribute.

# VII. How can I access bounded item view in code ?

For MvxAdvancedExpandableRecyclerView (grouped/expandable lists use):

```cs
var expandableItemAdapter = recyclerView.AdvancedRecyclerViewAdapter as MvxExpandableItemAdapter;
expandableItemAdapter.ChildItemBound += (e) =>
{
    e.ViewHolder.ItemView...
};
expandableItemAdapter.GroupItemBound += (e) =>
{
    e.ViewHolder.ItemView...
}
```

For MvxAdvancedNonExpandableRecyclerView use:

```cs
var mAdapter = mRecyclerView.AdvancedRecyclerViewAdapter as MvxNonExpandableAdapter;

mAdapter.MvxViewHolderBound += (args) =>
{
    // you have access to viewholder here..
}
```

# VIII. How can I access bounded header/footer view in code ?

**MvxAdvancedRecyclerView** exposes two events:

**MvxHeaderViewHolderBound** and **MvxFooterViewHolderBound** which gives you access to bound item viewholder.

# IX. How can I attach command to item click ?

You can bind to **MvxAdvancedRecyclerView** properties.

1. For Header Click/LongClick bind to: **HeaderClickCommand**/**HeaderLongClickCommand**

2. For Footer Click/LongClick bind to: **FooterClickCommand**/**FooterLongClickCommand**

3. For Item Click (non expandable/grouped recyclerview) bind to: **ItemClick**/**ItemLongClick**

4. For Group Item Click ( expandable/grouped recyclerview) bind to: **GroupItemClick**/**GroupItemLongClick**

5. For Child Item Click ( expandable / grouped recyclerview) bind to: **ChildItemClick**/**ChildItemLongClick**

# X. Love swipe to X feature! But I want to enable and disable "swipe to X" based on some of my list data model property (or even view one). Is that possible?

This feature has been added in version v1.15.2

Suppose you have Contacts list - and you want to have "call when swiped right" and "send sms when swiped left" features (as in default Android Samsung S10 Contacts app) when contact has phone number assigned.

Your **MvxSwipeableTemplate** should look as follows:

```cs
public class ContactOperationChildSwipeableTemplate : MvxSwipeableTemplate
{
    public override int SwipeContainerViewGroupId
    {
        get => Resource.Id.container_of_list_item; 
    }
    public override int UnderSwipeContainerViewGroupId => Resource.Id.underSwipe;

    protected override int SwipeReactionType => SwipeableItemConstants.ReactionCanSwipeBothH;

    public override int GetSwipeReactionType(object dataContext, MvxAdvancedRecyclerViewHolder holder)
    {
        if (dataContext is SelectableItem<ContactDetails> contactDetails && string.IsNullOrEmpty(contactDetails.Item.PhoneNumber))
            return SwipeableItemConstants.ReactionCanNotSwipeAny;

        return base.GetSwipeReactionType(dataContext, holder);
    }

    protected override float MaxLeftSwipeAmount => -1f;

    protected override float MaxRightSwipeAmount => 1f;

    public override float GetMaxLeftSwipeAmount(object dataContext, MvxAdvancedRecyclerViewHolder viewHolder)
    {
        if (dataContext is SelectableItem<ContactDetails> contactDetails && string.IsNullOrEmpty(contactDetails.Item.PhoneNumber))
            return 0;

        return base.GetMaxLeftSwipeAmount(dataContext, viewHolder);
    }

    public override float GetMaxRightSwipeAmount(object dataContext, MvxAdvancedRecyclerViewHolder viewHolder)
    {
        if (dataContext is SelectableItem<ContactDetails> contactDetails && string.IsNullOrEmpty(contactDetails.Item.PhoneNumber))
            return 0;

        return base.GetMaxRightSwipeAmount(dataContext, viewHolder);
    }

    public override int ItemViewSwipeLeftBackgroundResourceId => -1;
    //    Resource.Drawable.contact_bg_swipe_item_state_swiping_toLeft;

    public override int ItemViewSwipeRightBackgroundResourceId => -1;
     //   Resource.Drawable.bg_swipe_item_state_swiping_toRight;

    public override MvxSwipeResultActionFactory SwipeResultActionFactory => new SwipeResultActionFactory();
}
```
For more, please download repo and check two samples (one of this uses RX/DynamicData for grouping).

# *LICENSE*
This library is licensed under the Apache Software License, Version 2.0.

See LICENSE for full of the license text.

Copyright (C) 2015 Haruki Hasegawa ( Orginal Java library )

Copyright (C) 2017 Przemysław Raciborski ( Bindings Library + MvvmCross Bindings )

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
