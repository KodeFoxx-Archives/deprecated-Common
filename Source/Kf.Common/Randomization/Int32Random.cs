using System;
using System.Net.Http.Headers;
using Kf.Common.Comparison.Ranges;
using Kf.Common.Defensive.Possibly;

namespace Kf.Common.Randomization
{
    /// <summary>
    /// Implementation of <see cref="IRandom{T}"/> that wraps <see cref="System.Random"/>.    
    /// </summary>    
    public sealed class Int32Random : IRandom<int>
    {        
        private static readonly Random _staticRandom = new Random();
        private readonly IPossible<Random> _possibleRandom;

        public Int32Random(int? seed = null)
            => _possibleRandom = 
                seed.HasValue
                    ? new Random(seed.Value).ToPossible()
                    : Possible.NoValue<Random>();

        public int Next()
            => GetRandomInstance().Next();

        public int Next(IRange<int> range)
            => GetRandomInstance().Next(range.Minimum, range.Maximum);

        private Random GetRandomInstance()
            => _possibleRandom.GetValue(_staticRandom);
    }
}
