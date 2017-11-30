using System.Collections.Generic;
using Kf.Common.Comparison.Ranges;
using Xunit;

namespace Kf.Common.Tests.Comparison.Ranges
{
    public class RangeComparisonOptionsBuilderTests
    {
        [Fact]
        public void Build_without_options_yields_minimum_and_maximum_included() {
            var sut = RangeComparisonOptions.New().Build();
            Assert.True(sut.IsMinimumIncluded);
            Assert.True(sut.IsMaximumIncluded);
        }

        private static IEnumerable<object[]> BuildScenarios() {
            return new List<object[]> {
                new object[] {
                    "Default build",
                    RangeComparisonOptions.New(),
                    true, true,
                },
                new object[] {
                    "Minimum included, Maximum excluded",
                    RangeComparisonOptions.New()
                        .WithMaximumExcluded(),
                    true, false,
                },
                new object[] {
                    "Minimum included, Maximum excluded",
                    RangeComparisonOptions.New()
                        .WithMinimumIncluded()
                        .WithMaximumExcluded(),
                    true, false,
                },
                new object[] {
                    "Minimum excluded, Maximum excluded",
                    RangeComparisonOptions.New()
                        .WithMinimumExcluded()
                        .WithMaximumExcluded(),
                    false, false,
                },
                new object[] {
                    "Minimum excluded, Maximum included",
                    RangeComparisonOptions.New()
                        .WithMinimumExcluded(),
                    false, true,
                },
                new object[] {
                    "Minimum excluded, Maximum included",
                    RangeComparisonOptions.New()
                        .WithMaximumIncluded()
                        .WithMinimumExcluded(),
                    false, true,
                },
            };
        }

        [Theory,
         MemberData(nameof(BuildScenarios))]
        public void Build_with_options(string scenario, RangeComparsionOptionsBuilder sut, 
            bool expectedMinimumIncluded, bool expectedMaximumIncluded)
        {
            Assert.Equal(expectedMinimumIncluded, sut.Build().IsMinimumIncluded);
            Assert.Equal(expectedMaximumIncluded, sut.Build().IsMaximumIncluded);
        }
    }
}
