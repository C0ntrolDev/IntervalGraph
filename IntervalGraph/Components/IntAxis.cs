using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace IntervalGraph.Components
{
    public class IntAxis : DependencyObject
    {
        #region AxisColorBrushProperty

        public static readonly DependencyProperty AxisColorBrushProperty = DependencyProperty.Register(
            nameof(AxisColorBrush),
            typeof(Brush),
            typeof(IntAxis),
            new PropertyMetadata(default(Brush)));

        public Brush AxisColorBrush
        {
            get => (Brush)GetValue(AxisColorBrushProperty);
            set => SetValue(AxisColorBrushProperty, value);
        }

        #endregion

        #region AxisThicknessProperty

        public static readonly DependencyProperty AxisThicknessProperty = DependencyProperty.Register(
            nameof(AxisThickness),
            typeof(int),
            typeof(IntAxis),
            new PropertyMetadata(default(int)));

        public int AxisThickness
        {
            get => (int)GetValue(AxisThicknessProperty);
            set => SetValue(AxisThicknessProperty, value);
        }

        #endregion

        #region NumStepProperty

        public static readonly DependencyProperty NumStepProperty = DependencyProperty.Register(
            nameof(NumStep),
            typeof(int),
            typeof(IntAxis),
            new PropertyMetadata(default(int)));

        public int NumStep
        {
            get => (int)GetValue(NumStepProperty);
            set => SetValue(NumStepProperty, value);
        }

        #endregion

        #region MinFontSizeProperty

        public static readonly DependencyProperty MinFontSizeProperty = DependencyProperty.Register(
            nameof(MinFontSize),
            typeof(double),
            typeof(IntAxis),
            new PropertyMetadata(default(double)));

        public double MinFontSize
        {
            get => (double)GetValue(MinFontSizeProperty);
            set => SetValue(MinFontSizeProperty, value);
        }

        #endregion

        #region MaxFontSizeProperty

        public static readonly DependencyProperty MaxFontSizeProperty = DependencyProperty.Register(
            nameof(MaxFontSize),
            typeof(double),
            typeof(IntAxis),
            new PropertyMetadata(default(double)));

        public double MaxFontSize
        {
            get => (double)GetValue(MaxFontSizeProperty);
            set => SetValue(MaxFontSizeProperty, value);
        }

        #endregion

        #region TextBrushProperty

        public static readonly DependencyProperty TextBrushProperty = DependencyProperty.Register(
            nameof(TextBrush),
            typeof(Brush),
            typeof(IntAxis),
            new PropertyMetadata(default(Brush)));

        public Brush TextBrush
        {
            get => (Brush)GetValue(TextBrushProperty);
            set => SetValue(TextBrushProperty, value);
        }

        #endregion

        #region TextFormatProperty

        public static readonly DependencyProperty TextFormatProperty = DependencyProperty.Register(
            nameof(TextFormat),
            typeof(string),
            typeof(IntAxis),
            new PropertyMetadata(default(string)));

        public string TextFormat
        {
            get => (string)GetValue(TextFormatProperty);
            set => SetValue(TextFormatProperty, value);
        }

        #endregion

        #region MinZoomProperty

        public static readonly DependencyProperty MinZoomProperty = DependencyProperty.Register(
            nameof(MinZoom),
            typeof(double),
            typeof(IntAxis),
            new PropertyMetadata(default(double)));

        public double MinZoom
        {
            get => (double)GetValue(MinZoomProperty);
            set => SetValue(MinZoomProperty, value);
        }

        #endregion

        #region MaxZoomProperty

        public static readonly DependencyProperty MaxZoomProperty = DependencyProperty.Register(
            nameof(MaxZoom),
            typeof(double),
            typeof(IntAxis),
            new PropertyMetadata(default(double)));

        public double MaxZoom
        {
            get => (double)GetValue(MaxZoomProperty);
            set => SetValue(MaxZoomProperty, value);
        }

        #endregion
    }
}
