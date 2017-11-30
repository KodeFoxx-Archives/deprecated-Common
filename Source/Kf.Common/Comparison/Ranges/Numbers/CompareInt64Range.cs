using System;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class CompareInt64Range : ICompareRange<Int64>
    {
        public bool IsInRange(long value, IRange<long> range)
            => value >= (
                   range.RangeComparisonOptions.IsMinimumIncluded
                       ? range.Minimum
                       : range.Minimum + 1)
               && value <= (
                   range.RangeComparisonOptions.IsMaximumIncluded
                       ? range.Maximum
                       : range.Maximum - 1);
    }
}
