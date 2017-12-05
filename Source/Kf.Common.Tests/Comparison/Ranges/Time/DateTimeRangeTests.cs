using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Common.Comparison.Ranges;
using Kf.Common.Comparison.Ranges.Numbers;
using Kf.Common.Comparison.Ranges.Time;
using Kf.Common.Tests.Infrastructure;
using Xunit;

namespace Kf.Common.Tests.Comparison.Ranges.Time
{
    public class DateTimeRangeTests
    {
        [Fact]
        public void Implements_IRange_interface()
            => AssertExtensions.ImplementsInterface<IRange<DateTime>>(
                new DateTimeRange(DateTime.MinValue, DateTime.MaxValue)
            );

        private static IEnumerable<object[]> AsEnumerableTestData()
        {
            return new List<object[]> {

                new object[] {
                    new DateTimeRange(
                        new DateTime(1985, 10, 11),
                        new DateTime(1985, 10, 12)
                    ),
                    2
                },
            };
        }

        [Theory,
         MemberData(nameof(AsEnumerableTestData))]
        public void AsEnumerable_returns_correct_values(IRange<DateTime> sut, int expectedDays)
        {
            Assert.NotNull(sut.AsEnumerable());
            var actualDays = sut.AsEnumerable().Select(x => x.Date).Distinct();
            Assert.Equal(expectedDays, actualDays.Count());
        }
    }
}
