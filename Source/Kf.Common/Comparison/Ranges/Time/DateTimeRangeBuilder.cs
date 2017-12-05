using System;
using Kf.Common.Defensive.BuilderPattern;

namespace Kf.Common.Comparison.Ranges.Time
{
    public sealed class DateTimeRangeBuilder
        : Builder<DateTimeRange, DateTimeRangeBuilder>
    {
        public static implicit operator DateTimeRange(
            DateTimeRangeBuilder dateTimeRangeBuilder
        ) => dateTimeRangeBuilder.Build();

        public DateTimeRangeBuilder WithMinimum(DateTime minimum)
            => With(x => x.Minimum, minimum);

        public DateTimeRangeBuilder WithMaximum(DateTime maximum)
            => With(x => x.Maximum, maximum);

        public DateTimeRangeBuilder WithRangeComparsionOptions(RangeComparisonOptions rangeComparisonOptions = null)
            => With(x => x.RangeComparisonOptions, rangeComparisonOptions ?? RangeComparisonOptions.Create());
    }
}
