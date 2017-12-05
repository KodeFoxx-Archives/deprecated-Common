using System;
using System.Collections.Generic;

namespace Kf.Common.Comparison.Ranges.Time
{
    public sealed class DateTimeRange : Range<DateTime>
    {
        public DateTimeRange(
            DateTime minimum, DateTime maximum, RangeComparisonOptions rangeComparisonOptions = null) 
            : base(minimum, maximum, rangeComparisonOptions) { }

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
