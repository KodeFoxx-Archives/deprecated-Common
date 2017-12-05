using System;
using Kf.Common.Comparison.Ranges;
using Kf.Common.Comparison.Ranges.Time;
using Kf.Common.Tests.Infrastructure;
using Xunit;

namespace Kf.Common.Tests.Comparison.Ranges.Time
{
    public class CompareDateTimeRangeTests
    {
        [Fact]
        public void Implements_ICompareRange_interface()
            => AssertExtensions.ImplementsInterface<ICompareRange<DateTime>>(
                new CompareDateTimeRange()
            );

        [Fact]
        public void Is_in_range_when_falls_in_range()
        {
            var range = GetOctober11th1985Range();
            var sut = new CompareDateTimeRange();
            Assert.True(sut.IsInRange(new DateTime(1986, 10, 1), range));
        }

        [Fact]
        public void Is_in_range_when_minimum_value_provided_and_minimum_is_included()
        {
            var range = GetOctober11th1985Range();
            var sut = new CompareDateTimeRange();
            Assert.True(sut.IsInRange(range.Minimum, range));
        }

        [Fact]
        public void Is_not_in_range_when_minimum_value_provided_and_minimum_is_excluded()
        {
            var range = GetOctober11th1985Range(RangeComparisonOptions.Create().WithMinimumExcluded());
            var sut = new CompareDateTimeRange();
            Assert.False(sut.IsInRange(range.Minimum, range));
        }

        [Fact]
        public void Is_in_range_when_maximum_value_provided_and_maximum_is_included()
        {
            var range = GetOctober11th1985Range();
            var sut = new CompareDateTimeRange();
            Assert.True(sut.IsInRange(range.Maximum, range));
        }

        [Fact]
        public void Is_not_in_range_when_maximum_value_provided_and_maximum_is_excluded()
        {
            var range = GetOctober11th1985Range(RangeComparisonOptions.Create().WithMaximumExcluded());
            var sut = new CompareDateTimeRange();
            Assert.False(sut.IsInRange(range.Maximum, range));
        }

        private DateTimeRange GetOctober11th1985Range(
            RangeComparisonOptions rangeComparisonOptions = null)
        {
            return new DateTimeRange(
                minimum: new DateTime(1985, 10, 11), 
                maximum: new DateTime(1986, 10, 11),
                rangeComparisonOptions: rangeComparisonOptions
            );
        }
    }
}
