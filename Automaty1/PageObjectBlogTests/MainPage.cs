﻿using System;

namespace PageObjectBlogTests
{
    internal class MainPage
    {
        private const string url = "https://autotestdotnet.wordpress.com/";

        internal static void Open()
        {
            Browser.NavigateTo(url);
        }
    }
}