using System;
using System.Collections.Generic;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class Int32Range : Range<Int32>
    {
        public Int32Range(int minimum, int maximum, RangeComparisonOptions rangeComparisonOptions = null) 
            : base(minimum, maximum, rangeComparisonOptions) { }

        public override IEnumerable<int> AsEnumerable()
        {            
            for (var current = Minimum; current <= Maximum; current++)            
                yield return current;
        }
    }
}
