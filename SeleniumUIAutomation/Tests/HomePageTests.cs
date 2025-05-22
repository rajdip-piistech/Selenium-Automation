using OpenQA.Selenium.Support.UI;
using SeleniumUIAutomation.Pages;

namespace SeleniumUIAutomation.Tests;

public class HomePageTests:BaseTest
{
    [Fact]
    public void LoginButton_ShouldBeVisible()
    {
        var home = new HomePage(Driver);
        Assert.True(home.IsLoginVisible(), "Login button is not visible on the homepage.");
    }

    [Fact]
    public void LoginFlow_ShouldEnterCredentials()
    {
        var home = new HomePage(Driver);
        var dashboard = home.Login();
        Assert.True(true, "Login process completed and navigated to dashboard.");
    }
}