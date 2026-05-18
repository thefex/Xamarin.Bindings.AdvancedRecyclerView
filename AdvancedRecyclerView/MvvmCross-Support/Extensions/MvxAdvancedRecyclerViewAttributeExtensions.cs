using System;
using Android.Content;
using Android.Content.Res;
using Android.Util;
using Microsoft.Extensions.Logging;
using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.ItemUniqueIdProvider;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using MvvmCross.AdvancedRecyclerView.Utils;
using MvvmCross.DroidX.RecyclerView.ItemTemplates;
using MvvmCross.Logging;
using MvvmCross.Platforms.Android.Binding.Views;

namespace MvvmCross.AdvancedRecyclerView.Extensions
{
    static class MvxAdvancedRecyclerViewAttributeExtensions
    {
        public static MvxAdvancedRecyclerViewAttributes ParseRecyclerViewAttributes(Context context, IAttributeSet attrs)
            => ReadRecyclerViewItemTemplateSelectorAttributes(context, attrs);

        private static MvxAdvancedRecyclerViewAttributes ReadRecyclerViewItemTemplateSelectorAttributes(Context context, IAttributeSet attrs)
        {            TypedArray typedArray = null;

            string templateSelectorClassName = string.Empty;
            string groupedDataConverterClassName = string.Empty;
            string groupExpandControllerClassName = string.Empty;
            string swipeableTemplateClassName = string.Empty;
            string uniqueItemIdProviderClassName = string.Empty;
            string groupSwipeableTemplateClassName = string.Empty;
            string childSwipeableTemplateClassName = string.Empty;
            
            int headerLayoutId = 0;
            int footerLayoutId = 0;

            try
            {
                typedArray = context.ObtainStyledAttributes(attrs, MvxRecyclerViewGroupId);
                int numberOfStyles = typedArray.IndexCount;

                for (int i = 0; i < numberOfStyles; ++i)
                {
                    var attributeId = typedArray.GetIndex(i);

                    if (attributeId == MvxRecyclerViewGroupExpandController)
                        groupExpandControllerClassName = typedArray.GetString(attributeId);
                    if (attributeId == MvxRecyclerViewItemTemplateSelector)
                        templateSelectorClassName = typedArray.GetString(attributeId);
                    if (attributeId == MvxRecyclerViewHeaderLayoutId)
                        headerLayoutId = typedArray.GetResourceId(attributeId, 0);
                    if (attributeId == MvxRecyclerViewFooterLayoutId)
                        footerLayoutId = typedArray.GetResourceId(attributeId, 0);
                    if (attributeId == MvxRecyclerViewGroupedDataConverter)
                        groupedDataConverterClassName = typedArray.GetString(attributeId);
                    if (attributeId == MvxRecyclerViewSwipeableTemplate)
                        swipeableTemplateClassName = typedArray.GetString(attributeId);
                    if (attributeId == MvxRecyclerViewUniqueItemIdProvider)
                        uniqueItemIdProviderClassName = typedArray.GetString(attributeId);
                    if (attributeId == MvxRecyclerViewGroupSwipeableTemplate)
                        groupSwipeableTemplateClassName = typedArray.GetString(attributeId);
                    if (attributeId == MvxRecyclerViewChildSwipeableTemplate)
                        childSwipeableTemplateClassName = typedArray.GetString(attributeId);
                }
            }
            finally
            {
                typedArray?.Recycle();
            }

            if (string.IsNullOrEmpty(templateSelectorClassName))
                templateSelectorClassName = typeof(MvxDefaultTemplateSelector).FullName;
            if (string.IsNullOrEmpty(groupExpandControllerClassName))
                groupExpandControllerClassName = typeof(DefaultMvxGroupExpandController).FullName;

            var templateLayoutId = MvxAttributeHelpers.ReadListItemTemplateId(context, attrs);
            return new MvxAdvancedRecyclerViewAttributes()
            {
                TemplateSelectorClassName = templateSelectorClassName,
                ItemTemplateLayoutId = templateLayoutId,
                FooterLayoutId = footerLayoutId,
                HeaderLayoutId = headerLayoutId,
                GroupedDataConverterClassName = groupedDataConverterClassName,
                GroupExpandControllerClassName = groupExpandControllerClassName,
                SwipeableTemplateClassName = swipeableTemplateClassName,
                UniqueItemIdProviderClassName = uniqueItemIdProviderClassName,
                GroupSwipeableTemplateClassName = groupSwipeableTemplateClassName,
                ChildSwipeableTemplateClassName = childSwipeableTemplateClassName
            };
        }

        public static bool IsGroupingSupported(MvxAdvancedRecyclerViewAttributes attributes)
            => !string.IsNullOrEmpty(attributes.GroupedDataConverterClassName);

        public static bool IsSwipeSupported(MvxAdvancedRecyclerViewAttributes attributes)
            => !string.IsNullOrEmpty(attributes.SwipeableTemplateClassName);

        public static bool IsSwipeForExpandableSupported(MvxAdvancedRecyclerViewAttributes attributes)
            => IsGroupedSwipeSupported(attributes) || IsGroupedChildSwipeSupported(attributes);

        public static bool IsGroupedSwipeSupported(MvxAdvancedRecyclerViewAttributes attributes)
            => !string.IsNullOrEmpty(attributes.GroupSwipeableTemplateClassName);

        public static bool IsGroupedChildSwipeSupported(MvxAdvancedRecyclerViewAttributes attributes)
            => !string.IsNullOrEmpty(attributes.ChildSwipeableTemplateClassName);

        public static MvxExpandableDataConverter BuildMvxGroupedDataConverter(MvxAdvancedRecyclerViewAttributes attributes)
        {
            var groupedDataConverterClassName = attributes.GroupedDataConverterClassName;
            var type = Type.GetType(groupedDataConverterClassName);
            Mvx.IoCProvider.TryResolve(out ILogger logger);

            if (type == null)
            {
                var message = $"Can't build Grouped Data Converter." +
                    $"Sorry but type with class name: {groupedDataConverterClassName} does not exist." +
                              $"Make sure you have provided full Type name: namespace + class name, AssemblyName.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            if (!typeof(MvxExpandableDataConverter).IsAssignableFrom(type))
            {
                string message = $"Sorry but type: {type} does not implement {nameof(MvxExpandableDataConverter)} interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            if (type.IsAbstract)
            {
                string message = $"Sorry can not instatiate {nameof(MvxExpandableDataConverter)} as provided type: {type} is abstract/interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            return Activator.CreateInstance(type) as MvxExpandableDataConverter;
        }

        public static IMvxTemplateSelector BuildItemTemplateSelector(MvxAdvancedRecyclerViewAttributes templateSelectorAttributes)
        {
            var type = Type.GetType(templateSelectorAttributes.TemplateSelectorClassName);
            Mvx.IoCProvider.TryResolve(out ILogger logger);

            if (type == null && templateSelectorAttributes.ItemTemplateLayoutId == 0)
            {
                var message = $"Cant create template selector." +
                    $"Sorry but type with class name: {templateSelectorAttributes.TemplateSelectorClassName} does not exist." +
                             $"Make sure you have provided full Type name: namespace + class name, AssemblyName." +
                              $"Example (check Example.Droid sample!): Example.Droid.Common.TemplateSelectors.MultiItemTemplateModelTemplateSelector, Example.Droid";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            if (type != null && !typeof(IMvxTemplateSelector).IsAssignableFrom(type))
            {
                string message = $"Sorry but type: {type} does not implement {nameof(IMvxTemplateSelector)} interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            if (type?.IsAbstract ?? false)
            {
                string message = $"Sorry can not instatiate {nameof(IMvxTemplateSelector)} as provided type: {type} is abstract/interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            IMvxTemplateSelector templateSelector = null;
            if (type != null)
                templateSelector = Activator.CreateInstance(type) as IMvxTemplateSelector;
            else
                templateSelector = new MvxDefaultHeaderFooterTemplateSelector(templateSelectorAttributes.ItemTemplateLayoutId);
            
            var headerTemplate = templateSelector as IMvxHeaderTemplate;
            var footerTemplate = templateSelector as IMvxFooterTemplate;

            if (headerTemplate != null)
                headerTemplate.HeaderLayoutId = templateSelectorAttributes.HeaderLayoutId;

            if (footerTemplate != null)
                footerTemplate.FooterLayoutId = templateSelectorAttributes.FooterLayoutId;

            return templateSelector;
        }

        public static MvxGroupExpandController BuildGroupExpandController(MvxAdvancedRecyclerViewAttributes attributes)
        {
            var groupExpandControllerClassName = attributes.GroupExpandControllerClassName;
            var type = Type.GetType(groupExpandControllerClassName);
            Mvx.IoCProvider.TryResolve(out ILogger logger);

            if (type == null)
            {
                var message = $"Can't build GroupExpandController." +
                    $"Sorry but type with class name: {groupExpandControllerClassName} does not exist." +
                              $"Make sure you have provided full Type name: namespace + class name, AssemblyName.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            if (!typeof(MvxGroupExpandController).IsAssignableFrom(type))
            {
                string message = $"Sorry but type: {type} does not implement {nameof(MvxGroupExpandController)} interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            if (type.IsAbstract)
            {
                string message = $"Sorry can not instatiate {nameof(MvxGroupExpandController)} as provided type: {type} is abstract/interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            return Activator.CreateInstance(type) as MvxGroupExpandController;
        }

        public static MvxSwipeableTemplate BuildSwipeableTemplate(MvxAdvancedRecyclerViewAttributes templateSelectorAttributes)
        {
            var type = Type.GetType(templateSelectorAttributes.SwipeableTemplateClassName);
            Mvx.IoCProvider.TryResolve(out ILogger logger);

			if (type == null)
			{
				var message = $"Can't build swipeable template." +
                    $"Sorry but type with class name: {templateSelectorAttributes.SwipeableTemplateClassName} does not exist." +
							 $"Make sure you have provided full Type name: namespace + class name, AssemblyName." +
							  $"Example (check Example.Droid sample!): Example.Droid.Common.TemplateSelectors.MultiItemTemplateModelTemplateSelector, Example.Droid";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
			}

            if (!typeof(MvxSwipeableTemplate).IsAssignableFrom(type))
			{
                string message = $"Sorry but type: {type} does not implement {nameof(MvxSwipeableTemplate)} interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
			}

			if (type.IsAbstract)
			{
                string message = $"Sorry can not instatiate {nameof(MvxSwipeableTemplate)} as provided type: {type} is abstract/interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
			}

            var swipeableTemplate = Activator.CreateInstance(type) as MvxSwipeableTemplate;
			return swipeableTemplate;
        }

        public static MvxSwipeableTemplate BuildGroupSwipeableTemplate(MvxAdvancedRecyclerViewAttributes templateSelectorAttributes)
        {
            var type = Type.GetType(templateSelectorAttributes.GroupSwipeableTemplateClassName);
            Mvx.IoCProvider.TryResolve(out ILogger logger);

            if (type == null)
            {
                var message = $"Can't build group swipeable template." +
                              $"Sorry but type with class name: {templateSelectorAttributes.GroupSwipeableTemplateClassName} does not exist." +
                              $"Make sure you have provided full Type name: namespace + class name, AssemblyName." +
                              $"Example (check Example.Droid sample!): Example.Droid.Common.TemplateSelectors.MultiItemTemplateModelTemplateSelector, Example.Droid";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            if (!typeof(MvxSwipeableTemplate).IsAssignableFrom(type))
            {
                string message = $"Sorry but type: {type} does not implement {nameof(MvxSwipeableTemplate)} interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            if (type.IsAbstract)
            {
                string message = $"Sorry can not instatiate {nameof(MvxSwipeableTemplate)} as provided type: {type} is abstract/interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            var swipeableTemplate = Activator.CreateInstance(type) as MvxSwipeableTemplate;
            return swipeableTemplate;        }
        
        public static MvxSwipeableTemplate BuildGroupChildSwipeableTemplate(MvxAdvancedRecyclerViewAttributes templateSelectorAttributes)
        {
            var type = Type.GetType(templateSelectorAttributes.ChildSwipeableTemplateClassName);
            Mvx.IoCProvider.TryResolve(out ILogger logger);

            if (type == null)
            {
                var message = $"Can't build child swipeable template." +
                              $"Sorry but type with class name: {templateSelectorAttributes.ChildSwipeableTemplateClassName} does not exist." +
                              $"Make sure you have provided full Type name: namespace + class name, AssemblyName." +
                              $"Example (check Example.Droid sample!): Example.Droid.Common.TemplateSelectors.MultiItemTemplateModelTemplateSelector, Example.Droid";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            if (!typeof(MvxSwipeableTemplate).IsAssignableFrom(type))
            {
                string message = $"Sorry but type: {type} does not implement {nameof(MvxSwipeableTemplate)} interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            if (type.IsAbstract)
            {
                string message = $"Sorry can not instatiate {nameof(MvxSwipeableTemplate)} as provided type: {type} is abstract/interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
            }

            var swipeableTemplate = Activator.CreateInstance(type) as MvxSwipeableTemplate;
            return swipeableTemplate;
           
        }

        public static IMvxItemUniqueIdProvider BuildUniqueItemIdProvider(MvxAdvancedRecyclerViewAttributes templateSelectorAttributes){
            var type = Type.GetType(templateSelectorAttributes.UniqueItemIdProviderClassName);
            Mvx.IoCProvider.TryResolve(out ILogger logger);

			if (type == null)
			{
				var message = $"Can't build unique item id provider." +
                    $"Sorry but type with class name: {templateSelectorAttributes.UniqueItemIdProviderClassName} does not exist." +
							 $"Make sure you have provided full Type name: namespace + class name, AssemblyName." +
							  $"Example (check Example.Droid sample!): Example.Droid.Common.TemplateSelectors.MultiItemTemplateModelTemplateSelector, Example.Droid";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
			}

            if (!typeof(IMvxItemUniqueIdProvider).IsAssignableFrom(type))
			{
                string message = $"Sorry but type: {type} does not implement {nameof(IMvxItemUniqueIdProvider)} interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
			}

			if (type.IsAbstract)
			{
				string message = $"Sorry can not instatiate {nameof(IMvxItemUniqueIdProvider)} as provided type: {type} is abstract/interface.";
                logger?.Log(LogLevel.Error, message);
                throw new InvalidOperationException(message);
			}

            var uniqueItemIdProvider = Activator.CreateInstance(type) as IMvxItemUniqueIdProvider;
			return uniqueItemIdProvider;
        }

        private static int[] MvxRecyclerViewGroupId { get; } = Resource.Styleable.MvxRecyclerView;
        private static int MvxRecyclerViewItemTemplateSelector { get; } = Resource.Styleable.MvxRecyclerView_MvxTemplateSelector;
        private static int MvxRecyclerViewGroupExpandController { get; } = Resource.Styleable.MvxRecyclerView_MvxGroupExpandController;
        private static int MvxRecyclerViewHeaderLayoutId { get; } = Resource.Styleable.MvxRecyclerView_MvxHeaderLayoutId;
        private static int MvxRecyclerViewFooterLayoutId { get; } = Resource.Styleable.MvxRecyclerView_MvxFooterLayoutId;
        public static int MvxRecyclerViewGroupedDataConverter { get; } = Resource.Styleable.MvxRecyclerView_MvxGroupedDataConverter;
        public static int MvxRecyclerViewSwipeableTemplate { get; } = Resource.Styleable.MvxRecyclerView_MvxSwipeableTemplate;
        public static int MvxRecyclerViewUniqueItemIdProvider { get; } = Resource.Styleable.MvxRecyclerView_MvxUniqueItemIdProvider;
        public static int MvxRecyclerViewGroupSwipeableTemplate { get; } = Resource.Styleable.MvxRecyclerView_MvxGroupSwipeableTemplate;
        public static int MvxRecyclerViewChildSwipeableTemplate { get; } = Resource.Styleable.MvxRecyclerView_MvxChildSwipeableTemplate;
    }
}
