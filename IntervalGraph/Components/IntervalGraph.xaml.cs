using IntervalGraph.Models.Graph;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IntervalGraph.Components
{
    /// <summary>
    /// Логика взаимодействия для IntervalGraph.xaml
    /// </summary>
    public partial class IntervalGraph : UserControl, INotifyPropertyChanged
    {
        #region Parts

        #region IntAxisProperty

        public static readonly DependencyProperty IntAxisProperty = DependencyProperty.Register(
            nameof(IntAxis),
            typeof(IntAxis),
            typeof(IntervalGraph),
            new PropertyMetadata(new IntAxis()));

        public IntAxis IntAxis
        {
            get => (IntAxis)GetValue(IntAxisProperty);
            set => SetValue(IntAxisProperty, value);
        }

        #endregion

        #region LegendProperty

        public static readonly DependencyProperty LegendProperty = DependencyProperty.Register(
            nameof(Legend),
            typeof(Legend),
            typeof(IntervalGraph),
            new PropertyMetadata(new Legend()));

        public Legend Legend
        {
            get => (Legend)GetValue(LegendProperty);
            set => SetValue(LegendProperty, value);
        }

        #endregion

        #endregion

        #region DependencyProperties

        #region MainProperties

        #region MinValueProperty

        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
            nameof(MinValue),
            typeof(int?),
            typeof(IntervalGraph),
            new PropertyMetadata(null, OnMinValueChanged));

        private static void OnMinValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is IntervalGraph intervalGraph) intervalGraph.AdaptGraphToNewValues();
        }

        public int? MinValue
        {
            get => (int?)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        #endregion

        #region MaxValueProperty

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
            nameof(MaxValue),
            typeof(int?),
            typeof(IntervalGraph),
            new PropertyMetadata(null, OnMaxValueChanged));

        private static void OnMaxValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is IntervalGraph intervalGraph) intervalGraph.AdaptGraphToNewValues();
        }

        public int? MaxValue
        {
            get => (int?)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        #endregion

        #region MaxZoomProperty

        public static readonly DependencyProperty MaxZoomProperty = DependencyProperty.Register(
            nameof(MaxZoom),
            typeof(double?),
            typeof(IntervalGraph),
            new PropertyMetadata(null, OnMaxZoomChanged));

        private static void OnMaxZoomChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is IntervalGraph intervalGraph)
            {
                if (e.NewValue != null)
                {
                    if (intervalGraph.Zoom > (double)e.NewValue)
                    {
                        intervalGraph.Zoom = (double)e.NewValue;
                    }
                }

            }
        }

        public double? MaxZoom
        {
            get => (double?)GetValue(MaxZoomProperty);
            set => SetValue(MaxZoomProperty, value);
        }

        #endregion

        #region GraphIntervalsProperty

        public static readonly DependencyProperty GraphIntervalsProperty = DependencyProperty.Register(
            nameof(GraphIntervals),
            typeof(ObservableCollection<GraphInterval>),
            typeof(IntervalGraph),
            new PropertyMetadata(null, OnGraphIntervalsChanged));

        private static void OnGraphIntervalsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is IntervalGraph intervalGraph && 
                e.NewValue is ObservableCollection<GraphInterval> graphIntervals)
            {
                graphIntervals.CollectionChanged += (s, e) => intervalGraph.AdaptGraphToNewValues();
                intervalGraph.AdaptGraphToNewValues();
            }
        }

        public ObservableCollection<GraphInterval> GraphIntervals
        {
            get => (ObservableCollection<GraphInterval>)GetValue(GraphIntervalsProperty);
            set => SetValue(GraphIntervalsProperty, value);
        }

        #endregion

        #region ZoomProperty

        public static readonly DependencyProperty ZoomProperty = DependencyProperty.Register(
            nameof(Zoom),
            typeof(double),
            typeof(IntervalGraph),
            new FrameworkPropertyMetadata(1.0, OnZoomChanged, OnCoerceZoom));

        private static void OnZoomChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is IntervalGraph intervalGraph)
            {
                intervalGraph.UpdateZoomedGraphWidth();
            }

        }
        private static object OnCoerceZoom(DependencyObject dependencyObject, object basevalue)
        {
            if (dependencyObject is IntervalGraph intervalGraph)
            {
                if (intervalGraph.MaxZoom != null)
                {
                    if ((double)basevalue > intervalGraph.MaxZoom)
                    {
                        return intervalGraph.MaxZoom;
                    }
                }
            }

            return basevalue;
        }

        public double Zoom
        {
            get => (double)GetValue(ZoomProperty);
            set => SetValue(ZoomProperty, value);
        }

        #endregion

        #endregion

        #region DesignProperties

        #region MajorColorBrushProperty

        public static readonly DependencyProperty MajorColorBrushProperty = DependencyProperty.Register(
            nameof(MajorColorBrush),
            typeof(Brush),
            typeof(IntervalGraph),
            new PropertyMetadata(default(Brush)));

        public Brush MajorColorBrush
        {
            get => (Brush)GetValue(MajorColorBrushProperty);
            set => SetValue(MajorColorBrushProperty, value);
        }

        #endregion

        #region MinorColorBrushProperty

        public static readonly DependencyProperty MinorColorBrushProperty = DependencyProperty.Register(
            nameof(MinorColorBrush),
            typeof(Brush),
            typeof(IntervalGraph),
            new PropertyMetadata(default(Brush)));

        public Brush MinorColorBrush
        {
            get => (Brush)GetValue(MinorColorBrushProperty);
            set => SetValue(MinorColorBrushProperty, value);
        }

        #endregion

        #region MajorThicknessProperty

        public static readonly DependencyProperty MajorThicknessProperty = DependencyProperty.Register(
            nameof(MajorThickness),
            typeof(double),
            typeof(IntervalGraph),
            new PropertyMetadata(default(double)));

        public double MajorThickness
        {
            get => (double)GetValue(MajorThicknessProperty);
            set => SetValue(MajorThicknessProperty, value);
        }

        #endregion

        #region MinorThicknessProperty

        public static readonly DependencyProperty MinorThicknessProperty = DependencyProperty.Register(
            nameof(MinorThickness),
            typeof(double),
            typeof(IntervalGraph),
            new PropertyMetadata(default(double)));

        public double MinorThickness
        {
            get => (double)GetValue(MinorThicknessProperty);
            set => SetValue(MinorThicknessProperty, value);
        }

        #endregion

        #region MajorStepProperty

        public static readonly DependencyProperty MajorStepProperty = DependencyProperty.Register(
            nameof(MajorStep),
            typeof(int),
            typeof(IntervalGraph),
            new PropertyMetadata(default(int)));

        public int MajorStep
        {
            get => (int)GetValue(MajorStepProperty);
            set => SetValue(MajorStepProperty, value);
        }

        #endregion

        #region MinorStepProperty

        public static readonly DependencyProperty MinorStepProperty = DependencyProperty.Register(
            nameof(MinorStep),
            typeof(int),
            typeof(IntervalGraph),
            new PropertyMetadata(default(int)));

        public int MinorStep
        {
            get => (int)GetValue(MinorStepProperty);
            set => SetValue(MinorStepProperty, value);
        }

        #endregion


        #region IsIntervalHeightDependToWidthProperty

        public static readonly DependencyProperty IsIntervalHeightDependToWidthProperty = DependencyProperty.Register(
            nameof(IsIntervalHeightDependToWidth),
            typeof(bool),
            typeof(IntervalGraph),
            new PropertyMetadata(default(bool)));

        /// <summary>
        /// Will the height of the displayed graph depend on its length (longer => higher)
        /// </summary>
        public bool IsIntervalHeightDependToWidth
        {
            get => (bool)GetValue(IsIntervalHeightDependToWidthProperty);
            set => SetValue(IsIntervalHeightDependToWidthProperty, value);
        }

        #endregion

        #region MaxStableIntervalHeightProperty

        public static readonly DependencyProperty MaxStableIntervalHeightProperty = DependencyProperty.Register(
            nameof(MaxStableIntervalHeight),
            typeof(double),
            typeof(IntervalGraph),
            new PropertyMetadata(0.5));

        /// <summary>
        /// The minimum height of the graph, which will be necessarily reached. Calculated relative to MaxIntervalHeight.
        /// Set from 0 to 1.
        /// If the value is less than 1, the remaining distance will be calculated relative to the width of the interval
        /// </summary>
        public double MaxStableIntervalHeight
        {
            get => (double)GetValue(MaxStableIntervalHeightProperty);
            set => SetValue(MaxStableIntervalHeightProperty, value);
        }

        #endregion

        #region MaxIntervalHeightProperty

        public static readonly DependencyProperty MaxIntervalHeightProperty = DependencyProperty.Register(
            nameof(MaxIntervalHeight),
            typeof(double),
            typeof(IntervalGraph),
            new PropertyMetadata(0.7));

        /// <summary>
        /// Calculated relative to the height of the graph (from 0 to 1)
        /// </summary>
        public double MaxIntervalHeight
        {
            get => (double)GetValue(MaxIntervalHeightProperty);
            set => SetValue(MaxIntervalHeightProperty, value);
        }

        #endregion

        #endregion

        #endregion

        #region Properties

        #region DrawedMinValue

        private int _drawedMinValue;

        public int DrawedMinValue
        {
            get => _drawedMinValue;
            set
            {
                Set(ref _drawedMinValue, value);
                if (DrawedMinValue < DrawedMaxValue)
                {
                    OnPropertyChanged(nameof(AxisValues));
                }
               
            }
        }

        #endregion

        #region DrawedMaxValue

        private int _drawedMaxValue;

        public int DrawedMaxValue
        {
            get => _drawedMaxValue;
            set
            {
                Set(ref _drawedMaxValue, value);
                if (DrawedMinValue < DrawedMaxValue)
                {
                    OnPropertyChanged(nameof(AxisValues));
                }
            }
        }

        #endregion

        public int ColumnCount => DrawedMaxValue - DrawedMinValue + 1;
        public IEnumerable<int?> AxisValues => Enumerable.Range(DrawedMinValue, ColumnCount).Select(i => (int?)i).Append(null);

        #region ColumnWidth

        private double _columnWidth;

        public double ColumnWidth
        {
            get => _columnWidth;
            set => Set(ref _columnWidth, value);
        }

        #endregion

        #region GraphWidth

        private double _startGraphWidth;
        private double _graphWidth;

        public double GraphWidth
        {
            get => _graphWidth;
            set
            {
                Set(ref _graphWidth, value);

                if (_startGraphWidth == 0 && value is not 0 or Double.NaN)
                {
                    _startGraphWidth = value;
                }

                UpdateZoomedGraphWidth();
            }
        }

        #endregion

        #region ZoomedGraphWidth

        private double _zoomedGraphWidth;

        public double ZoomedGraphWidth
        {
            get => _zoomedGraphWidth;
            set
            {
                Set(ref _zoomedGraphWidth, value);
                UpdateColumnWidth();
            }
        }

        #endregion

        #region AxisHeight

        private double _axisHeight;

        public double AxisHeight
        {
            get => _axisHeight;
            set
            {
                Set(ref _axisHeight, value);
                OnPropertyChanged(nameof(GraphHeight));
            }
        }

        #endregion

        #region UpperGraphHeight

        private double _upperGraphHeight;

        public double UpperGraphHeight
        {
            get => _upperGraphHeight;
            set
            {
                Set(ref _upperGraphHeight, value);
                OnPropertyChanged(nameof(GraphHeight));
            }
        }

        #endregion

        public double GraphHeight => AxisHeight + UpperGraphHeight;

        #endregion


        public IntervalGraph()
        {
            InitializeComponent();
        }



        private void AdaptGraphToNewValues()
        {
            if (GraphIntervals != null && GraphIntervals.Count != 0)
            {
                List<int> AllPoints = GraphIntervals
                    .Select(gi => new int?[] { gi.Interval?.FirstPoint?.X, gi.Interval?.LastPoint?.X })
                    .SelectMany(ip => ip)
                    .Where(p => p != null)
                    .Select(p => (int)p)
                    .ToList();

                int newMinValue = AllPoints.Min();
                int newMaxValue = AllPoints.Max();

                if (MinValue == null || MinValue > newMinValue)
                {
                    DrawedMinValue = newMinValue;
                    UpdateColumnWidth();
                }

                if (MaxValue == null || MaxValue < newMaxValue)
                {
                    DrawedMaxValue = newMaxValue;
                    UpdateColumnWidth();
                }
            }
            else
            {
                if (MinValue != null)
                {
                    DrawedMinValue = (int)MinValue;
                }

                if (MaxValue != null)
                {
                    DrawedMaxValue = (int)MaxValue;
                }

                UpdateColumnWidth();
            }
        }

        private void UpdateZoomedGraphWidth()
        {
            if (Zoom * _startGraphWidth < GraphWidth)
            {
                if (MaxZoom != null && _startGraphWidth * MaxZoom < GraphWidth)
                {
                    ZoomedGraphWidth = _startGraphWidth * (double)MaxZoom;
                }
                else
                {
                    ZoomedGraphWidth = GraphWidth;
                }

            }
            else
            {
                ZoomedGraphWidth = Zoom * _startGraphWidth;
            }
        }

        private void UpdateColumnWidth()
        {
            ColumnWidth = ZoomedGraphWidth / ColumnCount;
        }




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
