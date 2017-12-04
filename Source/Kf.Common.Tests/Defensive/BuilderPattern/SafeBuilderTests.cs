using System.Collections.Generic;
using System.Linq;
using Kf.Common.Defensive.BuilderPattern;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.BuilderPattern
{
    public class SafeBuilderTests
    {
        [Fact]
        public void Can_not_build_when_string_is_not_defined_as_specified_in_GetBuildErrors()
        {
            var sut = new SafeFakeObjectBuilder();
            Assert.False(sut.CanBuild());
            Assert.Throws<CanNotBuildException<SafeFakeObjectBuilder>>(() => sut.Build());
        }

        [Fact]
        public void Can_build_when_string_is_defined_as_specified_in_GetBuildErrors()
        {
            var expectedValue = "ExpectedValue";
            var sut = new SafeFakeObjectBuilder();
            sut.With(x => x.String, expectedValue);
            Assert.True(sut.CanBuild());
            Assert.Equal(expectedValue, sut.Build().String);            
        }
    }

    public class SafeFakeObjectBuilder : SafeBuilder<FakeObject, SafeFakeObjectBuilder>
    {
        public override IEnumerable<string> GetBuildErrors()
        {
            var stringProperty = _values.Keys.Where(k => k.Name == nameof(FakeObject.String)).FirstOrNoValue();
            if (!stringProperty.HasValue) yield return $"{nameof(FakeObject.String)} property is not defined.";            
        }
    }
        
}
