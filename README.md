# Xamarin.Bindings.AdvancedRecyclerView
Xamarin Android binding library for: https://github.com/h6ah4i/android-advancedrecyclerview

# Documentatio
As you can see in the documentation of Android Recycler View java library, it offers various RecyclerView extensions such as grouping, swipe-to-delete, header/footer and so on...

In documentation I will focus on those currently supported as MvvmCross bindings - available in *MvvmCross.AdvancedRecyclerView* nuget package.

Using **MvvmCross.AdvancedRecyclerView** is similar to orginal MvvmCross RecyclerView library.

Use cases:

**I. I want to add header, footer to non grouped list with simple, one item layout.**

1. In your old RecyclerView/MvxRecyclerView .axml layout use:

	    <mvvmcross.advancedrecyclerview.MvxAdvancedNonExpandableRecyclerView 
			android:id="@+id/RecyclerView"
			android:layout_width="match_parent"
			android:layout_height="match_parent"
			local:MvxHeaderLayoutId="@layout/list_header_layout"
			local:MvxFooterLayoutId="@layout/list_footer_layout"
			local:MvxItemTemplate="@layout/yourLayoutName" 
			local:MvxUniqueItemIdProvider="@string/stringWithFullClassName"
			local:MvxBind="ItemsSource Items; ItemClick ItemClickCommand" />"


2. Add header and footer layout. Both of those layouts get datacontext set to your current fragment/activity ViewModel. Layout name should be equal to **local:MvxHeaderLayoutId/local:MvxFooterLayoutId** you have set in previous step.

3. Implement **IMvxItemUniqueIdProvider** interface. **AdvancedRecyclerView** internally needs to assign unique id to each item - implementation **IMvxItemUniqueIdProvider** should return unique id from your datacontext.

Sample:
https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/blob/master/AdvancedRecyclerView/Sample/Swipe/SwipeExampleUniqueIdProvider.cs

4. You should create an appropiate string in your strings.xml file - which would have key/value equal to your UniqueItemIdProvider full class name (like in **MvxRecyclerView Template Selector** - which I have created by the way :P )

Sample:
https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/blob/master/AdvancedRecyclerView/Sample/Resources/values/Strings.xml

String should have form of: Namespace.ClassName, AssemblyName

5. You are done :)

**II. I want to add header, footer to non grouped list with multiple item layouts.**

1.
	    <mvvmcross.advancedrecyclerview.MvxAdvancedNonExpandableRecyclerView
			android:id="@+id/RecyclerView"
			android:layout_width="match_parent"
			android:layout_height="match_parent"
			local:MvxHeaderLayoutId="@layout/list_header_layout"
			local:MvxFooterLayoutId="@layout/list_footer_layout"
			local:MvxItemTemplateSelector="@string/itemTemplateSelectorClassLikeInMvxRecyclerView" 
			local:MvxUniqueItemIdProvider="@string/stringWithFullClassName"
			local:MvxBind="ItemsSource Items; ItemClick ItemClickCommand" />"

Just use **MvxItemTemplateSelector** like you would use with orginal **MvxRecyclerView**

2. Your **MvxTemplateSelector** should implement two interfaces - **IMvxHeaderTemplate, IMvxFooterTemplate** (if you want both, footer and header).

Sample implementation:

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


3. You are done :)



** III. Ok, great - I want to add swipe support to previous example **

Well, that's a bit complex due to way how it has been implemented in **AdvancedRecyclerView**.

1. First of all, your item layout should contains two views - one of them will be visible during swipe/after swiped.

Look at example:
https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/blob/master/AdvancedRecyclerView/Sample/Resources/layout/swipe_item_template.axml

We've got an layout which has two containers: *underSwipe* and the default *container*.

2. When we have created an appropiate layout, lets implement special interface - called: **IMvxSwipeableTemplate**.
According to that interface, **AdvancedRecyclerView** picks: 

- in which direction swiping works (from left to right, from right to left, from top to bottom and so on..)
- what is the view which represented swiped content,
- what is the default view - in not swiping state

Sample implementation:

	using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
	using MvvmCross.AdvancedRecyclerView.TemplateSelectors;

	namespace Sample.Swipe
	{
	    public class SwipeableTemplate : IMvxSwipeableTemplate
	    {
		public int SwipeContainerViewGroupId => Resource.Id.container;

		public int UnderSwipeContainerViewGroupId => Resource.Id.underSwipe;

		public int SwipeReactionType => SwipeableItemConstants.ReactionCanSwipeBothH;
	    }
	}


**SwipeableItemConstants** represents constants related to swiping direction.

3. Lets update our base layout.

	<mvvmcross.advancedrecyclerview.MvxAdvancedNonExpandableRecyclerView
		android:id="@+id/RecyclerView"
		android:layout_width="match_parent"
		android:layout_height="match_parent"
		local:MvxHeaderLayoutId="@layout/list_header_layout"
		local:MvxFooterLayoutId="@layout/list_footer_layout"
		local:MvxItemTemplateSelector="@string/itemTemplateSelectorClassLikeInMvxRecyclerView" 
		local:MvxSwipeableTemplate="@string/SwipeableTemplate"
		local:MvxUniqueItemIdProvider="@string/stringWithFullClassName"
		local:MvxBind="ItemsSource Items; ItemClick ItemClickCommand" />

Where **MvxSwipeableTemplate** is a string with full class name (as usual - in **MvxTemplateSelector** style)

4. We can control in code how much slide amount is available, what background is set in swiped state.
We can control in code how item behaves after we swiped (should it go back to default state? should it be pinned?)

Look at this samples:
https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/blob/master/AdvancedRecyclerView/Sample/SwipeExampleActivity.cs
https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/blob/master/AdvancedRecyclerView/Sample/Swipe/SwipeResultActionFactory.cs

If you want to implement for ex. swipe-to-delete - you would have to create **MvxSwipeToDirectionResultAction** implementation and override **OnSlideAnimationEnd** method. Then, you should return instance of this class in SwipeResultActionFactory.

Please check https://github.com/h6ah4i/android-advancedrecyclerview documentation as well.

// todo write more about swiping features

*** IV. Ok, fine. This time I need grouped, non-expandable lists. **

Lets start from scratch.

1. Implement AdvancedRecyclerView layout - this time using **MvxAdvancedExpandableRecyclerView** 

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

For header/footers nothing changes with grouped lists.

However... we have an additional properties there which will be described in next subsections.

2. We have to implement **MvxExpandableDataConverter** - it is used to convert your Items DataSource to grouped data source -> **MvxGroupedData**

Sample implementation:

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


Our ViewModel/DataModel contains item which has: Child items (items inside group), Key (object to which every group layout datacontext will be bound), Unique Id for every group.
Besides that - we have to return unique id for each child item - AdvancedRecyclerView uses it internally.

3. We have to implement **MvxGroupExpandController** - this controls how expand/collapse feature behaves. We can block expand/collapse for some groups.
We can also set should all groups be expanded on start.

If you want to use default implementation - all groups can be expanded/collapsed, all groups are expanded by default just use:
"@string/DefaultMvxGroupExpandController".

Below I have presented sample code of MvxGroupExpandController which forbiddes expanding.

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

4. We have also implement special **MvxItemTemplateSelector** - with support for groups, which is **MvxExpandableTemplateSelector**

Sample implementation:

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

5. You are done :)

** V. That's nice. However I want to change my grouped lists to expandable/collapsable lists. **
Just change your RecyclerView **MvxGroupExpandController** attribute to: "@string/DefaultMvxGroupExpandController". 

    <mvvmcross.advancedrecyclerview.MvxAdvancedExpandableRecyclerView
            android:id="@+id/recyclerView"
            android:layout_width="match_parent"
            android:layout_height="match_parent"
            local:MvxHeaderLayoutId="@layout/person_list_header"
            local:MvxFooterLayoutId="@layout/person_list_footer"
            local:MvxGroupedDataConverter="@string/person_grouped_data_converter"
           * local:MvxGroupExpandController="@string/DefaultMvxGroupExpandController"*
            local:MvxTemplateSelector="@string/special_person_item_template_selector"
            local:MvxBind="ItemsSource Items; ChildItemClick PeopleTapped" />

** VI. My client is VERY CREATIVE and changed app requiement once again. He thinks that only one section should be expanded at the one time (so called Accordion Expandable Lists)

That's easy. The Accordion like Expand Controller is ready (https://github.com/thefex/Xamarin.Bindings.AdvancedRecyclerView/blob/master/AdvancedRecyclerView/MvvmCross.AdvancedRecyclerView/Utils/AccordionMvxGroupExpandController.cs)

Just change Expand Controller attribute:

    <mvvmcross.advancedrecyclerview.MvxAdvancedExpandableRecyclerView
            android:id="@+id/recyclerView"
            android:layout_width="match_parent"
            android:layout_height="match_parent"
            local:MvxHeaderLayoutId="@layout/person_list_header"
            local:MvxFooterLayoutId="@layout/person_list_footer"
            local:MvxGroupedDataConverter="@string/person_grouped_data_converter"
            *local:MvxGroupExpandController="@string/AccordionMvxGroupExpandController"*
            local:MvxTemplateSelector="@string/special_person_item_template_selector"
            local:MvxBind="ItemsSource Items; ChildItemClick PeopleTapped" />


** VI. OK! How about adding swiping to grouped lists ? **
Sorry, not supported yet with MvvmCross bindings.
Feel free to make PR or just... wait :)

** VII. How can I access bounded item view in code ? **

For MvxAdvancedExpandableRecyclerView (grouped/expandable lists use):

    var expandableItemAdapter = recyclerView.AdvancedRecyclerViewAdapter as MvxExpandableItemAdapter;
    expandableItemAdapter.ChildItemBound += (e) =>
    {
	e.ViewHolder.ItemView...

    };
    expandableItemAdapter.GroupItemBound += (e) =>{
	e.ViewHolder.ItemView...
    }

For MvxAdvancedNonExpandableRecyclerView use:


	var mAdapter = mRecyclerView.AdvancedRecyclerViewAdapter as MvxNonExpandableAdapter;

	mAdapter.MvxViewHolderBound += (args) =>
	{
	 // you have access to viewholder here..
	}


** VIII. How can I access bounded header/footer view in code ? **

**MvxAdvancedRecyclerView** exposes two events:
** MvxHeaderViewHolderBound ** and **MvxFooterViewHolderBound** which gives you access to bound item viewholder.

** IX. How can I attach command to item click ? **

You can bind to **MvxAdvancedRecyclerView** properties.

1. For Header Click/LongClick bind to: **HeaderClickCommand**/**HeaderLongClickCommand**

2. For Footer Click/LongClick bind to: **FooterClickCommand**/**FooterLongClickCommand**

3. For Item Click (non expandable/grouped recyclerview) bind to: **ItemClick**/**ItemLongClick**

4. For Group Item Click ( expandable/grouped recyclerview) bind to: **GroupItemClick**/**GroupItemLongClick**

5. For Child Item Click ( expandable / grouped recyclerview) bind to: **ChildItemClick**/**ChildItemLongClick**


For more, please download repo and check two samples (one of this uses RX/DynamicData for grouping).

# LICENSE 
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
