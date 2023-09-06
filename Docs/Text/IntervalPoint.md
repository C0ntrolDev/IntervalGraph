# IntervalPoint

IntervalPoint - класс, представляющий точку интервала

| Property | Type | DeffautltValue | Description |
| -------- | ----|----------------|----------|
| Id | int | 0 | Свойство предназначеное для хранения значений в базе данных при необходимости |
| X | int | 0.0 | Координата точки |
| IsInclusive | bool | false | Включена ли точка в интервал |

### Как использовать IsInclusive

- Если X ∈ (10; ... => IsInclusive = false
- Если X ∈ [10; ... => IsInclusive = true
