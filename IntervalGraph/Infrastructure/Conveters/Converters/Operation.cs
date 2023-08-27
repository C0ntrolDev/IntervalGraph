using System;
using System.Globalization;
using IntervalGraph.Infrastructure.Conveters.Base;

namespace IntervalGraph.Infrastructure.Conveters.Converters
{
    public class Operation : MarkupConverter
    {
        public char? Operator { get; set; }
        public double OperatorNum { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double num = System.Convert.ToDouble(value);
            if (Operator == null) throw new InvalidOperationException("The operator for the converter is not specified");
            if (OperatorNum == 0) throw new InvalidOperationException("The number for the converter is not set correctly");

            return Calculate(num);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double resultOfCalculate = System.Convert.ToDouble(value);
            if (Operator == null) throw new InvalidOperationException("The operator for the converter is not specified");
            if (OperatorNum == 0) throw new InvalidOperationException("The number for the converter is not set correctly");

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

            throw new InvalidOperationException("The operator for the converter is not set correctly");
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

            throw new InvalidOperationException("The operator for the converter is not set correctly");
        }
    }
}
