using OpenQA.Selenium.Chrome;
using System;

namespace PageObjectBlogTests
{
    internal class Browser
    {
        private static ChromeDriver driver;

        static Browser()
        {
            driver = new ChromeDriver();
        }

        internal static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}