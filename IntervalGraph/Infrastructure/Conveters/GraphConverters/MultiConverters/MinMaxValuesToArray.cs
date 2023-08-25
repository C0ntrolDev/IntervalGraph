using System;
using System.Globalization;
using System.Linq;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.MultiConverters
{
    class MinMaxValuesToArray : MultiMarkupConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            if (values.Length < 2) throw new InvalidOperationException("Задано неверное количество параметров. Шаблон: Мин_знач, Макс_знач, Шаг(необязательно) ");
            int minValue = System.Convert.ToInt32(values[0]);
            int maxValue = System.Convert.ToInt32(values[1]);

            int[] arr = Enumerable.Range(minValue, Math.Abs(maxValue - minValue)).ToArray();

            if (values.Length >= 3)
            {
                int step = System.Convert.ToInt32(values[2]);
                arr = arr.Where(i => i % step == 0).ToArray();
            }

            return arr;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new InvalidOperationException("В данном конвертера обратные преобразования не допустимы");
    }
}
