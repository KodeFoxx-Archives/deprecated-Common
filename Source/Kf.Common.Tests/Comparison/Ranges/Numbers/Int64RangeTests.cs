using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Common.Comparison.Ranges;
using Kf.Common.Comparison.Ranges.Numbers;
using Kf.Common.Tests.Infrastructure;
using Xunit;

namespace Kf.Common.Tests.Comparison.Ranges.Numbers
{
    public class Int64RangeTests
    {
        [Fact]
        public void Implements_IRange_interface()
            => AssertExtensions.ImplementsInterface<IRange<long>>(
                0L.ToRange(1)
            );

        private static IEnumerable<object[]> AsEnumerableTestData() {            
            return new List<object[]> {

                new object[] {
                    0L.ToRange(0), new long[] { 0 }
                },
                
                new object[] {
                    (-60L).ToRange(60), Enumerable.Range(-60, 121).Select(x => (long)x).ToArray()
                },
                new object[] {
                    (-60L).ToRange(-60), new long[] { -60 }
                },

                new object[] {
                    0L.ToRange(10),
                    new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
                },

                new object[] {
                    (-2L).ToRange(5),
                    new long[] { -2, -1, 0, 1, 2, 3, 4, 5 }
                },

                new object[] {
                    (-5L).ToRange(4582),
                    Enumerable.Range(-5, 4588).ToList().Select(x => (long)x).ToArray()
                },
            };            
        }

        [Theory,
         MemberData(nameof(AsEnumerableTestData))]
        public void AsEnumerable_returns_correct_values(IRange<long> sut, IEnumerable<long> expected) {            
            Assert.NotNull(sut.AsEnumerable());
            Assert.Equal(expected.Count(), sut.AsEnumerable().Count());
            Assert.Equal(expected.ToArray(), sut.AsEnumerable().ToArray());
        }
    }
}
