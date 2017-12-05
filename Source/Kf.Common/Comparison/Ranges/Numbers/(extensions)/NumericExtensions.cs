namespace Kf.Common.Comparison.Ranges.Numbers
{
    public static class NumericExtensions
    {
        public static IRange<short> ToRange(
            this short minimum, short maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => new Int16Range(minimum, maximum, rangeComparisonOptions);

        public static IRange<int> ToRange(
            this int minimum, int maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => new Int32Range(minimum, maximum, rangeComparisonOptions);

        public static IRange<long> ToRange(
            this long minimum, long maximum, RangeComparisonOptions rangeComparisonOptions = null            
        ) => new Int64Range(minimum, maximum, rangeComparisonOptions);

        public static IRange<short> ToInt16Range(
            this int minimum, short maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => new Int16Range((short)minimum, maximum, rangeComparisonOptions);

        public static IRange<long> ToInt64Range(
            this int minimum, long maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => new Int64Range(minimum, maximum, rangeComparisonOptions);
    }
}
