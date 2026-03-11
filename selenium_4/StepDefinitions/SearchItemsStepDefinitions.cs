using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using selenium_4.Support;
using OpenQA.Selenium.Support.UI;


[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]
namespace LTSpecFlow.StepDefinitions
{
    [Binding]
    public class AddItemsToCartStepDefinitions
    {
        /* For serial execution */
        /*
        private readonly IWebDriver _driver;

        public AddItemsToCartStepDefinitions()
        {
            _driver = Hooks.Driver;
        }
        */
        private readonly IWebDriver _driver;

        public AddItemsToCartStepDefinitions(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext["driver"] as IWebDriver;
        }

        private IWebElement WaitAndFind(By locator)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElement(locator));
        }

        private IReadOnlyCollection<IWebElement> WaitAndFindAll(By locator)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(locator));
        }

        /* Moved this to the Hooks, can be refined further if there are more test URLs */
        /*
        [BeforeScenario]
        public void SetUp()
        {
             _driver.Navigate().GoToUrl("https://ecommerce-playground.lambdatest.io/");
        }
        */

        [Given(@"I select the (.*) category")]
        public void GivenISelectTheCategory(string category)
        {
            WaitAndFind(
                By.XPath("(//div[@class='dropdown search-category']/button[@type='button'])[1]")
            ).Click();
            WaitAndFind(By.XPath($"(//a[text()='{category}'])[1]")).Click();
        }

        [When(@"I search for (.*)")]
        public void WhenISearchForProduct(string product)
        {
            WaitAndFind(By.XPath("(//input[@name='search'])[1]")).SendKeys(product);
            WaitAndFind(By.XPath("(//button[normalize-space()='Search'])[1]")).Click();
        }

        [Then(@"I should get (.*) results for (.*)")]
        public void ThenIShouldGetResults(int itemsCount, string product)
        {
            int actualCount = WaitAndFindAll(
                By.XPath($"//div[@class='row']//div[@class='carousel-item active']/img[@alt='{product}']")
            ).Count;

            /* NUnit 3 */
            /* Assert.AreEqual(itemsCount, actualCount); */

            /* NUnit 4 */
            Assert.That(actualCount, Is.EqualTo(itemsCount));

            Thread.Sleep(10000); // 10 seconds delay
        }
    }
}