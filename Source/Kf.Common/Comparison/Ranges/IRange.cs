using System.Collections.Generic;

namespace Kf.Common.Comparison.Ranges
{
    /// <summary>
    /// Specifies a range between a minimum and maximum value of <typeparamref name="T"/>.
    /// </summary>
    public interface IRange<T>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        T Minimum { get; }

        /// <summary>
        /// The maximul value of the range.
        /// </summary>
        T Maximum { get; }

        /// <summary>
        /// The options used to see whether a value is in a given range.
        /// </summary>
        RangeComparisonOptions RangeComparisonOptions { get; }

        /// <summary>
        /// Lists all values of <see cref="IRange{T}"/> in an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <returns>an <see cref="IEnumerable{T}"/></returns>
        IEnumerable<T> AsEnumerable();
    }    
}
