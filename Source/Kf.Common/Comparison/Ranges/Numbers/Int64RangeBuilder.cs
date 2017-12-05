using Kf.Common.Defensive.BuilderPattern;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class Int64RangeBuilder
        : Builder<Int64Range, Int64RangeBuilder>
    {
        public static implicit operator Int64Range(
            Int64RangeBuilder int64RangeBuilder
        ) => int64RangeBuilder.Build();

        public Int64RangeBuilder WithMinimum(long minimum)
            => With(x => x.Minimum, minimum);

        public Int64RangeBuilder WithMaximum(long maximum)
            => With(x => x.Maximum, maximum);

        public Int64RangeBuilder WithRangeComparsionOptions(RangeComparisonOptions rangeComparisonOptions = null)
            => With(x => x.RangeComparisonOptions, rangeComparisonOptions ?? RangeComparisonOptions.Create());
    }
}
