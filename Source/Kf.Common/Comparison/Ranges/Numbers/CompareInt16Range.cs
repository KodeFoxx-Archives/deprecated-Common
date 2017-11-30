using System;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class CompareInt16Range : ICompareRange<Int16>
    {
        public bool IsInRange(short value, IRange<short> range)
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
