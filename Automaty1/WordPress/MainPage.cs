using System;
using System.Linq;

namespace WordPress
{
    internal class MainPage
    {

        private const string url = "https://autotestdotnet.wordpress.com/wp-admin/";

        internal static void Open()
        {
            Browser.NavigateTo(url);
        }

        internal static void EnterCredentials(Credentials testdata)
        {
            var emailBox = Browser.FindElementById("usernameOrEmail");
            emailBox.SendKeys(testdata.Mail);

            var submit = Browser.FindByXpath("//*[@id='primary']/div/main/div/div[1]/div/form/div[1]/div[2]/button").First();
            submit.Click();

            var passwordBox = Browser.FindElementById("password");
            passwordBox.SendKeys(testdata.Password);

            var submit1 = Browser.FindElementById("primary");
            submit1.Click();
        }


    }
}