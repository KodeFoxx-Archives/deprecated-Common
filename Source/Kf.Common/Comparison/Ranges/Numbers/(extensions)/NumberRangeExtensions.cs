using Kf.Common.Defensive.Possibly;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public class NumberRangeExtensions
    {
        public static bool IsInRange(
            IRange<short> range, short value, ICompareRange<short> rangeComparer = null
        ) => rangeComparer
                .ToPossible().GetValue(new CompareInt16Range())
                .IsInRange(value, range);

        public static bool IsInRange(
            IRange<int> range, int value, ICompareRange<int> rangeComparer = null
        ) => rangeComparer
            .ToPossible().GetValue(new CompareInt32Range())
            .IsInRange(value, range);

        public static bool IsInRange(
            IRange<long> range, long value, ICompareRange<long> rangeComparer = null
        ) => rangeComparer
            .ToPossible().GetValue(new CompareInt64Range())
            .IsInRange(value, range);
    }
}
