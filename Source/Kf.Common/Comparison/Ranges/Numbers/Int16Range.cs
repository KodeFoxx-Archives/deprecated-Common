using System;
using System.Collections.Generic;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class Int16Range : Range<Int16>
    {
        public Int16Range(short minimum, short maximum, RangeComparisonOptions rangeComparisonOptions = null) 
            : base(minimum, maximum, rangeComparisonOptions) { }

        public override IEnumerable<short> AsEnumerable()
        {            
            for (var current = Minimum; current <= Maximum; current++)            
                yield return current;
        }
    }
}
