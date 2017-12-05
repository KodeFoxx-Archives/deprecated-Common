using System;

namespace Kf.Common.Comparison.Ranges.Time
{
    public sealed class CompareDateTimeRange : ICompareRange<DateTime>
    {
        public bool IsInRange(DateTime value, IRange<DateTime> range)
            => value >= (range.RangeComparisonOptions.IsMinimumIncluded
                   ? range.Minimum
                   : range.Minimum.AddMilliseconds(1)
               )
               && value <= (range.RangeComparisonOptions.IsMaximumIncluded
                   ? range.Maximum
                   : range.Maximum.AddMilliseconds(-1)
               );
    }
}
