using System;
using System.Linq;

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
    }
}