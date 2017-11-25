using System.Collections.Generic;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly
{
    public partial class PossibleTests
    {
        [Fact]
        public void Possible_NoValue_produces_sequence_that_contains_inputted_value_on_AsEnumerable()
        {
            var inputValue = "inputValue";
            var sut = Possible.Value(inputValue);
            Assert.NotEmpty(sut.AsEnumerable());
            Assert.Contains(inputValue, sut.AsEnumerable());
        }

        [Fact]
        public void Possible_NoValue_produces_false_when_HasValue()
        {
            var sut = Possible.NoValue<string>();
            Assert.False(sut.HasValue);
        }

        [Fact]
        public void Possible_NoValue_produces_defaultValue_on_GetValue_with_defaultValue()
        {
            var defaultValue = "defaultValue";
            var sut = Possible.NoValue<string>();
            Assert.Equal(defaultValue, sut.GetValue(defaultValue));
        }

        [Fact]
        public void Possible_NoValue_produces_defaultValue_on_GetValue_with_defaultValueProvider()
        {
            var defaultValue = "defaultValue";
            var sut = Possible.NoValue<string>();
            Assert.Equal(defaultValue, sut.GetValue(() => defaultValue));
        }

        [Fact]
        public void Possible_NoValue_produces_empty_sequence_on_AsEnumerable()
        {
            var sut = Possible.NoValue<string>();
            Assert.Empty(sut.AsEnumerable());
        }

        [Fact]
        public void Possible_NoValue_doesnt_execute_action()
        {
            var sut = Possible.NoValue<string>();
            var strings = new List<string>();
            sut.Execute(s => strings.Add(s));
            Assert.Empty(strings);
        }

        [Fact]
        public void Possible_NoValue_doesnt_execute_mapping_and_returns_new_possible_NoValue()
        {
            var sut = Possible.NoValue<string>();
            var result = sut.Map(s => s.ToUpper());
            Assert.NotNull(result);
            Assert.False(result.HasValue);
        }
    }
}
