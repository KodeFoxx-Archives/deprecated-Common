using System;
using Kf.Common.Comparison.Ranges.Numbers;
using Kf.Common.Randomization;
using Kf.Common.Tests.Infrastructure;
using Xunit;

namespace Kf.Common.Tests.Randomization
{
    public class TestRandomTests
    {
        [Fact]
        public void Implements_IRandom_interface()
            => AssertExtensions.ImplementsInterface<IRandom<string>>(
                TestRandom<string>.Create("testValue")
            );

        [Fact]
        public void Next_always_returns_the_same_value() {
            var expected = "testValue";
            var sut = TestRandom<string>.Create(expected);
            Assert.Equal(expected, sut.Next());
            Assert.Equal(expected, sut.Next(null));
        }

        [Fact]
        public void Next_with_range_always_returns_the_same_value()
        {
            var expected = 12;
            var sut = TestRandom<int>.Create(expected);
            Assert.Equal(expected, sut.Next(20.ToRange(50)));
        }
    }
}
