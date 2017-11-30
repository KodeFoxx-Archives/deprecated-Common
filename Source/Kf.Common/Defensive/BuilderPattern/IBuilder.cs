namespace Kf.Common.Defensive.BuilderPattern
{
    /// <summary>
    /// Marker interface
    /// </summary>
    public interface IBuilder { }

    /// <summary>
    /// Defines a contract for an object builder.
    /// </summary>    
    public interface IBuilder<TObject> : IBuilder
        where TObject : class
    {
        TObject Build();
    }    
}
