using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace IntervalGraph.Components
{
    public class Legend : Freezable
    {
        #region ForegroundProperty

        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(
            nameof(Foreground),
            typeof(Brush),
            typeof(Legend),
            new PropertyMetadata(default(Brush)));

        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        #endregion

        #region BackgroundProperty

        public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register(
            nameof(Background),
            typeof(Brush),
            typeof(Legend),
            new PropertyMetadata(default(Brush)));

        public Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        #endregion

        #region FontSizeProperty

        public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(
            nameof(FontSize),
            typeof(double),
            typeof(Legend),
            new PropertyMetadata(default(double)));

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        #endregion

        #region IsIconDisplayedProperty

        public static readonly DependencyProperty IsIconDisplayedProperty = DependencyProperty.Register(
            nameof(IsIconDisplayed),
            typeof(bool),
            typeof(Legend),
            new PropertyMetadata(default(bool)));

        public bool IsIconDisplayed
        {
            get => (bool)GetValue(IsIconDisplayedProperty);
            set => SetValue(IsIconDisplayedProperty, value);
        }

        #endregion

        #region PaddingProperty

        public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(
            nameof(Padding),
            typeof(Thickness),
            typeof(Legend),
            new PropertyMetadata(default(Thickness)));

        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        #endregion

        protected override Freezable CreateInstanceCore() => new Legend();
    }
}
