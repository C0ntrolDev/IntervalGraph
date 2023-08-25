using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using IntervalGraph.Models.Graph;

namespace IntervalGraph.Components
{
    /// <summary>
    /// Логика взаимодействия для OldIntervalGraph.xaml
    /// </summary>

    public partial class OldIntervalGraph : UserControl
    {
        #region MainGraphProperties

        #region MinValueProperty

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            nameof(MinValue),
            typeof(int),
            typeof(OldIntervalGraph),
            new PropertyMetadata(default(int)));

        public int MinValue
        {
            get => (int)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        #endregion

        #region MaxValueProperty

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            nameof(MaxValue),
            typeof(int),
            typeof(OldIntervalGraph),
            new PropertyMetadata(default(int)));

        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        #endregion

        #region ZoomProperty

        public static readonly DependencyProperty ZoomProperty = DependencyProperty.Register(
            nameof(Zoom),
            typeof(double),
            typeof(OldIntervalGraph),
            new PropertyMetadata(1.0,OnZoomChanged));

        private static void OnZoomChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            sender.SetValue(ColumnWidthProperty, 100 * (double)e.NewValue);

            double proportionalAboutHeigthFontSize = Math.Min(((double)e.NewValue - 1) / (double)sender.GetValue(MaximumTextZoomProperty), 1);

            double maxFontSize = (double)sender.GetValue(MaxHorizontalFontSizeProperty);
            double minFontSize = (double)sender.GetValue(MinHorizontalFontSizeProperty);

            proportionalAboutHeigthFontSize *= (maxFontSize - minFontSize);
            proportionalAboutHeigthFontSize += minFontSize;

            int fontSize = (int)(proportionalAboutHeigthFontSize * ((OldIntervalGraph)sender).ActualGraphHeigth);

            sender.SetValue(ActualHorizontalFontSizeProperty, fontSize);
        }

        public double Zoom
        {
            get => (double)GetValue(ZoomProperty);
            set => SetValue(ZoomProperty, value);
        }

        #endregion

        #region StepProperty

        public static readonly DependencyProperty StepProperty = DependencyProperty.Register(
            nameof(Step),
            typeof(int),
            typeof(OldIntervalGraph),
            new PropertyMetadata(1));

        public int Step
        {
            get => (int)GetValue(StepProperty);
            set => SetValue(StepProperty, value);
        }

        #endregion

        #region ColumnWidthProperty

        public static readonly DependencyProperty ColumnWidthProperty = DependencyProperty.Register(
            nameof(ColumnWidth),
            typeof(double),
            typeof(OldIntervalGraph),
            new PropertyMetadata(100.0));

        public double ColumnWidth
        {
            get => (double)GetValue(ColumnWidthProperty);
        }

        #endregion

        public double ActualGraphHeigth => GraphCanvas.Height;
        public int ColumnsCount => MaxValue - MinValue - 1;

        #endregion

        #region TextScalingProperties

        #region MinHorizontalFontSizeProperty

        public static readonly DependencyProperty MinHorizontalFontSizeProperty = DependencyProperty.Register(
            nameof(MinHorizontalFontSize),
            typeof(double),
            typeof(OldIntervalGraph),
            new PropertyMetadata(0.01));

        public double MinHorizontalFontSize
        {
            get => (double)GetValue(MinHorizontalFontSizeProperty);
            set => SetValue(MinHorizontalFontSizeProperty, value);
        }

        #endregion

        #region MaxHorizontalFontSizeProperty

        public static readonly DependencyProperty MaxHorizontalFontSizeProperty = DependencyProperty.Register(
            nameof(MaxHorizontalFontSize),
            typeof(double),
            typeof(OldIntervalGraph),
            new PropertyMetadata(0.1));

        public double MaxHorizontalFontSize
        {
            get => (double)GetValue(MaxHorizontalFontSizeProperty);
            set => SetValue(MaxHorizontalFontSizeProperty, value);
        }

        #endregion

        #region MaximumTextZoomProperty

        public static readonly DependencyProperty MaximumTextZoomProperty = DependencyProperty.Register(
            nameof(MaximumTextZoom),
            typeof(double),
            typeof(OldIntervalGraph),
            new PropertyMetadata(2.0));

        public double MaximumTextZoom
        {
            get => (double)GetValue(MaximumTextZoomProperty);
            set => SetValue(MaximumTextZoomProperty, value);
        }

        #endregion

        #region ActualHorizontalFontSizeProperty

        public static readonly DependencyProperty ActualHorizontalFontSizeProperty = DependencyProperty.Register(
            nameof(ActualHorizontalFontSize),
            typeof(int),
            typeof(OldIntervalGraph),
            new PropertyMetadata(100));

        public int ActualHorizontalFontSize
        {
            get => (int)GetValue(ActualHorizontalFontSizeProperty);
        }

        #endregion

        #endregion

        #region DesignProperies

        #region MajorBrushProperty

        public static readonly DependencyProperty MajorBrushProperty = DependencyProperty.Register(
            nameof(MajorBrush),
            typeof(Brush),
            typeof(OldIntervalGraph),
            new PropertyMetadata(Brushes.Black));

        public Brush MajorBrush
        {
            get => (Brush)GetValue(MajorBrushProperty);
            set => SetValue(MajorBrushProperty, value);
        }

        #endregion

        #region MinorBrushProperty

        public static readonly DependencyProperty MinorBrushProperty = DependencyProperty.Register(
            nameof(MinorBrush),
            typeof(Brush),
            typeof(OldIntervalGraph),
            new PropertyMetadata(Brushes.Black));

        public Brush MinorBrush
        {
            get => (Brush)GetValue(MinorBrushProperty);
            set => SetValue(MinorBrushProperty, value);
        }

        #endregion

        #region GraphBorderBrushProperty

        public static readonly DependencyProperty GraphBorderBrushProperty = DependencyProperty.Register(
            nameof(GraphBorderBrush),
            typeof(Brush),
            typeof(OldIntervalGraph),
            new PropertyMetadata(Brushes.Black));

        public Brush GraphBorderBrush
        {
            get => (Brush)GetValue(GraphBorderBrushProperty);
            set => SetValue(GraphBorderBrushProperty, value);
        }

        #endregion

        #endregion

        #region IntervalsProperty

        public static readonly DependencyProperty GraphIntervalsProperty = DependencyProperty.Register(
            nameof(GraphIntervals),
            typeof(ObservableCollection<GraphInterval>),
            typeof(OldIntervalGraph),
            new PropertyMetadata(null));

        public ObservableCollection<GraphInterval> GraphIntervals
        {
            get { return (ObservableCollection<GraphInterval>)GetValue(GraphIntervalsProperty); }
            set { SetValue(GraphIntervalsProperty, value); }
        }

        #endregion

        public OldIntervalGraph()
        {
            InitializeComponent();
        }
    }
}
