using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace IntervalGraph.Components
{
    public class IntAxis : Freezable, INotifyPropertyChanged
    {
        private double _lastZoom = 1;

        #region Dependency properties

        #region Axis

        #region AxisColorBrushProperty

        public static readonly DependencyProperty AxisColorBrushProperty = DependencyProperty.Register(
            nameof(AxisColorBrush),
            typeof(Brush),
            typeof(IntAxis),
            new PropertyMetadata(Brushes.Black));

        public Brush AxisColorBrush
        {
            get => (Brush)GetValue(AxisColorBrushProperty);
            set => SetValue(AxisColorBrushProperty, value);
        }

        #endregion

        #region AxisThicknessProperty

        public static readonly DependencyProperty AxisThicknessProperty = DependencyProperty.Register(
            nameof(AxisThickness),
            typeof(double),
            typeof(IntAxis),
            new PropertyMetadata(2.0));

        public double AxisThickness
        {
            get => (double)GetValue(AxisThicknessProperty);
            set => SetValue(AxisThicknessProperty, value);
        }

        #endregion

        #region CirclesRadiusProperty

        public static readonly DependencyProperty CirclesRadiusProperty = DependencyProperty.Register(
            nameof(CirclesRadius),
            typeof(double),
            typeof(IntAxis),
            new PropertyMetadata(3.0));

        public double CirclesRadius
        {
            get => (double)GetValue(CirclesRadiusProperty);
            set => SetValue(CirclesRadiusProperty, value);
        }

        #endregion

        #region CirclesThicknessProperty

        public static readonly DependencyProperty CirclesThicknessProperty = DependencyProperty.Register(
            nameof(CirclesThickness),
            typeof(double),
            typeof(IntAxis),
            new PropertyMetadata(2.0));

        public double CirclesThickness
        {
            get => (double)GetValue(CirclesThicknessProperty);
            set => SetValue(CirclesThicknessProperty, value);
        }

        #endregion

        #endregion

        #region Text

        #region NumStepProperty

        public static readonly DependencyProperty NumStepProperty = DependencyProperty.Register(
            nameof(NumStep),
            typeof(int),
            typeof(IntAxis),
            new PropertyMetadata(1));

        public int NumStep
        {
            get => (int)GetValue(NumStepProperty);
            set => SetValue(NumStepProperty, value);
        }

        #endregion

        #region TextColorBrushProperty

        public static readonly DependencyProperty TextColorBrushProperty = DependencyProperty.Register(
            nameof(TextColorBrush),
            typeof(Brush),
            typeof(IntAxis),
            new PropertyMetadata(Brushes.Black));

        public Brush TextColorBrush
        {
            get => (Brush)GetValue(TextColorBrushProperty);
            set => SetValue(TextColorBrushProperty, value);
        }

        #endregion

        #region TextFormatProperty

        public static readonly DependencyProperty TextFormatProperty = DependencyProperty.Register(
            nameof(TextFormat),
            typeof(string),
            typeof(IntAxis),
            new PropertyMetadata("{0}"));

        public string TextFormat
        {
            get => (string)GetValue(TextFormatProperty);
            set => SetValue(TextFormatProperty, value);
        }

        #endregion

        #region FontSizeProperty

        public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(
            nameof(FontSize),
            typeof(double?),
            typeof(IntAxis),
            new PropertyMetadata(null));

        public double? FontSize
        {
            get => (double?)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        #endregion

        #region MinFontSizeProperty

        public static readonly DependencyProperty MinFontSizeProperty = DependencyProperty.Register(
            nameof(MinFontSize),
            typeof(double),
            typeof(IntAxis),
            new PropertyMetadata(15.0, UpdateTextFontSize));

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
            new PropertyMetadata(15.0, OnMaxFontSizeChanged));

        private static void OnMaxFontSizeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is IntAxis intAxis)
            {
                intAxis.UpdateTextFontSize(intAxis._lastZoom);
                intAxis.OnPropertyChanged(nameof(intAxis.TextContainerHeight));
            }
        }

        public double MaxFontSize
        {
            get => (double)GetValue(MaxFontSizeProperty);
            set => SetValue(MaxFontSizeProperty, value);
        }

        #endregion

        #region MinZoomProperty

        public static readonly DependencyProperty MinZoomProperty = DependencyProperty.Register(
            nameof(MinZoom),
            typeof(double),
            typeof(IntAxis),
            new PropertyMetadata(1.0, UpdateTextFontSize));

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
            new PropertyMetadata(1.0, UpdateTextFontSize));

        public double MaxZoom
        {
            get => (double)GetValue(MaxZoomProperty);
            set => SetValue(MaxZoomProperty, value);
        }

        #endregion

        #endregion



        #endregion


        #region DrawedFontSize

        private double _drawedFontSize;

        public double DrawedFontSize
        {
            get => _drawedFontSize;
            set => Set(ref _drawedFontSize, value);
        }

        #endregion

        #region TextContainerHeight

        public GridLength TextContainerHeight
        {
            get
            {
                if (FontSize != null) return new GridLength((double)FontSize * 1.5);
                return new GridLength(MaxFontSize * 1.5);
            }
        }

        #endregion


        private static void UpdateTextFontSize(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is IntAxis intAxis)
            {
                intAxis.UpdateTextFontSize(intAxis._lastZoom);
            }
        }
        public void UpdateTextFontSize(double zoom)
        {
            _lastZoom = zoom;

            if (FontSize != null)
            {
                DrawedFontSize = (double)FontSize;
                return;
            }

            if (zoom - MinZoom < 0)
            {
                DrawedFontSize = MinFontSize;
                return;
            }

            if (MaxZoom - zoom < 0)
            {
                DrawedFontSize = MaxFontSize;
                return;
            }

            double fontSizeRange = MaxFontSize - MinFontSize;
            double limitedZoom = zoom - MinZoom;
            double zoomRange = MaxZoom - MinZoom;
            
            DrawedFontSize = MinFontSize + (fontSizeRange * (limitedZoom / zoomRange));
        }



        protected override Freezable CreateInstanceCore() => new IntAxis();



        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
