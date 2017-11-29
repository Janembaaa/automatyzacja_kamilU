using System.Linq;
using System.Threading;

namespace PageObjectBlogTests
{
    internal class NotePage
    {
        internal static void AddComment(Comment testData)
        {
            var commentBox = Browser.FindElementById("comment");
            commentBox.Click();
            commentBox.SendKeys(testData.Text);

            var emailBox = Browser.FindElementById("email");
            emailBox.Click();
            emailBox.SendKeys(testData.Mail);

            var nameLabel = Browser.FindByXpath("//label[@for='author']").First();
            nameLabel.Click();

            Thread.Sleep(2000);

            var nameBox = Browser.FindElementById("author");
            nameBox.Click();
            nameBox.SendKeys(testData.User);

            var submit = Browser.FindElementById("comment-submit");
            submit.Click();

        }
    }
}