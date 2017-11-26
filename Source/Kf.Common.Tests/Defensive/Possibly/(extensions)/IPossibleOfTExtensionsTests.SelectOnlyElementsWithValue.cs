using System.Collections.Generic;
using System.Linq;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly
{
    public partial class IPossibleOfTExtensionsTests
    {
        private static IEnumerable<object[]> Sequences() {
            return new List<object[]> {
                new object[] {
                    new[] {1.ToPossible(), 2.ToPossible(), 3.ToPossible()},
                    new[] {1, 2, 3},
                    3
                },
                new object[] {
                    new[] {1.ToPossible(), Possible.NoValue<int>(), 3.ToPossible()},
                    new[] {1, 3},
                    2
                },
                new object[] {
                    new[] { Possible.NoValue<int>(), Possible.NoValue<int>(), Possible.NoValue<int>() },
                    new int[] { },
                    0
                },
                new object[] {
                    new IPossible<int>[] { },
                    new int[] { },
                    0
                },
                new object[] {
                    null,
                    new int[] { },
                    0
                }
            };
        }

        [Theory,
         MemberData(nameof(Sequences))]
        public void SelectOnlyWithValue_produces_correct_outcome(IPossible<int>[] input, int[] expectedOutcome, int expectedLength) {
            var sut = input.SelectElementsWithValue().ToList();
            Assert.NotNull(sut);
            Assert.Equal(expectedLength, sut.Count);
            Assert.Equal(expectedOutcome.ToList(), sut);
        }
    }
}
