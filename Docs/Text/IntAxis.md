# IntAxis

IntAxis - специальный класс созданный для разделения настроек [IntervalGraph](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/IntervalGraph.md), в нем содержутся все настройки связаные с осью и цифрами под ней

```XAML
 <gi:IntervalGraph>

     <gi:IntervalGraph.IntAxis>
         <gi:IntAxis/>
     </gi:IntervalGraph.IntAxis>

 <gi:IntervalGraph>
```

### Свойства текста под графиком

| Property | Type | DeffautltValue | Description |
| -------- | ----|----------------|----------|
| NumStep | int | 1 | С каким отступом будут отрисовываться числа под графиком |
| TextColorBrush | Brush | Black | Цвет текста под графиком |
| FontFamily | FontFamily |  | FontFamily текста |
| TextFormat | string | "{0}" | StringFormat текста под графиком |
| FontSize | double? | null | FontSize текста под графиком |
| MinZoom | double | 1.0 | Минимальный Zoom до которого будет уменьшаться текст, при изменении Zoom) |
| MaxZoom | double | 1.0 | Максимальный Zoom до которого будет уменьшаться текст, при изменении Zoom) |
| MinFontSize | double | 15.0 | Минимальный размер текста, который будет достигнут при Zoom <= MinZoom |
| MaxFontSize | double | 15.0 | Максимальный размер текста, которы будет достигнут при Zoom >= MaxZoom |

Можно обратить внимание, что есть два способа указать размер текста:

- Указать FontSize, и размер текста будет все время равен ему
- Указать Min/Max Zoom/FontSize и текст будет варьироваться от MinZoom до MaxZoom FontSize , в зависимости от Zoom, а также Minzoom и MaxZoom

## Свойства оси и отображаемых элементов на ней

| Property | Type | DeffautltValue | Description |
| -------- | ----|----------------|----------|
| AxisColorBrush | Brush | Black | Цвет оси под графиком |
| AxisThickness | double | 2.0 | Ширина линии оси под графиком |
| CirclesRadius | double | 3.0 | Радиус кружков отображаемых в месте пересечения интервала и оси, которые означают включено ли значение в интервал |
| CirclesThickness | double | 2.0 | Ширина линии тех же кружков |
