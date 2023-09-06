# Interval

Interval is a simple class designed for creating intervals.

### Properties

| Property   | Type                                                | DefaultValue | Description                                          |
| ---------- | --------------------------------------------------- | ------------ | ---------------------------------------------------- |
| Id         | int                                                 | 0            | Property intended for storing values in a database if needed. |
| FirstPoint | [IntervalPoint](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/IntervalPoint.md) | null         | The first point of the interval.                     |
| LastPoint  | [IntervalPoint](https://github.com/C0ntrolDev/IntervalGraph/blob/master/Docs/Text/IntervalPoint.md) | null         | The last point of the interval.                      |
| IsPositive | bool                                                | true         | **Currently not used**.                               |

(**Please specify the smallest value for `FirstPoint` and the largest value for `LastPoint`**)
