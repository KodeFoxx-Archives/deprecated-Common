namespace Kf.Common.Defensive.ObjectBuilder
{
    /// <summary>
    /// Defines a contract for an object that defines whether it can build an object of <typeparamref name="T"/>.
    /// </summary>    
    public interface ICanBuild<T>
    {
        bool CanBuild();
    }
}
