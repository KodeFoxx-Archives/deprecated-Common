using System.Collections.Generic;
using Kf.Common.Comparison.Ranges;
using Xunit;

namespace Kf.Common.Tests.Comparison.Ranges
{
    public class RangeComparisonOptionsBuilderTests
    {
        [Fact]
        public void Build_without_options_yields_minimum_and_maximum_included() {
            RangeComparisonOptions sut = RangeComparisonOptions.Create();
            Assert.True(sut.IsMinimumIncluded);
            Assert.True(sut.IsMaximumIncluded);
        }

        private static IEnumerable<object[]> BuildScenarios() {
            return new List<object[]> {
                new object[] {
                    "Default build",
                    RangeComparisonOptions.Create(),
                    true, true,
                },
                new object[] {
                    "Minimum included, Maximum excluded",
                    RangeComparisonOptions.Create()
                        .WithMaximumExcluded(),
                    true, false,
                },
                new object[] {
                    "Minimum included, Maximum excluded",
                    RangeComparisonOptions.Create()
                        .WithMinimumIncluded()
                        .WithMaximumExcluded(),
                    true, false,
                },
                new object[] {
                    "Minimum excluded, Maximum excluded",
                    RangeComparisonOptions.Create()
                        .WithMinimumExcluded()
                        .WithMaximumExcluded(),
                    false, false,
                },
                new object[] {
                    "Minimum excluded, Maximum included",
                    RangeComparisonOptions.Create()
                        .WithMinimumExcluded(),
                    false, true,
                },
                new object[] {
                    "Minimum excluded, Maximum included",
                    RangeComparisonOptions.Create()
                        .WithMaximumIncluded()
                        .WithMinimumExcluded(),
                    false, true,
                },
            };
        }

        [Theory,
         MemberData(nameof(BuildScenarios))]
        public void Build_with_options(string scenario, RangeComparisonOptionsBuilder builder, 
            bool expectedMinimumIncluded, bool expectedMaximumIncluded) {
            RangeComparisonOptions sut = builder;
            Assert.Equal(expectedMinimumIncluded, sut.IsMinimumIncluded);
            Assert.Equal(expectedMaximumIncluded, sut.IsMaximumIncluded);
        }
    }
}
