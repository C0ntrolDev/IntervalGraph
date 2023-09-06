# GraphInterval

GraphInterval is a subclass of [Interval](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/Interval.md), but it differs in that it contains additional properties specifically related to its displaying in IntervalGraph.

### Additional Properties Used for Display in IntervalGraph

| Property          | Type            | DefaultValue          | Description                                          |
| ----------------- | --------------- | --------------------- | ---------------------------------------------------- |
| StrokeDashArray   | DoubleCollection | new DoubleCollection() | StrokeDashArray used for drawing the line.           |
| StrokeThickness   | double           | 1                     | The width of the line.                               |
| StrokeBrush       | Brush            | Black                 | The color of the line.                               |
| FillBrush         | Brush            | Black                 | The color of the interval inside.                    |
| Height            | double?          | null                  | The height of the interval in IntervalGraph (from 0 to 1). |
| Icon              | object           | null                  | **Not used**.                                        |
| LegendName        | string           | ""                    | **Not used**.                                        |

### Example of Two GraphIntervals with Different Settings:

![Example 1](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Images/GraphIntervalExample1.png)

```C#
new GraphInterval()
{
    FirstPoint = new IntervalPoint()
    { 
        X = 10
    },

    LastPoint = new IntervalPoint()
    { 
        X = 20
    },

    StrokeBrush = Brushes.Blue,
    StrokeThickness = 1,
    StrokeDashArray = new DoubleCollection(new List<double>()),
    FillBrush = new SolidColorBrush(Color.FromArgb(30,0,0,255))

}
```

![Example 2](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Images/GraphIntervalExample2.png)

```C#
new GraphInterval()
{
    FirstPoint = new IntervalPoint()
    { 
        X = 10
    },

    LastPoint = new IntervalPoint()
    { 
        X = 20
    },

    StrokeBrush = Brushes.Red,
    StrokeThickness = 5,
    StrokeDashArray = new DoubleCollection(new List<double>() { 1, 1 }),
    FillBrush = new SolidColorBrush(Color.FromArgb(30,255,0,0))

}
```
