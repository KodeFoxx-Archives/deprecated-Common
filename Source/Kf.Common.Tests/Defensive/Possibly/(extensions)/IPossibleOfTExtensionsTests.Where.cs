using System.Linq;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly
{
    public partial class IPossibleOfTExtensionsTests
    {
        [Theory,
         MemberData(nameof(Sequences))]
        public void Where_produces_correct_outcome(IPossible<int>[] input, int[] expectedOutcome, int expectedLength) {
            var sut = input.Where(i => i == 1).ToList();
            Assert.NotNull(sut);
            if (expectedLength != 0) {
                Assert.Equal(1, sut.Count);
                Assert.Equal(1, sut.ElementAt(0).GetValue(-1));
            }
            else {
                Assert.Equal(0, sut.Count);
            }
        }
    }
}
