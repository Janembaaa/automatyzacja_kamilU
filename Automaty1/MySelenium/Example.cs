using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Collections.ObjectModel;

namespace SeleniumTests
{
    public class SeleniumExample : IDisposable
    {
        private const string SearchTextBoxId = "lst-ib";
        private const string Google = "https://www.google.com";
        private const string PageTitle = "Code Sprinters -";
        private const string TextToSearch = "code sprinters";
        private const string LinkTextToFind = "Poznaj nasze podejście";
        private const string CookiesPolicy = "Akceptuję";
        private const string DesiredTextLink = "Poznaj nasze podejście";
        private IWebDriver driver;
        private StringBuilder verificationErrors;

        public SeleniumExample()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts()
            .ImplicitWait = TimeSpan.FromMilliseconds(100);
            verificationErrors = new StringBuilder();
        }

        [Fact]
        public void NavigatingToCodeSprintersSite()
        {
            GoToGoogle();
            Search(TextToSearch);
            GoToSearchResultByPageTitle(PageTitle);

            Assert.Single(GetElementsByLinkText(LinkTextToFind));

            AcceptCookies();

            GoToDesiredPage();

            Assert.Single(GetElementByText());
        }

        private System.Collections.Generic.IEnumerable<IWebElement> GetElementByText()
        {
            return TextOnPage();
        }

        private System.Collections.Generic.IEnumerable<IWebElement> TextOnPage()
        {
            return driver.FindElements(By.TagName("h2"))
                                        .Where(tag => tag.Text == "WIEDZA NA PIERWSZYM MIEJSCU");
        }

        private void GoToDesiredPage()
        {
            WaitForClickable(By.LinkText(DesiredTextLink), 5);

            driver.FindElement(By.LinkText(DesiredTextLink)).Click();
        }

        private void AcceptCookies()
        {
            driver.FindElement(By.LinkText(CookiesPolicy)).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(11));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText("Akceptuję"), "Akceptuję"));
        }

        private ReadOnlyCollection<IWebElement> GetElementsByLinkText(string text)
        {
            return driver.FindElements(By.LinkText(text));
        }

        private void Search(string query)
        {
            var searchBox = GetSearchBox();
            searchBox.Clear();
            searchBox.SendKeys(query);
            searchBox.Submit();
        }

        private void GoToSearchResultByPageTitle(string title)
        {
            driver.FindElement(By.LinkText(title)).Click();
        }

        private void GoToGoogle()
        {
            driver.Navigate().GoToUrl(Google);
        }

        private IWebElement GetSearchBox()
        {
            return driver.FindElement(By.Id(SearchTextBoxId));
        }

        protected void WaitForClickable(By by, int seconds)
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
            }
            Assert.Equal("", verificationErrors.ToString());
        }
    }
}