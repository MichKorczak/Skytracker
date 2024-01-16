using System.Reflection;

namespace Skytracker.Application;

public static class SkytrackerApplicationAssembly
{
    public static Assembly GetAssembly => Assembly.GetExecutingAssembly()!;
}
