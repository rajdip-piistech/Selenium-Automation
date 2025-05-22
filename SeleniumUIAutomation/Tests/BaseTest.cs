using OpenQA.Selenium;
using SeleniumUIAutomation.Config;
using SeleniumUIAutomation.Drivers;

namespace SeleniumUIAutomation.Tests;

public class BaseTest: IDisposable
{
    protected IWebDriver Driver;

    public BaseTest()
    {
        Driver = DriverFactory.CreateDriver();
        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(ConfigurationHelper.BaseUrl);
    }

    public void Dispose()
    {
        Driver.Quit();
    }
}