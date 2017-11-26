namespace Kf.Common.Defensive.Possibly
{
    public static class StringExtensions
    {
        public static IPossible<string> ToPossible(
            this string value, 
            StringValueParserStrategy stringValueParserStrategy = StringValueParserStrategy.NullEmptyOrWhitespaceIsNoValue
        ) => Possible.From(value, stringValueParserStrategy);
    }
}
