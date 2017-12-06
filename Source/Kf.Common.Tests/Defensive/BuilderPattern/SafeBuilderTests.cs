using System.Collections.Generic;
using Kf.Common.Defensive.BuilderPattern;
using Xunit;

namespace Kf.Common.Tests.Defensive.BuilderPattern
{
    public class SafeBuilderTests
    {
        [Fact]
        public void Can_not_build_when_no_values_are_defined()
        {
            var sut = new SafeFakeObjectBuilder();
            Assert.False(sut.CanBuild());
            Assert.Throws<CanNotBuildException<SafeFakeObjectBuilder>>(() => sut.Build());
        }

        [Fact]
        public void Can_not_build_when_no_value_set_for_SomeInt()
        {
            var sut = new SafeFakeObjectBuilder()
                .With(x => x.String, "Some string");
            var exceptions = sut.GetBuildErrors();
            Assert.False(sut.CanBuild());
            Assert.Throws<CanNotBuildException<SafeFakeObjectBuilder>>(() => sut.Build());
        }

        [Theory, InlineData(0), InlineData(10)]
        public void Can_build_when_value_is_set_for_SomeInt(int someIntValue)
        {
            var sut = new SafeFakeObjectBuilder()
                .With(x => x.String, "Some string")
                .With(x => x.SomeInt, someIntValue);
            Assert.True(sut.CanBuild());            
        }

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
            sut.With(x => x.String, expectedValue).With(x => x.SomeInt, 0);
            Assert.True(sut.CanBuild());
            Assert.Equal(expectedValue, sut.Build().String);            
        }
    }

    public class SafeFakeObjectBuilder : SafeBuilder<FakeObject, SafeFakeObjectBuilder>
    {
        public override IEnumerable<string> GetBuildErrors() {
            if (!HasValues()) yield return "Has no values";

            if (!TryGetValue(f => f.String, out var stringPropertyValue))
                yield return $"{nameof(FakeObject.String)} property is not defined.";

            if(!TryGetValue(f => f.SomeInt, out var someIntPropertyValue))
                yield return $"{nameof(FakeObject.SomeInt)} property is not defined.";
        }
    }
        
}
