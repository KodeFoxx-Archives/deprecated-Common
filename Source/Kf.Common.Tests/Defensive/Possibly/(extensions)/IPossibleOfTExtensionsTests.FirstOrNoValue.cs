using System.Linq;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly
{
    public partial class IPossibleOfTExtensionsTests
    {
        [Theory,
         MemberData(nameof(Sequences))]
        public void FirstOrNoValue_produces_correct_outcome(IPossible<int>[] input, int[] expectedOutcome, int expectedLength) {
            var sut = input.FirstOrNoValue();
            Assert.NotNull(sut);
            Assert.Equal(expectedLength != 0, sut.HasValue);
            if (expectedLength != 0)
                Assert.Equal(expectedOutcome.First(), sut.GetValue(-1));
        }
    }
}
