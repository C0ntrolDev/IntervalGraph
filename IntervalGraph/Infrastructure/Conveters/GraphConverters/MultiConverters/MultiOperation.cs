using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.MultiConverters
{
    internal class MultiOperation : MultiMarkupConverter
    {
        public char? FirstOperator { get; set; }
        public char? SecondOperator { get; set; }
        public char? ThrirdOperator { get; set; }


        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(v => v == DependencyProperty.UnsetValue)) return null;

            if (values.Length < 2) throw new InvalidOperationException("Задано неверное количество чисел для вычесления. Шаблон: 1_число, 2_число, 3_число(необязательно)");
            if (FirstOperator == null) throw new InvalidOperationException("Не задан первый оператор для конвертера");

            double num = System.Convert.ToDouble(values[0]);
            double operatorNum = System.Convert.ToDouble(values[1]);


            double firstResult = Calculate(num, operatorNum, (char)FirstOperator);
            double secondResult;

            if (SecondOperator != null)
            {
                double secondOperatorNum = System.Convert.ToDouble(values[2]);
                secondResult = Calculate(firstResult, secondOperatorNum, (char)SecondOperator);
            }
            else
            {
                return firstResult;
            }

            if (ThrirdOperator != null)
            {
                double thirdOperatorNum = System.Convert.ToDouble(values[3]);
                return Calculate(secondResult, thirdOperatorNum, (char)SecondOperator);
            }
            else
            {
                return secondResult;
            }
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new InvalidOperationException("В данном конвертера обратные преобразования не допустимы");

        private double Calculate(double num, double operatorNum, char Operator)
        {
            switch (Operator)
            {
                case '+': return num + operatorNum;
                case '-': return num - operatorNum;
                case '*': return num * operatorNum;
                case '/': return num / operatorNum;
                case '%': return num % operatorNum;
                case 'L': return num > operatorNum ? num : operatorNum;
                case 'S': return num < operatorNum ? num : operatorNum;
            }

            throw new InvalidOperationException("Не верно задан оператор для конвертера");
        }
    }
}
