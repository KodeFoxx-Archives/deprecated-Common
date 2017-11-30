using Kf.Common.Comparison.Ranges;
using Kf.Common.Comparison.Ranges.Numbers;
using Xunit;

namespace Kf.Common.Tests.Comparison.Ranges.Numbers
{
    public class CompareInt64RangeTests
    {
        [Fact]
        public void IsInRange_With_Value_In_Range_Returns_True()
        {
            IRange<long> range = new Int64Range(0, 100);
            var sut = new CompareInt64Range();
            Assert.True(sut.IsInRange(10, range));
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_With_Minimum_Excluded_Returns_True()
        {
            IRange<long> range = new Int64Range(0, 100, RangeComparisonOptions.New().WithMinimumExcluded().Build());
            var sut = new CompareInt64Range();
            Assert.True(sut.IsInRange(1, range));            
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_With_Maximum_Excluded_Returns_True()
        {                        
            IRange<long> range = new Int64Range(0, 100, RangeComparisonOptions.New().WithMaximumExcluded().Build());
            var sut = new CompareInt64Range();
            Assert.True(sut.IsInRange(99, range));            
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_Returns_True()
        {
            IRange<long> range = new Int64Range(0, 100);
            var sut = new CompareInt64Range();
            Assert.True(sut.IsInRange(0, range));                       
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_Returns_False()
        {
            IRange<long> range = new Int64Range(0, 100);
            var sut = new CompareInt64Range();
            Assert.False(sut.IsInRange(-5, range));            
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_With_Minimum_Excluded_Returns_False()
        {            
            IRange<long> range = new Int64Range(0, 100, RangeComparisonOptions.New().WithMinimumExcluded().Build());
            var sut = new CompareInt64Range();
            Assert.False(sut.IsInRange(0, range));
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_With_Maximum_Excluded_Returns_False()
        {
            IRange<long> range = new Int64Range(0, 100, RangeComparisonOptions.New().WithMaximumExcluded().Build());
            var sut = new CompareInt64Range();
            Assert.False(sut.IsInRange(100, range));            
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_Returns_False()
        {
            IRange<long> range = new Int64Range(0, 100);
            var sut = new CompareInt64Range();
            Assert.False(sut.IsInRange(-1, range));
        }
    }
}
