using System;
using System.Linq;

namespace Kf.Common.Defensive.Possibly.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            // One can convert any object ot IPossible<T>
            var possibleIntViaStaticMethod = Possible.From(1);
            var possibleIntViaExtensionsMethod = 1.ToPossible();
            
            // That way, when an object contains null,
            // and you wouldn't know it beforehand
            // the Possible class will take that into account for you:            
            int? nullableInt = null;
            var possibleIntFromNullableViaStaticMethod = Possible.From(nullableInt);
            var posibleIntFromNullableViaExtensionMethod = nullableInt.ToPossible();
            object @object = null;
            var possibleObjectViaStaticMethod = Possible.From(@object);
            var possibleObjectViaExtensionMethod = @object.ToPossible();
            
            // You can pass in an optional lambda to determine whether an object is null or not, 
            // used below is the default expression when you pass no lambda
            // which just checks whether the object is not null, then Possible.From
            // assumes you have a value by "convention":
            possibleObjectViaStaticMethod = Possible.From(@object, o => o != null);
            possibleObjectViaExtensionMethod = @object.ToPossible(o => o != null);

            // For string objects you can define a parsing strategy,
            // the default one is StringValueParserStrategy.NullEmptyOrWhitespaceIsNoValue
            // which translates to String.IsNullOrWhiteSpace()
            var possibleStringViaStaticMethod = Possible.From(" ");
            var possibleStringViaExtensionMethod = " ".ToPossible();
            possibleStringViaStaticMethod = Possible.From(" ", StringValueParserStrategy.NullOrEmptyIsNoValue);
            possibleStringViaExtensionMethod = " ".ToPossible(StringValueParserStrategy.NullOrEmptyIsNoValue);

            // Given a possible object, one can get the original value back,
            // but since you have no idea whether it contains a value or not,
            // you are always obliged to pass in either a fixed default value
            // or a function the produces a default value
            var possible = "".ToPossible();
            var real = possible.GetValue(""); // pass in a fixed value as the default
            real = possible.GetValue(() => String.Empty); // pass in a function the produces a default value

            // One can also check via a boolean property whether a possible
            // has a value or not. But to avoid if-else branching in the code
            // too much, we'd advice to use this as a last resort
            var hasValue = possible.HasValue;

            // Better is to use the methods Execute or Map
            // - Execute will perform an action on the value when it is present
            possible.Execute(value => Console.WriteLine(value));
            // - Map will perform a function on the value if it is present,
            //   and produce a new possible result.
            var newPossibleResult = possible.Map(value => value.Length);

            // Extension methods provide options to be more flexible with
            // collections of possible types
            var collectionOfPossibleInts = new[] {1, 2, 3, 4, 5}.Select(i => i.ToPossible());
            // - SelectElementsWithValue will only return the elements with a value
            var sumOfelementsWithValue = collectionOfPossibleInts
                .SelectElementsWithValue()
                .Sum();
            // - MapElementsWithValue will only operate a mapping function on elements with a value
            //   and return back a collection of concrete results.
            //   Hence why you have to return a "possible" result in the function, so that 
            //   the mapping function can automatically apply the SelectElementsWithValue
            //   method on it.
            var mappedElementsWithValue = collectionOfPossibleInts
                .MapElementsWithValue(i => i.ToString().ToPossible());
            // - FirstOrNoValue is the replacement for Linq's FirstOrDefault
            var firstOrNoValueResult = collectionOfPossibleInts
                .FirstOrNoValue();
        }
    }
}
