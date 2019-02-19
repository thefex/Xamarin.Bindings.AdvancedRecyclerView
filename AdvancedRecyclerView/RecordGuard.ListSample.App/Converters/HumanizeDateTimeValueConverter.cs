using System;
using System.Globalization;
using Humanizer;
using MvvmCross.Converters;

namespace RecordGuard.ListSample.App.Converters
{
    public class HumanizeDateTimeValueConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Humanize();
        }
    }
}