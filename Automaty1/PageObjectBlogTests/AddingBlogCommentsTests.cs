using System;
using Xunit;

namespace PageObjectBlogTests
{
    public class AddingBlogCommentsTests : IDisposable
    {
        [Fact]
        public void CanAddCommentToTheBlogNote()
        {
            //otworz url
            MainPage.Open();

            //otworz pierwsza notke
            MainPage.OpenFirstNote();

            //dodaj komentarz
            

            //sprawdz ze komentarz sie dodal
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
