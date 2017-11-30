using System.Collections.Generic;

namespace Kf.Common.Defensive.BuilderPattern
{
    /// <summary>
    /// Defines a contract for an object that defines whether it can build an object of <typeparamref name="T"/>.
    /// </summary>    
    public interface ICanBuild        
    {
        bool CanBuild();
        List<string> GetBuildErrors();
    }
}
