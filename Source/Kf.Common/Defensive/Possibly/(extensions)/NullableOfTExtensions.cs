namespace Kf.Common.Defensive.Possibly
{
    public static class NullableOfTExtensions
    {
        public static IPossible<TConcrete> ToPossible<TConcrete>(this TConcrete? value)
            where TConcrete : struct
            => Possible.From(value);
    }
}
