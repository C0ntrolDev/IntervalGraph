using IntervalGraph.Models.Graph;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public partial class IntervalGraph : UserControl
    {
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
            new PropertyMetadata(null,OnMaxValueChanged));

        private static void OnMaxValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if(dependencyObject is IntervalGraph intervalGraph) intervalGraph.AdaptGraphToNewValues();
        }

        public int? MaxValue
        {
            get => (int?)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        #endregion

        #region DrawedMinValueProperty

        public static readonly DependencyProperty DrawedMinValueProperty = DependencyProperty.Register(
            nameof(DrawedMinValue),
            typeof(int),
            typeof(IntervalGraph),
            new PropertyMetadata(default(int)));

        public int DrawedMinValue
        {
            get => (int)GetValue(DrawedMinValueProperty);
            private set => SetValue(DrawedMinValueProperty, value);
        }

        #endregion

        #region DrawedMaxValueProperty

        public static readonly DependencyProperty DrawedMaxValueProperty = DependencyProperty.Register(
            nameof(DrawedMaxValue),
            typeof(int),
            typeof(IntervalGraph),
            new PropertyMetadata(default(int)));

        public int DrawedMaxValue
        {
            get => (int)GetValue(DrawedMaxValueProperty);
            private set => SetValue(DrawedMaxValueProperty, value);
        }

        #endregion

        public int ColumnCount => DrawedMaxValue - DrawedMinValue;

        #region ColumnWidthProperty

        public static readonly DependencyProperty ColumnWidthProperty = DependencyProperty.Register(
            nameof(ColumnWidth),
            typeof(double),
            typeof(IntervalGraph),
            new PropertyMetadata(default(double)));

        public double ColumnWidth
        {
            get => (double)GetValue(ColumnWidthProperty);
            private set => SetValue(ColumnWidthProperty, value);
        }

        #endregion

        #region GraphHeigthProperty

        public static readonly DependencyProperty GraphHeigthProperty = DependencyProperty.Register(
            nameof(GraphHeigth),
            typeof(double),
            typeof(IntervalGraph),
            new PropertyMetadata(default(double)));

        public double GraphHeigth
        {
            get => (double)GetValue(GraphHeigthProperty);
            set => SetValue(GraphHeigthProperty, value);
        }

        #endregion

        #region GraphWidthProperty

        private double _startGraphWidth;

        public static readonly DependencyProperty GraphWidthProperty = DependencyProperty.Register(
            nameof(GraphWidth),
            typeof(double),
            typeof(IntervalGraph),
            new PropertyMetadata(default(double), OnGraphWidthChanged, OnCoerceGraphWidth));

        private static void OnGraphWidthChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is IntervalGraph intervalGraph) intervalGraph.UpdateZoomedGraphWidth();
        }

        private static object OnCoerceGraphWidth(DependencyObject dependencyObject, object basevalue)
        {
            if (dependencyObject is IntervalGraph intervalGraph)
            {
                if (intervalGraph._startGraphWidth != 0)
                {
                    if ((double)basevalue >= intervalGraph._startGraphWidth)
                    {
                        return intervalGraph._startGraphWidth;
                    }

                    return basevalue;
                }
                else
                {
                    if ((double)basevalue is not 0 or Double.NaN )
                    {
                        intervalGraph._startGraphWidth = (double)basevalue;
                    }
                }
            }

            return basevalue;
        }

        public double GraphWidth
        {
            get => (double)GetValue(GraphWidthProperty);
            set => SetValue(GraphWidthProperty, value);
        }

        #endregion

        #region ZoomedGraphWidthProperty

        public static readonly DependencyProperty ZoomedGraphWidthProperty = DependencyProperty.Register(
            nameof(ZoomedGraphWidth),
            typeof(double),
            typeof(IntervalGraph),
            new PropertyMetadata(default(double), OmZoomedWidthChanged));

        private static void OmZoomedWidthChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is IntervalGraph intervalGraph) intervalGraph.UpdateColumnWidth();
        }

        public double ZoomedGraphWidth
        {
            get => (double)GetValue(ZoomedGraphWidthProperty);
            private set => SetValue(ZoomedGraphWidthProperty, value);
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
            if (dependencyObject is IntervalGraph intervalGraph) intervalGraph.UpdateZoomedGraphWidth();
        }
        private static object OnCoerceZoom(DependencyObject dependencyObject, object basevalue)
        {
            if (dependencyObject is IntervalGraph intervalGraph)
            {
                if ((double)basevalue > intervalGraph.MaxZoom)
                {
                    return intervalGraph.MaxZoom;
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

        #region MaxZoomProperty

        public static readonly DependencyProperty MaxZoomProperty = DependencyProperty.Register(
            nameof(MaxZoom),
            typeof(double),
            typeof(IntervalGraph),
            new PropertyMetadata(1.0, OnMaxZoomChanged));

        private static void OnMaxZoomChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is IntervalGraph intervalGraph)
            {
                if (intervalGraph.Zoom > (double)e.NewValue)
                {
                    intervalGraph.Zoom = (double)e.NewValue;
                }
            } 
        }

        public double MaxZoom
        {
            get => (double)GetValue(MaxZoomProperty);
            set => SetValue(MaxZoomProperty, value);
        }

        #endregion

        #region MaxIntervalHeightProperty

        public static readonly DependencyProperty MaxIntervalHeightProperty = DependencyProperty.Register(
            nameof(MaxIntervalHeight),
            typeof(double),
            typeof(IntervalGraph),
            new PropertyMetadata(default(double)));

        /// <summary>
        /// Calculated relative to the height of the graph (from 0 to 1)
        /// </summary>
        public double MaxIntervalHeight
        {
            get => (double)GetValue(MaxIntervalHeightProperty);
            set => SetValue(MaxIntervalHeightProperty, value);
        }

        #endregion

        #region GraphIntervalsProperty

        public static readonly DependencyProperty GraphIntervalsProperty = DependencyProperty.Register(
            nameof(GraphIntervals),
            typeof(ObservableCollection<GraphInterval>),
            typeof(IntervalGraph),
            new PropertyMetadata(null));

        public ObservableCollection<GraphInterval> GraphIntervals
        {
            get { return (ObservableCollection<GraphInterval>)GetValue(GraphIntervalsProperty); }
            set { SetValue(GraphIntervalsProperty, value); }
        }

        #endregion



        public IntervalGraph()
        {
            InitializeComponent();
            AdaptGraphToNewValues();
        }

        private void AdaptGraphToNewValues()
        {
            if (GraphIntervals != null && GraphIntervals.Count != 0)
            {
                List<int> AllPoints = GraphIntervals
                    .Select(gi => new int?[] { gi.Interval?.FirstPoint.X, gi.Interval?.LastPoint.X })
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
        }

        private void UpdateZoomedGraphWidth()
        {
            ZoomedGraphWidth = GraphWidth * Zoom;
        }

        private void UpdateColumnWidth()
        {
            ColumnWidth = ZoomedGraphWidth / ColumnCount;
        }
    }

}
