using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace IntervalGraph.Infrastructure.Conveters.Base
{
    public abstract class MultiMarkupConverter : MarkupExtension, IMultiValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);
        public abstract object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);
    }
}
