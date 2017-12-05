using System;
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
        public void Next_with_range_always_returns_a_value_between_the_range(int minium, int maximum)
        {            
            var sut = new SimpleInt32Random();
            var range = minium.ToRange(maximum);            
            Assert.True(range.IsInRange(sut.Next(range)));
        }

        [Fact]
        public void Next_without_range_always_returns_a_value_between_lin_and_max_of_Int32()
        {
            var sut = new SimpleInt32Random();
            var range = Int32.MinValue.ToRange(Int32.MaxValue);
            Assert.True(range.IsInRange(sut.Next()));
        }
    }
}
