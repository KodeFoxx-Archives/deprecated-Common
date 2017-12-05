using Kf.Common.Defensive.BuilderPattern;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class Int16RangeBuilder
        : Builder<Int16Range, Int16RangeBuilder>
    {
        public static implicit operator Int16Range(
            Int16RangeBuilder int16RangeBuilder
        ) => int16RangeBuilder.Build();        

        public Int16RangeBuilder WithMinimum(short minimum)
            => With(x => x.Minimum, minimum);

        public Int16RangeBuilder WithMaximum(short maximum)
            => With(x => x.Maximum, maximum);

        public Int16RangeBuilder WithRangeComparsionOptions(RangeComparisonOptions rangeComparisonOptions = null)
            => With(x => x.RangeComparisonOptions, rangeComparisonOptions ?? RangeComparisonOptions.Create());
    }
}
