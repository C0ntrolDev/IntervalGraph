using System;
using System.Globalization;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.GraphConverters.Converters
{
    public class Operation : MarkupConverter
    {
        public char? Operator { get; set; }
        public int OperatorNum { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double num = System.Convert.ToDouble(value);
            if (Operator == null) throw new InvalidOperationException("Не задан оператор для конвертера");
            if (OperatorNum == 0) throw new InvalidOperationException("Число для конвертатора задано не верно");

            return Calculate(num);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double resultOfCalculate = System.Convert.ToDouble(value);
            if (Operator == null) throw new InvalidOperationException("Не задан оператор для конвертера");
            if (OperatorNum == 0) throw new InvalidOperationException("Число для конвертатора задано не верно");

            return UnCalculate(resultOfCalculate);
        }

        private double Calculate(double num)
        {
            switch (Operator)
            {
                case '+': return num + OperatorNum;
                case '-': return num - OperatorNum;
                case '*': return num * OperatorNum;
                case '/': return num / OperatorNum;
                case '%': return num % OperatorNum;
            }

            throw new InvalidOperationException("Не верно задан оператор для конвертера");
        }

        private double UnCalculate(double resultOfCalculate)
        {
            switch (Operator)
            {
                case '+': return resultOfCalculate - OperatorNum;
                case '-': return resultOfCalculate + OperatorNum;
                case '*': return resultOfCalculate / OperatorNum;
                case '/': return resultOfCalculate * OperatorNum;
                case '%': return resultOfCalculate * OperatorNum;
            }

            throw new InvalidOperationException("Не верно задан оператор для конвертера");
        }
    }
}
