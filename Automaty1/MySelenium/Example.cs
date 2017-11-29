using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Linq;

namespace SeleniumTests
{
    public class Example : IDisposable
    {
        private const string SearchTextBoxId = "lst-ib";
        private const string Google = "https://www.google.com";

        private IWebDriver driver;
        private StringBuilder verificationErrors;

        public Example()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);
            verificationErrors = new StringBuilder();
        }
  

        [Fact]
        public void TheExampleTest()
        {
            driver.Navigate().GoToUrl(Google);

            IWebElement searchBox = GetSearchBOx();
            searchBox.Clear();
            searchBox.SendKeys("code sprinters");
            searchBox.Submit();


            driver.FindElement(By.Id(SearchTextBoxId)).Clear();
            driver.FindElement(By.Id(SearchTextBoxId)).SendKeys("code sprinters");
            driver.FindElement(By.Id(SearchTextBoxId)).Submit();
            driver.FindElement(By.LinkText("Code Sprinters -")).Click();

            waitForClickable(By.LinkText("Akceptuję"), 11);

            driver.FindElement(By.LinkText("Akceptuję")).Click();

            //var element = driver.FindElement(By.LinkText("Poznaj nasze podejście"));
            //Assert.NotNull(element);

            //var elements = driver.FindElements(By.LinkText("Poznaj nasze podejście"));
            //Assert.Single(elements);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(11));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText("Akceptuję"), "Akceptuję"));

            waitForClickable(By.LinkText("Poznaj nasze podejście"), 5);

            driver.FindElement(By.LinkText("Poznaj nasze podejście")).Click();

            //ver1
            Assert.Contains("WIEDZA NA PIERWSZYM MIEJSCU", driver.PageSource);

            //ver2
            Assert.Single(driver.FindElements(By.TagName("h2")).Where(tag => tag.Text == "WIEDZA NA PIERWSZYM MIEJSCU"));

            Thread.Sleep(5000);
        }

        private IWebElement GetSearchBOx()
        {
            return driver.FindElement(By.Id(SearchTextBoxId));
        }

        protected void waitForClickable(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected void waitForElementPresent(IWebElement by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public void Dispose()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.Equal("", verificationErrors.ToString());
        }
    }
}