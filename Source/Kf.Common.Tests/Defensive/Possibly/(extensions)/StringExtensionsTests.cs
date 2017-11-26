using System;
using System.Collections.Generic;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly
{
    public class StringExtensionsTests
    {
        [Theory,
         MemberData(nameof(StringValues))]
        public void From_string_produces_correct_value_object(string value, bool expectedHasValue, StringValueParserStrategy stringValueParserStrategy)
        {
            var sut = value.ToPossible(stringValueParserStrategy);
            Assert.Equal(expectedHasValue, sut.HasValue);
        }

        private static IEnumerable<object[]> StringValues()
        {
            return new List<object[]> {
                new object[] {
                    null, false, StringValueParserStrategy.NullEmptyOrWhitespaceIsNoValue
                },
                new object[] {
                    String.Empty, false, StringValueParserStrategy.NullEmptyOrWhitespaceIsNoValue
                },
                new object[] {
                    "", false, StringValueParserStrategy.NullEmptyOrWhitespaceIsNoValue
                },
                new object[] {
                    "  ", false, StringValueParserStrategy.NullEmptyOrWhitespaceIsNoValue
                },
                new object[] {
                    "value", true, StringValueParserStrategy.NullEmptyOrWhitespaceIsNoValue
                },

                new object[] {
                    null, false, StringValueParserStrategy.NullOrEmptyIsNoValue
                },
                new object[] {
                    String.Empty, false, StringValueParserStrategy.NullOrEmptyIsNoValue
                },
                new object[] {
                    "", false, StringValueParserStrategy.NullOrEmptyIsNoValue
                },
                new object[] {
                    "  ", true, StringValueParserStrategy.NullOrEmptyIsNoValue
                },
                new object[] {
                    "value", true, StringValueParserStrategy.NullOrEmptyIsNoValue
                },
            };
        }
    }
}
