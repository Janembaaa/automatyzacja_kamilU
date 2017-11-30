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

           // var menuPost = Browser.FindByCSS("#menu-posts>a> div.wp-menu-name");
           // menuPost.Click();

        }
    }
}