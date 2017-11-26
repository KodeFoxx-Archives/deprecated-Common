using System.Collections.Generic;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly
{
    public class NullableOfTExtensionsTests
    {
        [Theory,
         MemberData(nameof(NullableValues))]
        public void From_nullable_produces_correct_value_object(int? value, bool expectedHasValue)
        {
            var sut = value.ToPossible();
            Assert.Equal(expectedHasValue, sut.HasValue);
            if (sut.HasValue)
                Assert.Equal(value.Value, sut.GetValue(-1));
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
    }
}
