# IntervalGraph

IntervalGraph is a library that allows you to create interval graphs from mathematics. With this library, you can create graphs like the following:

X ∈ (−∞, 7] U (14, 21)
![](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Images/Image1.png)

# Installation

You can either follow this [link](https://www.nuget.org/packages/IntervalGraph) to download the NuGet package or use the package manager in Visual Studio.

For use in XAML code, specify:

```xml
xmlns:gi="clr-namespace:IntervalGraph.Components;assembly=IntervalGraph"
```

# Example Usage

Let's consider the same example with the interval: X ∈ (−∞, 7] U (14, 21)

First, create your control element:

```XAML
<gi:IntervalGraph Height="200" Width="600" HorizontalAlignment="Left" VerticalAlignment="Top"
                 MajorStep="2" MajorThickness="1" MinorStep="0"
                 GraphIntervals="{Binding GraphIntervals}" >

    <c:IntervalGraph.IntAxis>
        <c:IntAxis FontSize="13" NumStep="2" CirclesRadius="3"/>
    </c:IntervalGraph.IntAxis>

</gi:IntervalGraph>
```

The most important property here is `GraphIntervals`. The intervals will be created based on the contents of this property.

(For more information about IntervalGraph, you can learn more [here](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/IntervalGraph.md)).

To create our interval, we need to split it into two parts:
1) (−∞, 7]
2) (14, 21)

Next, in your ViewModel, create an `ObservableCollection<GraphInterval>` and populate it with intervals:

```C#
List<GraphInterval> intervals = new List<GraphInterval>()
{
    new GraphInterval()
    {
        LastPoint = new IntervalPoint()
        {
            X = 7,
            IsInclusive = true
        },

        StrokeBrush = Brushes.Red,
        FillBrush = new SolidColorBrush(Color.FromArgb(30,255,0,0))
    },

    new GraphInterval()
    {
        FirstPoint = new IntervalPoint()
        { 
            X = 14 
        },

        LastPoint = new IntervalPoint()
        { 
            X = 21
        },

        StrokeBrush = Brushes.Red,
        FillBrush = new SolidColorBrush(Color.FromArgb(30,255,0,0))
    },
};

GraphIntervals = new ObservableCollection<GraphInterval>(intervals);
```

To create intervals, you will use the [GraphInterval](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/GraphInterval.md) class, which has properties `FirstPoint` and `LastPoint` of type [IntervalPoint](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/IntervalPoint.md).

- `FirstPoint` == null  => (−∞ , ...
- `LastPoint` == null  => ... ; +∞)

# Documentation Links

- [IntervalGraph](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/IntervalGraph.md)
- [IntAxis](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/IntAxis.md)
- [Interval](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/Interval.md)
- [GraphInterval](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/GraphInterval.md)
- [IntervalPoint](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/IntervalPoint.md)
