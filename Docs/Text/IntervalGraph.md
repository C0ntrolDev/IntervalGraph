# IntevalGraph

IntervalGraph - это основной пользовательский элемент управлений, который является главным предметом этой библиотеки. У него есть как и свои свойства, так и подэлемент под названием IntAxis, в котором находится настройки оси и текста под ней

Свойства IntervalGraph можно разбить на подгруппы: Min-Max Values, Zoom, Background Lines, Intervals Height.

### Min-Max Values

В этой категории содержатся свойства которые влияют на минимальное и максимальное значение графика:

- **MinValue** (double?) - позволяет указать минимальное значение графика, у значения не самый высокий приоритет, тоесть если в GraphIntervals будет содержаться Interval, у которого IntervalPoint.X < MinValue, то значение учитываться не будет. Если не указать значение, значение будет выбираться автоматически.
- **MaxValue** (double?) - позволяет указать максимальное значение графика, у значения не самый высокий приоритет, тоесть если в GraphIntervals будет содержаться Interval, у которого IntervalPoint.X > MaxValue, то значение учитываться не будет. Если не указать значение, значение будет выбираться автоматически.
- **GraphIntervals** (ObservableCollection) - Отображаемые интервалы, могут влиять на MaxValue и MinValue, если значение будет выходить за их диапазон, если MaxValue или MinValue == null, то график будет учитывать значения IntervalPoint для построения графика.

### Zoom

В этой категории содержатся свойства которые влияют на Zoom графика:

- **MaxZoom** (double) (deffaultValue = 1) - позволяет указать максимальное увеличение графика.
- **Zoom** (double?) (deffaultValue = 1) - позволяет указать Zoom, значение больше MaxZoom, будет проигнорировано.
- **IsZoomChangeEnabledWithWheel** (bool) - будет ли включено Zooming графика с помощью колеса мыши.
- **WheelZoomingStep** (bool) - на сколько будет изменен Zoom при единичном вращении колеса мыши.

Стоит упомянуть что Zoom по умолчанию всегда равен 1, и при Zoom = 1 график будет занимать все доступное пространство при запуске вашего приложения

### Background Lines

В этой категории содержатся свойства которые влияют на линии графика:

- **MajorColorBrush** (Brush) (deffaultValue = Black) - позволяет указать цвет первостепенной линии фона.
- **MinorColorBrush** (Brush) (deffaultValue = Black) - позволяет указать цвет второстепенной линии фона.
- **MajorThickness** (int) (deffaultValue = 1) - позволяет указать ширину первостепенной линии фона.
- **MinorThickness** (int) (deffaultValue = 1) - позволяет указать ширину второстепенной линии фона.
- **MajorStep** (int) (deffaultValue = 1) - позволяет указать частоту отображения первостепенной линии фона.  
- **MinorStep** (int) (deffaultValue = 1) - позволяет указать частоту отображения второстепенной линии фона.  

#### Пример использования данных параметров

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

В этой категории содержатся свойства которые влияют на отображаемую высоту графиков:

Есть несколько способов указать высоту графиков: 
1. В свойстве GraphInterval.Height указать отображаемую высоту (указывать следует от 0 до 1)
2. Если IsIntervalHeightDependToWidth == true, то высота будет расчитываться следующим образом: (MaxStableIntervalHeight + (IntervalWidth / GraphWidth * (1 - MaxStableIntervalHeight)) * MaxIntervalHeight). Если говорить более просто, то все интервалы будут иметь максимальную высоту равную MaxIntervalHeight. Далее относительно MaxIntervalHeight расчитывается MaxStableIntervalHeight, а далее к этой высоте прибавляется высота зависящая от ширины интервала.
3. Если IsIntervalHeightDependToWidth == false, то высота графиков всегда будет равна MaxIntervalHeight.

Изображение объясняющее работу 2 способа:

![](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Images/IntervalHeightExample.png)

Теперь все свойства:

- **IsIntervalHeightDependToWidth** (bool) - будет ли высота расчитывать относительно ширины интервала
- **MaxIntervalHeight** (double) (deffaultValue = 0.7) - максимальная высота графика (задается от 0 до 1)
- **MaxStableIntervalHeight** (double) (deffaultValue = 0.5) - максимальная обязательная высота графика (задается от 0 до 1) (отображается относительно MaxIntervalHeight)

### Остальные свойства

В этой категории содержатся свойства которые не попали ни в одну подборку:

- **GraphIntervalsPositioning** (GraphIntervalsPositioning) (deffaultValue = NoBased) - как графики будут отсортированы, сейчас есть один способ сортировки - по длине, тоесть более короткие графики будут находится на переднем плане, а более длинные позади, благодаря этому графики меньше перекрывают друг друга.
