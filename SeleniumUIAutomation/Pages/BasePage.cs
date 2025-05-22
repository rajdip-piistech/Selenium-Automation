using OpenQA.Selenium;

namespace SeleniumUIAutomation.Pages;

public class BasePage
{
    protected IWebDriver Driver;
    protected BasePage(IWebDriver driver) => Driver = driver;
    protected IWebElement Find(By by) => Driver.FindElement(by);
    protected void Click(By by) => Find(by).Click();
    protected string Text(By by) => Find(by).Text;
    protected bool IsDisplayed(By by) => Find(by).Displayed;
    protected void Type(By by, string value)
    {
        var element = Find(by);
        element.Clear();
        element.SendKeys(value);
    }
}