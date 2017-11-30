using Kf.Common.Defensive.BuilderPattern;

namespace Kf.Common.Comparison.Ranges
{
    public sealed class RangeComparisonOptions
    {
        public static RangeComparisonOptionsBuilder Create() => new RangeComparisonOptionsBuilder();

        /// <summary>
        /// Determines whether the minimum value is included in the comparison.
        /// </summary>
        public bool IsMinimumIncluded { get; private set; }

        /// <summary>
        /// Determines whether the maximum value is included in the comparison.
        /// </summary>
        public bool IsMaximumIncluded { get; private set; }

        internal RangeComparisonOptions(bool isMinimumIncluded, bool isMaximumIncluded) {
            IsMinimumIncluded = isMinimumIncluded;
            IsMaximumIncluded = isMaximumIncluded;
        }
        private RangeComparisonOptions() : this(true, true) { }
    }
}
