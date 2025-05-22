using OpenQA.Selenium;
using System.IO;

namespace SeleniumUIAutomation.Utils
{
    public static class ScreenshotHelper
    {
        public static void CaptureScreenshot(IWebDriver driver, string filename)
        {
            // Cast IWebDriver to ITakesScreenshot to access TakeScreenshot method
            if (driver is ITakesScreenshot screenshotDriver)
            {
                var screenshot = screenshotDriver.GetScreenshot();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
                Directory.CreateDirectory(filePath);
                screenshot.SaveAsFile(Path.Combine(filePath, filename + ".png"));
            }
            else
            {
                throw new InvalidOperationException("The provided driver does not support taking screenshots.");
            }
        }
    }
}