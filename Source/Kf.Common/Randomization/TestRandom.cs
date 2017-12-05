using Kf.Common.Comparison.Ranges;

namespace Kf.Common.Randomization
{
    /// <summary>
    /// Implementation of <see cref="IRandom{T}"/> that always returns the same value,
    /// intended for use in unit tests.
    /// </summary>    
    public sealed class TestRandom<T> : IRandom<T>
    {
        public static TestRandom<T> Create(T value)
            => new TestRandom<T>(value);

        private readonly T _value;

        private TestRandom(T value) => _value = value;        

        public T Next() 
            => _value;

        public T Next(IRange<T> range) 
            => _value;
    }
}
