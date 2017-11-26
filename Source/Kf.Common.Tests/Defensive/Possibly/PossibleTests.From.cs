using System;
using System.Collections.Generic;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly
{
    public partial class PossibleTests
    {
        private static IEnumerable<object[]> ObjectValues()
        {
            return new List<object[]>
            {
                new object[] {
                    null, false, null
                },
                new object[] {
                    new object(), true, null
                },
                new object[] {
                    0, true, null
                },
                new object[] {
                    0, false, new Func<object, bool>(v => (int)v != 0)
                },
                new object[] {
                    0, false, new Func<object, bool>(v => (int)v > 0)
                },
                new object[] {
                    -1, false, new Func<object, bool>(v => (int)v > 0)
                },
                new object[] {
                    1, true, new Func<object, bool>(v => (int)v > 0)
                },
            };
        }

        [Theory,
         MemberData(nameof(ObjectValues))]
        public void From_produces_correct_value_object(object value, bool expectedHasValue, Func<object, bool> hasValueDeterminator)
        {
            var sut = Possible.From(value, hasValueDeterminator);
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

        [Theory,
         MemberData(nameof(StringValues))]
        public void From_string_produces_correct_value_object(string value, bool expectedHasValue, StringValueParserStrategy stringValueParserStrategy)
        {
            var sut = Possible.From(value, stringValueParserStrategy);
            Assert.Equal(expectedHasValue, sut.HasValue);            
        }

        private static IEnumerable<object[]> NullableValues()
        {
            return new List<object[]> {
                new object[] {
                    null, false
                },
                new object[] {
                    0, true
                },
                new object[] {
                    1, true
                },
            };
        }

        [Theory,
         MemberData(nameof(NullableValues))]
        public void From_nullable_produces_correct_value_object(int? value, bool expectedHasValue)
        {
            var sut = Possible.From(value);
            Assert.Equal(expectedHasValue, sut.HasValue);
            if (sut.HasValue)
                Assert.Equal(value.Value, sut.GetValue(-1));
        }
    }
}
