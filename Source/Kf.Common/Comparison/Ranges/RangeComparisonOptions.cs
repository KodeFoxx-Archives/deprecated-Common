namespace Kf.Common.Comparison.Ranges
{
    public sealed class RangeComparisonOptions
    {
        public static RangeComparsionOptionsBuilder New() => new RangeComparsionOptionsBuilder();

        /// <summary>
        /// Determines whether the minimum value is included in the comparison.
        /// </summary>
        public bool IsMinimumIncluded { get; }

        /// <summary>
        /// Determines whether the maximum value is included in the comparison.
        /// </summary>
        public bool IsMaximumIncluded { get; }

        internal RangeComparisonOptions(bool isMinimumIncluded = true, bool isMaximumIncluded = true) {
            IsMinimumIncluded = isMinimumIncluded;
            IsMaximumIncluded = isMaximumIncluded;
        }        
    }
}
