using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly._extensions_
{
    public partial class IPossibleOfTExtensionsTests
    {
        [Theory,
         MemberData(nameof(Sequences))]
        public void MapElementsWithValue_produces_correct_outcome(IPossible<int>[] input, int[] expectedOutcome, int expectedLength) {
            var sut = input.MapElementsWithValue(i => (i * 10).ToPossible()).ToList();            
            Assert.NotNull(sut);
            Assert.Equal(expectedLength, sut.Count);
            Assert.Equal(expectedOutcome.Select(i => i * 10).ToList(), sut);
        }
    }
}
