using Microsoft.Extensions.Configuration;

namespace SeleniumUIAutomation.Config;

public class ConfigurationHelper
{
    private static IConfigurationRoot config;

    static ConfigurationHelper()
    {
        config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public static string BaseUrl => config["AppSettings:BaseUrl"];
    public static string Browser => config["AppSettings:Browser"];
    public static int DefaultTimeout => int.Parse(config["AppSettings:DefaultTimeout"]);
}