using Kf.Common.Comparison.Ranges;
using Kf.Common.Comparison.Ranges.Numbers;
using Kf.Common.Randomization;
using Kf.Common.Tests.Infrastructure;
using Xunit;

namespace Kf.Common.Tests.Randomization
{
    public class SimpleBooleanRandomTests
    {

        [Fact]
        public void Implements_IRandom_interface()
            => AssertExtensions.ImplementsInterface<IRandom<bool>>(
                new SimpleBooleanRandom()
            );

        [Fact]
        public void Next_with_range_set_to_false_always_returns_false()
        {            
            var sut = new SimpleBooleanRandom();
            Assert.False(sut.Next(new Range<bool>(false, false)));
        }

        [Fact]
        public void Next_with_range_set_to_true_always_returns_true()
        {
            var sut = new SimpleBooleanRandom();
            Assert.True(sut.Next(new Range<bool>(true, true)));
        }
    }
}
