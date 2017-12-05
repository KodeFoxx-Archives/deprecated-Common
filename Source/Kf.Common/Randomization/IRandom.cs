using Kf.Common.Comparison.Ranges;

namespace Kf.Common.Randomization
{
    /// <summary>
    /// Defines a contract that generates a random value of <typeparamref name="T"/>.
    /// </summary>    
    public interface IRandom<T>
    {
        /// <summary>
        /// Returns a random value of <typeparamref name="T"/>.
        /// </summary>        
        T Next();

        /// <summary>
        /// Returns a random value of <typeparamref name="T"/> withing the specified range.
        /// </summary>
        T Next(IRange<T> range);
    }
}
