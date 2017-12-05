﻿using System;

namespace Kf.Common.Comparison.Ranges.Time
{
    public static class TimeExtensions
    {
        public static IRange<DateTime> To(
            this DateTime minimum, DateTime maximum, RangeComparisonOptions rangeComparisonOptions = null
        ) => new DateTimeRange(minimum, maximum, rangeComparisonOptions);        
    }
}
