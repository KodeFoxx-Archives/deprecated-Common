using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Common.Comparison.Ranges;
using Kf.Common.Comparison.Ranges.Numbers;
using Xunit;

namespace Kf.Common.Tests.Comparison.Ranges.Numbers
{
    public class Int64RangeTests
    {
        private static IEnumerable<object[]> AsEnumerableTestData() {            
            return new List<object[]> {

                new object[] {
                    new Int64Range(0, 0), new long[] { 0 }
                },
                new object[] {
                    new Int64Range(-60, -60), new long[] { -60 }
                },

                new object[] {
                    new Int64Range(0, 10),
                    new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
                },

                new object[] {
                    new Int64Range(-2, 5),                    
                    new long[] { -2, -1, 0, 1, 2, 3, 4, 5 }
                },

                new object[] {
                    new Int64Range(-5, 4582),
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
