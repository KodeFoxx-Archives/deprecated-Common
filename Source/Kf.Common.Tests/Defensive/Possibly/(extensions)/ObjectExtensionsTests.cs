using System;
using System.Collections.Generic;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly
{
    public class ObjectExtensionsTests
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
        public void From_produces_correct_value_object(object value, bool expectedHasValue, Func<object, bool> hasValueDeterminator) {
            var sut = value.ToPossible(hasValueDeterminator);
            Assert.Equal(expectedHasValue, sut.HasValue);
        }
    }
}
