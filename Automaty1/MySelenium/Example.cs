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
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private IWebDriver _driver;

        private bool acceptNextAlert = true;

        public Example()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);
            baseURL = "https://www.google.pl/";
            verificationErrors = new StringBuilder();
        }

       

        [Fact]
        public void TheExampleTest()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("lst-ib")).Clear();
            driver.FindElement(By.Id("lst-ib")).SendKeys("code sprinters");
            driver.FindElement(By.Id("lst-ib")).Submit();
            driver.FindElement(By.LinkText("Code Sprinters -")).Click();

            waitForClickable(By.LinkText("Akceptuję"), 5);

            driver.FindElement(By.LinkText("Akceptuję")).Click();

            var element = driver.FindElement(By.LinkText("Poznaj nasze podejście"));
            Assert.NotNull(element);

            var elements = driver.FindElements(By.LinkText("Poznaj nasze podejście"));
            Assert.Single(elements);

            waitForClickable(By.LinkText("Poznaj nasze podejście"), 30);

            driver.FindElement(By.LinkText("Poznaj nasze podejście")).Click();

            //ver1
            Assert.Contains("WIEDZA NA PIERWSZYM MIEJSCU", driver.PageSource);

            //ver2
            Assert.Single(driver.FindElements(By.TagName("h2")).Where(tag => tag.Text == "WIEDZA NA PIERWSZYM MIEJSCU"));

            Thread.Sleep(10000);
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