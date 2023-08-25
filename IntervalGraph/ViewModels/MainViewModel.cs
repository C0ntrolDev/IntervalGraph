using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using IntervalGraph.Models.Graph;
using IntervalGraph.ViewModels.Base;

namespace IntervalGraph.ViewModels
{
    class MainViewModel : ViewModel
    {
        #region GraphIntervals

        private ObservableCollection<GraphInterval> _graphIntervals;

        public ObservableCollection<GraphInterval> GraphIntervals
        {
            get => _graphIntervals;
            set => Set(ref _graphIntervals, value);
        }

        #endregion

        public MainViewModel()
        {
            List<GraphInterval> intervals = new List<GraphInterval>()
            {
                new GraphInterval()
                {
                    Interval = new Interval()
                    {
                        FirstPoint = new IntervalPoint<int>()
                        {
                            X = 0
                        },

                        LastPoint = new IntervalPoint<int>()
                        {
                            X = 32
                        }
                    },

                    StrokeBrush = Brushes.Blue,
                    FillBrush = new SolidColorBrush(Color.FromArgb(30,0,0,255))
                },

                new GraphInterval()
                {
                    Interval = new Interval()
                    {
                        FirstPoint = new IntervalPoint<int>()
                        {
                            X = 10
                        },

                        LastPoint = new IntervalPoint<int>()
                        {
                            X = 48
                        }
                    },

                    StrokeBrush = new SolidColorBrush(Color.FromArgb(255,228,0,255)),
                    FillBrush = new SolidColorBrush(Color.FromArgb(30,228,0,255))
                },

                new GraphInterval()
                {
                    Interval = new Interval()
                    {
                        FirstPoint = new IntervalPoint<int>()
                        {
                            X = 5
                        },

                        LastPoint = new IntervalPoint<int>()
                        {
                            X = 27
                        }
                    },

                    StrokeBrush = Brushes.Green,
                    FillBrush = new SolidColorBrush(Color.FromArgb(30,0,255,0))
                },

                new GraphInterval()
                {
                    Interval = new Interval()
                    {
                        FirstPoint = new IntervalPoint<int>()
                        {
                            X = 10
                        },

                        LastPoint = new IntervalPoint<int>()
                        {
                            X = 12
                        }
                    },

                    StrokeBrush = Brushes.Red,
                    FillBrush = new SolidColorBrush(Color.FromArgb(30,255,0,0)),
                    Name = "Просто интервал"
                },
                
            };

            GraphIntervals = new ObservableCollection<GraphInterval>(intervals);
        }
    }
}
