namespace Kf.Common.Comparison.Ranges
{
    /// <summary>
    /// Specifies a contract for an object that compares an <see cref="IRange{T}"/>.
    /// </summary>    
    public interface ICompareRange<T>
    {
        /// <summary>
        /// Determines whether the given value of <typeparamref name="T"/> is within the range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="range">The range the value will be checked against.</param>
        /// <returns>True when in range, false when not in range.</returns>
        bool IsInRange(T value, IRange<T> range);
    }
}
