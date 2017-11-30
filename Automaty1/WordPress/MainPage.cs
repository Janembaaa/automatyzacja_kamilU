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

            var passwordBox = Browser.FindElementById("password");
            passwordBox.SendKeys(testdata.Password);

            var submit = Browser.FindElementById("primary");
            submit.Click();
        }


    }
}