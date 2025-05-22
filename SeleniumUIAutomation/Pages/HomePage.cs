using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUIAutomation.Config;

namespace SeleniumUIAutomation.Pages;

public class HomePage:BasePage
{
    private By LoginButton => By.Id("btn-sign-in");
    private By UsernameField => By.Id("inputEmail");
    private By PasswordField => By.Id("inputPassword");
    public HomePage(IWebDriver driver) : base(driver) { }
    public void ClickLogin() => Click(LoginButton);
    public bool IsLoginVisible() => IsDisplayed(LoginButton);
    public void EnterUsername(string username) => Type(UsernameField, username);
    public void EnterPassword(string password) => Type(PasswordField, password);
    public DashboardPage Login()
    {
        EnterUsername("administrator");
        EnterPassword("monethaken@");
        ClickLogin();

        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(ConfigurationHelper.DefaultTimeout));
        wait.Until(d => d.Url.Contains("/dashboard"));

        return new DashboardPage(Driver);
    }
}