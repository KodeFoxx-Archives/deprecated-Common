namespace Kf.Common.Defensive.BuilderPattern
{
    /// <summary>
    /// Marks a builder that also checks whether it can build the object before doing so.
    /// </summary>    
    public interface ISafeBuilder<TObject> 
        : IBuilder<TObject>, ICanBuild
        where TObject : class
    { }
}
