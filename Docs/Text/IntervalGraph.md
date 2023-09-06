# IntervalGraph

IntervalGraph is the main user control element, which is the core of this library. It has its own properties as well as a sub-element [IntAxis](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/IntAxis.md), which contains axis and text settings.

The properties of IntervalGraph can be categorized into: Min-Max Values, Zoom, Background Lines, and Intervals Height.

### Min-Max Values

This category contains properties that affect the minimum and maximum values of the graph:

| Property | Type | DefaultValue | Description |
| -------- | ----|--------------|-------------|
| MinValue | double? | null | Allows you to specify the minimum value of the graph. This value has a lower priority. If an Interval with IntervalPoint.X < MinValue exists in GraphIntervals, it won't be considered. If not specified, the value will be chosen automatically. |
| MaxValue | double? | null | Allows you to specify the maximum value of the graph. This value has a lower priority. If an Interval with IntervalPoint.X > MaxValue exists in GraphIntervals, it won't be considered. If not specified, the value will be chosen automatically. |
| GraphIntervals | ObservableCollection | null | Displayed intervals that can affect MaxValue and MinValue. If the value goes beyond their range and MaxValue or MinValue == null, the graph will consider the IntervalPoint values for graph construction. |

### Zoom

This category contains properties that affect the graph's zoom:

| Property | Type | DefaultValue | Description |
| -------- | ----|--------------|-------------|
| MaxZoom | double | 1 | Allows you to specify the maximum zoom level of the graph. |
| Zoom | double? | 1 | Allows you to set the zoom level. A value greater than MaxZoom will be ignored. |
| IsZoomChangeEnabledWithWheel | bool | false | Specifies whether zooming the graph with the mouse wheel is enabled. |
| WheelZoomingStep | bool | false | Specifies how much the zoom changes with a single rotation of the mouse wheel. |

It's worth mentioning that the default Zoom is always 1, and at Zoom = 1, the graph will occupy the entire available space when your application is launched.

### Background Lines

This category contains properties that affect the graph's lines:

| Property | Type | DefaultValue | Description |
| -------- | ----|--------------|-------------|
| MajorColorBrush | Brush | Black | Allows you to specify the color of the major background line. |
| MinorColorBrush | Brush | Black | Allows you to specify the color of the minor background line. |
| MajorThickness | int | 1 | Allows you to specify the thickness of the major background line. |
| MinorThickness | int | 1 | Allows you to specify the thickness of the minor background line. |
| MajorStep | int | 1 | Allows you to specify the frequency of displaying the major background line. |
| MinorStep | int | 1 | Allows you to specify the frequency of displaying the minor background line. |

#### Example of using these parameters

![](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Images/BackgroundLinesExample.png)

```XAML
 <gi:IntervalGraph Height="200" Width="600" HorizontalAlignment="Left" VerticalAlignment="Top"
                  MajorStep="2" MajorThickness="2" MajorColorBrush="Green" MinorStep="1" MinorThickness="1" MinorColorBrush="Blue"
                  GraphIntervals="{Binding GraphIntervals}" >

     <c:IntervalGraph.IntAxis>
         <c:IntAxis FontSize="13" NumStep="2" CirclesRadius="3"/>
     </c:IntervalGraph.IntAxis>

 </gi:IntervalGraph>
```

### Intervals Height

This category contains properties that affect the displayed height of the graphs:

There are several ways to specify the height of the graphs:

1. Set the displayed height in the GraphInterval.Height property (values should be between 0 and 1).
2. If `IsIntervalHeightDependToWidth` == true, the height will be calculated as follows: (`MaxStableIntervalHeight` + (`IntervalWidth` / `GraphWidth` * (1 - `MaxStableIntervalHeight`)) * `MaxIntervalHeight`). In simpler terms, all intervals will have a maximum height equal to `MaxIntervalHeight`. `MaxStableIntervalHeight` is then calculated relative to `MaxIntervalHeight`, and the height depends on the width of the interval.
3. If `IsIntervalHeightDependToWidth` == false, the height of the graphs will always be `MaxIntervalHeight`.

An image explaining the second method:

![](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Images/IntervalHeightExample.png)

Now, all the properties:

| Property | Type | DefaultValue | Description |
| -------- | ----|--------------|-------------|
| IsIntervalHeightDependToWidth | bool | false | Specifies whether the height should be calculated relative to the width of the interval. |
| MaxIntervalHeight | double | 0.7 | Maximum height of the graph (values should be between 0 and 1). |
| MaxStableIntervalHeight | double | 0.5 | Maximum mandatory height of the graph (values should be between 0 and 1) (relative to MaxIntervalHeight). |

### Other Properties

This category contains properties that do not belong to any of the above categories:

| Property | Type | DefaultValue | Description |
| -------- | ----|--------------|-------------|
| GraphIntervalsPositioning | GraphIntervalsPositioning | NoBased | Specifies how the graphs will be sorted. Currently, there is one sorting method - by length. In other words, shorter graphs will be in the foreground, and longer ones will be in the background. This reduces overlap between graphs. |
