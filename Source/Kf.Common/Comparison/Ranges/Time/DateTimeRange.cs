using System;
using System.Collections.Generic;

namespace Kf.Common.Comparison.Ranges.Time
{
    public sealed class DateTimeRange : Range<DateTime>
    {
        public static DateTimeRangeBuilder Create() => new DateTimeRangeBuilder();

        internal DateTimeRange(
            DateTime minimum, DateTime maximum, RangeComparisonOptions rangeComparisonOptions = null) 
            : base(minimum, maximum, rangeComparisonOptions) { }
        private DateTimeRange() : this(DateTime.MinValue, DateTime.MaxValue) { }

        public override IEnumerable<DateTime> AsEnumerable()
        {
            var currentValue = Minimum;
            while (currentValue <= Maximum)
            {
                yield return currentValue;
                currentValue = currentValue.AddMilliseconds(1);
            }
        }
    }
}
