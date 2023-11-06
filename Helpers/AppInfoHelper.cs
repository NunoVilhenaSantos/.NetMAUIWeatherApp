using System.Reflection;

namespace WeatherApp.Helpers;

internal class AppInfoHelper
{
    public static string GetVersion()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var assemblyName = assembly.GetName();
        return assemblyName.Version.ToString();
    }
}