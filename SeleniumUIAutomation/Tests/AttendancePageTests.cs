using SeleniumUIAutomation.Pages;

namespace SeleniumUIAutomation.Tests
{
    public class AttendancePageTests:BaseTest
    {
        [Fact]
        public void AttendanceReport_ShouldLoadSuccessfully()
        {
            var home = new HomePage(Driver);
            var dashboard = home.Login();

            var attendancePage = dashboard.GoToAttendance();
            attendancePage.FillReportFilters("01/05/2025", "31/05/2025");
            attendancePage.ClickSearch();

            Assert.True(attendancePage.IsReportVisible(), "Attendance report table not visible.");
        }
    }
}

