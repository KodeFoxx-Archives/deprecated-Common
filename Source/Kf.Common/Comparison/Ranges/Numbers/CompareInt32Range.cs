using System;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class CompareInt32Range : ICompareRange<Int32>
    {
        public bool IsInRange(int value, IRange<int> range)
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
