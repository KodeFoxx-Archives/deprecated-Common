using System.Collections.Generic;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly
{
    public partial class PossibleTests
    {
        [Fact]
        public void Possible_Value_produces_true_when_HasValue() {
            var sut = Possible.Value("");
            Assert.True(sut.HasValue);
        }

        [Fact]
        public void Possible_Value_produces_inputted_value_on_GetValue_with_defaultValue() {
            var inputValue = "inputValue";
            var defaultValue = "defaultValue";
            var sut = Possible.Value(inputValue);
            Assert.Equal(inputValue, sut.GetValue(defaultValue));
        }

        [Fact]
        public void Possible_Value_produces_inputted_value_on_GetValue_with_defaultValueProvider()
        {
            var inputValue = "inputValue";
            var defaultValue = "defaultValue";
            var sut = Possible.Value(inputValue);
            Assert.Equal(inputValue, sut.GetValue(() => defaultValue));
        }

        [Fact]
        public void Possible_Value_executes_action() {
            var inputtedValue = "value";
            var sut = Possible.Value(inputtedValue);
            var strings = new List<string>();
            sut.Execute(s => strings.Add(s));
            Assert.NotEmpty(strings);
            Assert.Contains(inputtedValue, strings);
        }

        [Fact]
        public void Possible_Value_executes_mapping_and_returns_new_possible_value()
        {
            var inputtedValue = "value";
            var sut = Possible.Value(inputtedValue);            
            var result = sut.Map(s => s.ToUpper());
            Assert.NotNull(result);
            Assert.True(result.HasValue);
        }        
    }
}
