using Microsoft.Extensions.Configuration;
using CoreFramework.Utilities;

namespace CoreFramework.Configs;

public class ConfigManager
{
    
    private static IConfigurationRoot _configurationRoot;

    // Read JSON file
    public static void Configure()
    {
        _configurationRoot = new ConfigurationBuilder()
            .SetBasePath(FilePaths.GetCurrentDirectoryPath())
            .AddJsonFile($"appsettings.json", true)
            .AddEnvironmentVariables()
            .Build();
    }

    //Build functions to read keys insilde JSON file
    public static T GetConfig<T>(string key) where T : class
    {
        if (_configurationRoot == null)
        {
            Configure();
        }
        return _configurationRoot.GetSection(key).Get<T>();
    }

    //Read values
    public static T GetValue<T>(string key) where T : class
    {
        if (_configurationRoot == null)
        {
            Configure();
        }
        return _configurationRoot.GetValue<T>(key);
    }
}
