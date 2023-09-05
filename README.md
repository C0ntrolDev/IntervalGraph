# IntervalGraph

InteravalGraph - это библиотека, которая позволяет строить интервальные графики из математики, например благодаря этой библиотеке можно построить подобный график:

X ∈ (−∞, 7] U (14, 21)
![](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Images/Image1.png)

# Установка

Вы можете перейти по ссылке и скачать пакет nuget или скачать с помощью диспечера пакетов в Visual Studio

https://www.nuget.org/packages/IntervalGraph

Для использование в коде XAML укажите:

```
xmlns:gi="clr-namespace:IntervalGraph.Components;assembly=IntervalGraph"
```

# Пример использования

Рассмотрим все тот же пример с интевалом: X ∈ (−∞, 7] U (14, 21)

Для начала мы создаем наш элемент управления:

```XAML
<c:IntervalGraph Height="200" Width="600" HorizontalAlignment="Left" VerticalAlignment="Top"
                 MajorStep="2" MajorThickness="1" MinorStep="0"
                 GraphIntervals="{Binding GraphIntervals}" >

    <c:IntervalGraph.IntAxis>
        <c:IntAxis FontSize="13" NumStep="2" CirclesRadius="3"/>
    </c:IntervalGraph.IntAxis>

</c:IntervalGraph>
```

Самое важное свойство здесь - это GraphIntervals.
Именно по содержимому этого свойства будут строится интервалы.

(Подробнее об IntervalGraph, можно узнать [здесь](http://example.com/)).

Для создания нашего интервала нам потребуется раздробить его на две части:
1) (−∞, 7]
2) (14, 21)

Даллее в вашей ViewModel создаем ObservableCollection<GraphInterval>. И заполняем ее интервалами:
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

Для создания интервалов используется класс [GraphInterval](http://example.com/), у которого есть свойства FirstPoint и LastPoint типа [IntervalPoint](http://example.com/)

- FirstPoint = null  => (−∞ , ...
- LastPoint = null  => ... ; +∞)
