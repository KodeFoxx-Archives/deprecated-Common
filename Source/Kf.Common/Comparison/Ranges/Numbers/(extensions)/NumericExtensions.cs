namespace Kf.Common.Comparison.Ranges.Numbers
{
    public static class NumericExtensions
    {
        public static IRange<short> To(
            this short minimum, short maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => new Int16Range(minimum, maximum, rangeComparisonOptions);

        public static IRange<int> To(
            this int minimum, int maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => new Int32Range(minimum, maximum, rangeComparisonOptions);

        public static IRange<long> To(
            this long minimum, long maximum, RangeComparisonOptions rangeComparisonOptions = null            
        ) => new Int64Range(minimum, maximum, rangeComparisonOptions);
    }
}
