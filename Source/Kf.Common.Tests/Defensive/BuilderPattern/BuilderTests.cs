using Kf.Common.Defensive.BuilderPattern;
using Xunit;

namespace Kf.Common.Tests.Defensive.BuilderPattern
{
    public class BuilderTests
    {
        [Fact]
        public void Can_set_property_of_an_object()
        {
            var expectedValue = "ExpectedValue";
            var sut = new FakeObjectBuilder();
            sut.With(x => x.String, expectedValue);
            Assert.Equal(expectedValue, sut.Build().String);
        }

        [Fact]
        public void Can_set_property_via_private_setter_of_an_object()
        {
            var expectedValue = 6587954L;
            var sut = new FakeObjectBuilder();
            sut.With(x => x.PrivateSetterInt64, expectedValue);
            Assert.Equal(expectedValue, sut.Build().PrivateSetterInt64);
        }

        [Fact]
        public void Can_not_set_a_readonly_property()
        {
            var sut = new FakeObjectBuilder();
            Assert.Throws<CanNotBuildException<FakeObjectBuilder>>(() =>
                sut.With(x => x.ReadOnlyInt, 50).Build()
            );
        }
    }

    public class FakeObject
    {
        public string String { get; set; }
        public int ReadOnlyInt { get; }
        public long PrivateSetterInt64 { get; private set; }
        public int SomeInt { get; private set; }
        
        private FakeObject() { } // needs to be provided
    }

    public class FakeObjectBuilder : Builder<FakeObject, FakeObjectBuilder>
    {
        // You can define your builder methods here in addition to the "With" method that's provided with the base class.
        // E.g.: WithInt64ToZero()
        public FakeObjectBuilder WithInt64ToZero()
            => With(x => x.PrivateSetterInt64, 0);
    }
}
