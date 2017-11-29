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

            //dodaj komentarz, NotePage zamiast MainPage bo to nowa podstrona
            NotePage.AddComment(new Comment
            {
                Text = "Lorem ipsum dupa dupa",
                Mail = "test@test.pl",
                User = "białko"
            });
                
            //sprawdz ze komentarz sie dodal
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
