namespace Kf.Common.Comparison.Ranges.Numbers
{
    public static class NumericExtensions
    {
        public static IRange<short> ToRange(
            this short minimum, short maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => Int16Range.Create()
                .WithMinimum(minimum)
                .WithMaximum(maximum)
                .WithRangeComparsionOptions(rangeComparisonOptions)
                .Build();

        public static IRange<int> ToRange(
            this int minimum, int maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => Int32Range.Create()
                .WithMinimum(minimum)
                .WithMaximum(maximum)
                .WithRangeComparsionOptions(rangeComparisonOptions)
                .Build();

        public static IRange<long> ToRange(
            this long minimum, long maximum, RangeComparisonOptions rangeComparisonOptions = null            
        ) => Int64Range.Create()
                .WithMinimum(minimum)
                .WithMaximum(maximum)
                .WithRangeComparsionOptions(rangeComparisonOptions)
                .Build();

        public static IRange<short> ToInt16Range(
            this int minimum, short maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => Int16Range.Create()
                .WithMinimum((short)minimum)
                .WithMaximum(maximum)
                .WithRangeComparsionOptions(rangeComparisonOptions)
                .Build();

        public static IRange<long> ToInt64Range(
            this int minimum, long maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => Int64Range.Create()
                .WithMinimum(minimum)
                .WithMaximum(maximum)
                .WithRangeComparsionOptions(rangeComparisonOptions)
                .Build();
    }
}
