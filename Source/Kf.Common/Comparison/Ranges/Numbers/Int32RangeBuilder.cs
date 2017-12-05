using Kf.Common.Defensive.BuilderPattern;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class Int32RangeBuilder
        : Builder<Int32Range, Int32RangeBuilder>
    {
        public static implicit operator Int32Range(
            Int32RangeBuilder int16RangeBuilder
        ) => int16RangeBuilder.Build();

        public Int32RangeBuilder WithMinimum(int minimum)
            => With(x => x.Minimum, minimum);

        public Int32RangeBuilder WithMaximum(int maximum)
            => With(x => x.Maximum, maximum);

        public Int32RangeBuilder WithRangeComparsionOptions(RangeComparisonOptions rangeComparisonOptions = null)
            => With(x => x.RangeComparisonOptions, rangeComparisonOptions ?? RangeComparisonOptions.Create());
    }
}
