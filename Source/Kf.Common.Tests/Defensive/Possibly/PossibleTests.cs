using System.Collections.Generic;
using Kf.Common.Defensive.Possibly;
using Xunit;

namespace Kf.Common.Tests.Defensive.Possibly
{
    public class PossibleTests
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
