# GraphInteval

GraphInteval - наследник [Interval](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/Interval.md), отличается от него тем, что содержит дополнительные свойства, связанные с отображением в IntervalGraph.

### Дополнительные свойства, которые используются при отображении в IntevalGraph

| Property | Type | DeffautltValue | Description |
| -------- | ----|----------------|----------|
| StrokeDashArray | DoubleCollection | new DoubleCollection() | StrokeDashArray используемый для отрисовки линиии |
| StrokeThickness | double | 1 | Ширина линии |
| StrokeBrush | Brush | Black | Цвет линии |
| FillBrush | Brush | Black | Цвет интервала внутри |
| Height | double? | null | Высота интервала на IntervalGraph (от 0 до 1) |
| Icon | object | null | **Не используется** |
| LegendName | string | "" | **Не используется** |


### Пример двух GraphInnteval с разными настройками:

![](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Images/GraphIntervalExample1.png)
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

![](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Images/GraphIntervalExample2.png)
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
