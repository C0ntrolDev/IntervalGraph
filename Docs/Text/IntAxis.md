# IntAxis

IntAxis is a specialized class created to manage settings related to the [IntervalGraph](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/IntervalGraph.md). It contains all the settings related to the axis and the numbers beneath it.

```XAML
 <gi:IntervalGraph>

     <gi:IntervalGraph.IntAxis>
         <gi:IntAxis/>
     </gi:IntervalGraph.IntAxis>

 <gi:IntervalGraph>
```

### Properties for Text Below the Graph

| Property        | Type     | DefaultValue | Description                                      |
| --------------- | -------- | ------------ | ------------------------------------------------ |
| NumStep         | int      | 1            | Specifies the interval for rendering numbers below the graph. |
| TextColorBrush  | Brush    | Black        | Color of the text below the graph.               |
| FontFamily      | FontFamily |             | FontFamily of the text.                         |
| TextFormat      | string   | "{0}"        | StringFormat for the text below the graph.       |
| FontSize        | double?  | null         | FontSize for the text below the graph.           |
| MinZoom         | double   | 1.0          | Minimum Zoom at which text will shrink when Zoom is changed. |
| MaxZoom         | double   | 1.0          | Maximum Zoom at which text will shrink when Zoom is changed. |
| MinFontSize     | double   | 15.0         | Minimum text size reached when Zoom <= MinZoom.  |
| MaxFontSize     | double   | 15.0         | Maximum text size reached when Zoom >= MaxZoom.  |

Note that there are two ways to specify the text size:

- Specify `FontSize`, and the text size will always be equal to it.
- Specify `Min`/`Max` `Zoom`/`FontSize`, and the text size will vary from `MinZoom` to `MaxZoom` `FontSize`, depending on `Zoom`, `MinZoom`, and `MaxZoom`.

### Properties for the Axis and Displayed Elements on It

| Property        | Type   | DefaultValue | Description                                   |
| --------------- | ------ | ------------ | --------------------------------------------- |
| AxisColorBrush  | Brush  | Black        | Color of the axis below the graph.            |
| AxisThickness   | double | 2.0          | Thickness of the axis line below the graph.   |
| CirclesRadius   | double | 3.0          | Radius of the circles displayed at the intersection of the interval and axis, indicating whether the value is included in the interval. |
| CirclesThickness | double | 2.0          | Thickness of the lines of these circles.      |
