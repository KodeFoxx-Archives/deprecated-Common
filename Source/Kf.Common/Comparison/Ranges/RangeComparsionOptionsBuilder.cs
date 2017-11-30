namespace Kf.Common.Comparison.Ranges
{
    public sealed class RangeComparsionOptionsBuilder
    {
        private bool _isMinimumIncluded = true;
        private bool _isMaximumIncluded = true;

        public RangeComparisonOptions Build()
            => new RangeComparisonOptions(_isMinimumIncluded, _isMaximumIncluded);

        public RangeComparsionOptionsBuilder WithMinimumIncluded()
        {
            _isMinimumIncluded = true;
            return this;
        }

        public RangeComparsionOptionsBuilder WithMaximumIncluded()
        {
            _isMaximumIncluded = true;
            return this;
        }

        public RangeComparsionOptionsBuilder WithMinimumExcluded()
        {
            _isMinimumIncluded = false;
            return this;
        }

        public RangeComparsionOptionsBuilder WithMaximumExcluded()
        {
            _isMaximumIncluded = false;
            return this;
        }
    }
}
