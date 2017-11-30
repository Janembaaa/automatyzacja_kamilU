using System;
using System.Linq;
using System.Threading;

namespace WordPress
{
    internal class PostPage
    {
        internal static void EnterPostMenu()
        {
            var menuPosts = Browser.FindByXpath("//*[@id='menu-posts']/a/div[3]").First();
            menuPosts.Click();

            var addPost = Browser.FindByXpath("//*[@id='wpbody-content']/div[3]/a").First();
            addPost.Click();
        }

        internal static void EnterPostBody()
        {
            var postTitle = Browser.FindElementById("title");
            postTitle.Click();
            postTitle.SendKeys(Guid.NewGuid() + "");

            var postContent = Browser.FindElementById("content");
            postContent.Click();
            postContent.SendKeys(Guid.NewGuid() + "");
            Thread.Sleep(5000);

            var postPublish = Browser.FindElementById("publish");
            postPublish.Click();
        }

        internal static void ViewAddedPost()
        {
            var viewPost = Browser.FindByXpath("//*[@id='message']/p/a").First();
            viewPost.Click();
            Thread.Sleep(5000);
        }

        internal static void LogoutUser()
        {
            var logoutIcon = Browser.FindByXpath("//*[@id='wp-admin-bar-my-account']/a/img").First();
            logoutIcon.Click();
            Thread.Sleep(2000);

            var signOut = Browser.FindByXpath("//button[text()='Sign Out']").First();
            signOut.Click();
        }
    }
}