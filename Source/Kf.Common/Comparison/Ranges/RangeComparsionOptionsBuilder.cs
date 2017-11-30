using System;

namespace Kf.Common.Comparison.Ranges
{
    public sealed class RangeComparisonOptionsBuilder
    {
        private bool _isMinimumIncluded = true;
        private bool _isMaximumIncluded = true;

        public static implicit operator RangeComparisonOptions(
            RangeComparisonOptionsBuilder rangeComparisonOptionsBuilder)
            => new RangeComparisonOptions(
                    rangeComparisonOptionsBuilder._isMinimumIncluded, 
                    rangeComparisonOptionsBuilder._isMaximumIncluded
               );        

        public RangeComparisonOptionsBuilder WithMinimumIncluded()
        {
            _isMinimumIncluded = true;
            return this;
        }

        public RangeComparisonOptionsBuilder WithMaximumIncluded()
        {
            _isMaximumIncluded = true;
            return this;
        }

        public RangeComparisonOptionsBuilder WithMinimumExcluded()
        {
            _isMinimumIncluded = false;
            return this;
        }

        public RangeComparisonOptionsBuilder WithMaximumExcluded()
        {
            _isMaximumIncluded = false;
            return this;
        }
    }
}
