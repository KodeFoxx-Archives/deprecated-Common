using System.Collections.Generic;
using System.Linq;

namespace Kf.Common.Comparison.Ranges
{
    /// <summary>
    /// Abstract base implementation of <see cref="IRange{T}"/>.
    /// </summary>    
    public class Range<T> : IRange<T>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        public T Minimum { get; private set; }

        /// <summary>
        /// The maximul value of the range.
        /// </summary>
        public T Maximum { get; private set; }

        /// <summary>
        /// The options used to see whether a value is in a given range.
        /// </summary>
        public RangeComparisonOptions RangeComparisonOptions { get; private set; }

        /// <summary>
        /// Creates a new <see cref="Range{T}"/> object.
        /// </summary>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value</param>
        /// <param name="rangeComparisonOptions">The comparer options, where the default included both minimum and maximum.</param>
        public Range(T minimum, T maximum, RangeComparisonOptions rangeComparisonOptions = null)
        {
            Minimum = minimum;
            Maximum = maximum;
            RangeComparisonOptions =
                rangeComparisonOptions
                ?? RangeComparisonOptions.Create()
                    .WithMinimumIncluded()
                    .WithMaximumIncluded();
        }

        /// <summary>
        /// Lists all values of <see cref="IRange{T}"/> in an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <returns>an <see cref="IEnumerable{T}"/></returns>
        public virtual IEnumerable<T> AsEnumerable()
            => Enumerable.Empty<T>();
    }
}
