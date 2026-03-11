using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;

namespace selenium_4.Support
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(string scenarioName)
        {
            /* Logic similar to the one used in https://github.com/hjsblogger/selenium-automation-python-tutorial/
            blob/99e0cf469c04c0e0e72b37e2aec4fdf550accfdc/pyunitsetup.py#L8
            */
            return CreateCloudDriver(scenarioName);
        }
        
        private static IWebDriver CreateCloudDriver(string scenarioName)
        {
            string userName = Environment.GetEnvironmentVariable("LT_USERNAME") == null ? 
                            "LT_USERNAME" : Environment.GetEnvironmentVariable("LT_USERNAME");

            string accessKey = Environment.GetEnvironmentVariable("LT_ACCESS_KEY") == null ?
                            "LT_ACCESS_KEY" : Environment.GetEnvironmentVariable("LT_ACCESS_KEY");

            var gridUrl = new Uri($"https://{userName}:{accessKey}@hub.lambdatest.com/wd/hub");

            var ltOptions = new Dictionary<string, object>()
            {
                { "build", "[Selenium 4] ReqNRoll demo on LambdaTest" },
                { "project", "Reqnroll_Selenium4_Demo" },
                { "w3c", true },
                { "sessionName", scenarioName },
                { "platformName", "Windows 11" }
            };

            /* This can be further optimized to take different browsers */
            /* and browser versions */
            var options = new ChromeOptions();
            options.BrowserVersion = "latest";
            options.AddAdditionalOption("LT:Options", ltOptions);

            var driver = new RemoteWebDriver(gridUrl, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}