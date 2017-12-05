using System;
using System.Collections.Generic;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class Int16Range : Range<Int16>
    {
        public static Int16RangeBuilder Create() => new Int16RangeBuilder();

        internal Int16Range(short minimum, short maximum, RangeComparisonOptions rangeComparisonOptions = null) 
            : base(minimum, maximum, rangeComparisonOptions) { }
        private Int16Range() : this(Int16.MinValue, Int16.MaxValue) { }

        public override IEnumerable<short> AsEnumerable()
        {            
            for (var current = Minimum; current <= Maximum; current++)            
                yield return current;
        }
    }    
}
