# IntervalPoint

IntervalPoint is a class representing a interval point.

| Property    | Type  | DefaultValue | Description                                         |
| ----------- | ----- | ------------ | --------------------------------------------------- |
| Id          | int   | 0            | Property intended for storing values in a database if needed. |
| X           | int   | 0.0          | The coordinate of the point.                        |
| IsInclusive | bool  | false        | Indicates whether the point is included in the interval. |

### How to Use IsInclusive

- If X ∈ (10; ... => `IsInclusive` = false
- If X ∈ [10; ... => `IsInclusive` = true
