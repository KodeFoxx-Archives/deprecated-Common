using Kf.Common.Comparison.Ranges.Numbers;
using Kf.Common.Randomization;
using Kf.Common.Tests.Infrastructure;
using Xunit;

namespace Kf.Common.Tests.Randomization
{
    class SimpleInt32RandomTests
    {
        [Fact]
        public void Implements_IRandom_interface()
            => AssertExtensions.ImplementsInterface<IRandom<int>>(
                new SimpleInt32Random()
            );        

        [Theory,
         InlineData(0, 5), InlineData(0, 10), InlineData(-5, 5),
         InlineData(8, 10), InlineData(9, 10), InlineData(-10, -5)]
        public void Next_with_range_always_returns_the_same_value(int minium, int maximum)
        {            
            var sut = new SimpleInt32Random();
            var range = minium.ToRange(maximum);            
            Assert.True(range.IsInRange(sut.Next(range)));
        }
    }
}
