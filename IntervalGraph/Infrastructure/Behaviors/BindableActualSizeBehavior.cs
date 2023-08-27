using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace IntervalGraph.Infrastructure.Behaviors
{
    public class BindableActualSizeBehavior : Behavior<FrameworkElement>
    {
        #region ActualWidthProperty

        public static readonly DependencyProperty ActualWidthProperty = DependencyProperty.Register(
            nameof(ActualWidth),
            typeof(double),
            typeof(BindableActualSizeBehavior),
            new FrameworkPropertyMetadata());

        public double ActualWidth
        {
            get => (double)GetValue(ActualWidthProperty);
            set => SetValue(ActualWidthProperty, value);
        }

        #endregion

        #region ActualHeightProperty

        public static readonly DependencyProperty ActualHeightProperty = DependencyProperty.Register(
            nameof(ActualHeight),
            typeof(double),
            typeof(BindableActualSizeBehavior),
            new FrameworkPropertyMetadata());

        public double ActualHeight
        {
            get => (double)GetValue(ActualHeightProperty);
            set => SetValue(ActualHeightProperty, value);
        }

        #endregion


        protected override void OnAttached()
        {
            base.OnAttached();
            base.AssociatedObject.SizeChanged += OnSizeChanged;
            base.AssociatedObject.Loaded += OnLoaded;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.SizeChanged -= OnSizeChanged;
            base.AssociatedObject.Loaded -= OnLoaded;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ActualWidth = base.AssociatedObject.RenderSize.Width;
            ActualHeight = base.AssociatedObject.RenderSize.Height;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ActualWidth = base.AssociatedObject.RenderSize.Width;
            ActualHeight = base.AssociatedObject.RenderSize.Height;
        }


    }
}
