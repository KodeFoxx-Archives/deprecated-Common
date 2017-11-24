using System.Diagnostics;

namespace Kf.Common.Defensive.Possibly
{    
    public interface IPossiblyHaveAValue
    {
        /// <summary>
        /// Indicates whether a value is present or not.
        /// </summary>
        bool HasValue { get; }
    }
}
