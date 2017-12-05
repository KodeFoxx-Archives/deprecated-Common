using Kf.Common.Comparison.Ranges;
using Kf.Common.Comparison.Ranges.Numbers;

namespace Kf.Common.Randomization
{
    public sealed class SimpleBooleanRandom : IRandom<bool>
    {
        private static readonly IRandom<int> _random = new SimpleInt32Random();

        public bool Next()
            => _random.Next(1.ToRange(2)) == 1;

        public bool Next(IRange<bool> range)
            => range.Minimum == range.Maximum
                ? range.Minimum
                : Next();
    }
}
