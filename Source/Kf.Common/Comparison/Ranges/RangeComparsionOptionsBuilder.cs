using System;
using Kf.Common.Defensive.BuilderPattern;

namespace Kf.Common.Comparison.Ranges
{
    public sealed class RangeComparisonOptionsBuilder 
        : Builder<RangeComparisonOptions, RangeComparisonOptionsBuilder>
    {        
        public static implicit operator RangeComparisonOptions(
            RangeComparisonOptionsBuilder rangeComparisonOptionsBuilder)
            => rangeComparisonOptionsBuilder.Build();

        public RangeComparisonOptionsBuilder WithMinimumIncluded()
            => With(x => x.IsMinimumIncluded, true);

        public RangeComparisonOptionsBuilder WithMaximumIncluded()
            => With(x => x.IsMaximumIncluded, true);

        public RangeComparisonOptionsBuilder WithMinimumExcluded()
            => With(x => x.IsMinimumIncluded, false);

        public RangeComparisonOptionsBuilder WithMaximumExcluded()
            => With(x => x.IsMaximumIncluded, false);
    }
}
