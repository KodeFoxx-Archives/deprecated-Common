using System;
using System.Collections.Generic;

namespace Kf.Common.Comparison.Ranges.Numbers
{
    public sealed class Int32Range : Range<Int32>
    {
        public static Int32RangeBuilder Create() => new Int32RangeBuilder();

        internal Int32Range(int minimum, int maximum, RangeComparisonOptions rangeComparisonOptions = null) 
            : base(minimum, maximum, rangeComparisonOptions) { }
        private Int32Range() : this(Int32.MinValue, Int32.MaxValue) { }

        public override IEnumerable<int> AsEnumerable()
        {            
            for (var current = Minimum; current <= Maximum; current++)            
                yield return current;
        }        
    }
}
