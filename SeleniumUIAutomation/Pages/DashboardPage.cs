using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumUIAutomation.Config;
using SeleniumExtras.WaitHelpers;

namespace SeleniumUIAutomation.Pages;

public class DashboardPage:BasePage
{
    private By ReportsMenu => By.Name("Payroll-Management");
    private By AttendanceSubMenu => By.Name("Attendance-Management");
    private By AttendanceChildMenu => By.Id("attendance");
    private By JobCardMenu => By.Id("JobCard");

    public DashboardPage(IWebDriver driver) : base(driver) { }

    public AttendancePage GoToAttendance()
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(ConfigurationHelper.DefaultTimeout));
        var actions = new OpenQA.Selenium.Interactions.Actions(Driver);

        // Hover over "Payroll Management"
        var payrollMenu = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Payroll-Management")));
        actions.MoveToElement(payrollMenu).Perform();

        // Hover over "Attendance Management"
        var attendanceMenu = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("Attendance-Management")));
        actions.MoveToElement(attendanceMenu).Perform();

        // Hover over "Attendance"
        var attendanceSubMenu = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Attendance')]")));
        actions.MoveToElement(attendanceSubMenu).Perform();

        // Click "Monthly Attendance Report"
        var monthlyReport = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Monthly Attendance Report')]")));
        monthlyReport.Click();

        // Wait for page to load
        wait.Until(d => d.Url.Contains("/report/attendance-report"));

        return new AttendancePage(Driver);
    }
}