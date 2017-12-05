using Kf.Common.Defensive.BuilderPattern;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class Int64RangeBuilder
        : Builder<Int64Range, Int64RangeBuilder>
    {
        public static implicit operator Int64Range(
            Int64RangeBuilder int16RangeBuilder
        ) => int16RangeBuilder.Build();

        public Int64RangeBuilder WithMinimum(long minimum)
            => With(x => x.Minimum, minimum);

        public Int64RangeBuilder WithMaximum(long maximum)
            => With(x => x.Maximum, maximum);

        public Int64RangeBuilder WithRangeComparsionOptions(RangeComparisonOptions rangeComparisonOptions)
            => With(x => x.RangeComparisonOptions, rangeComparisonOptions);
    }
}
