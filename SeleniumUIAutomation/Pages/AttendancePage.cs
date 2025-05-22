using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumUIAutomation.Config;

namespace SeleniumUIAutomation.Pages;

public class AttendancePage:BasePage
{
    private By FromDateField => By.Id("StartDate");
    private By ToDateField => By.Id("EndDate");
    private By ShowResult => By.ClassName("btn-success"); // Only use last class if multiple

    // Assuming this element appears after the report loads
    private By ReportTable => By.Id("reportTable"); // Replace with actual table ID

    public AttendancePage(IWebDriver driver) : base(driver) { }

    public void FillReportFilters(string fromDate, string toDate, string employeeId = "")
    {
        Type(FromDateField, fromDate);
        Type(ToDateField, toDate);

        // If there's an employeeId filter field, add it here
        // Example:
        // if (!string.IsNullOrEmpty(employeeId))
        //     Type(EmployeeIdField, employeeId);
    }

    public void ClickSearch()
    {
        Click(ShowResult);

        // Wait until the report table is visible
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(ConfigurationHelper.DefaultTimeout));
        wait.Until(driver => driver.FindElement(ReportTable).Displayed);
    }

    public bool IsReportVisible() => IsDisplayed(ReportTable);
}