using System.Collections.Generic;
using System.Linq;
using Kf.Common.Comparison.Ranges;
using Kf.Common.Comparison.Ranges.Numbers;
using Xunit;

namespace Kf.Common.Tests.Comparison.Ranges.Numbers
{
    public class Int16RangeTests
    {
        private static IEnumerable<object[]> AsEnumerableTestData() {            
            return new List<object[]> {

                new object[] {
                    new Int16Range(0, 0), new short[] { 0 }
                },
                new object[] {
                    new Int16Range(-60, -60), new short[] { -60 }
                },

                new object[] {
                    new Int16Range(0, 10),
                    new short[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
                },

                new object[] {
                    new Int16Range(-5, 5),                    
                    new short[] { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 }
                },                
            };            
        }

        [Theory,
         MemberData(nameof(AsEnumerableTestData))]
        public void AsEnumerable_returns_correct_values(IRange<short> sut, IEnumerable<short> expected) {            
            Assert.NotNull(sut.AsEnumerable());
            Assert.Equal(expected.Count(), sut.AsEnumerable().Count());
            Assert.Equal(expected, sut.AsEnumerable().ToArray());
        }
    }
}
