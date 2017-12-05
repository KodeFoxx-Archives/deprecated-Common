using System;
using System.Collections.Generic;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class Int64Range : Range<Int64>
    {
        public static Int64RangeBuilder Create() => new Int64RangeBuilder();

        internal Int64Range(long minimum, long maximum, RangeComparisonOptions rangeComparisonOptions = null) 
            : base(minimum, maximum, rangeComparisonOptions) { }
        private Int64Range() : this(Int64.MinValue, Int64.MaxValue) { }

        public override IEnumerable<long> AsEnumerable()
        {            
            for (var current = Minimum; current <= Maximum; current++)            
                yield return current;
        }
    }
}
