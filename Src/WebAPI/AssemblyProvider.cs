using System.Reflection;
using Kasp1_Review;
using Tasks;

namespace Environment;

public static class AssemblyProvider
{
    public static Assembly[] All => new[]
    {
        ReviewersUtilityAssemblyStash.Current,
        typeof(Startup).Assembly
    };
}