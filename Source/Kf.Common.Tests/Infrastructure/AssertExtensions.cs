using System.Runtime.InteropServices.ComTypes;
using Xunit;

namespace Kf.Common.Tests.Infrastructure
{
    public static class AssertExtensions
    {
        public static void ImplementsInterface<T>(object @object)
        {
            Assert.NotNull(@object);
            var expectedType = typeof(T);
            var actualType = @object
                .GetType()
                .GetInterface(expectedType.Name, ignoreCase: true);
            Assert.Equal(expectedType, actualType);
        }
    }
}
