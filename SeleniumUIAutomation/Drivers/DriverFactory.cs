using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumUIAutomation.Config;

namespace SeleniumUIAutomation.Drivers;

public static class DriverFactory
{
    public static IWebDriver CreateDriver()
    {
        var browser = ConfigurationHelper.Browser.ToLower();
        return browser switch
        {
            "firefox" => new FirefoxDriver(),
            _ => new ChromeDriver(),
        };
    }
}