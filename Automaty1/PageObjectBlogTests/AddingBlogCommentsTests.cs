using PageObjectTests;
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
                Text = (Guid.NewGuid() + Guid.NewGuid().ToString()),
                // jeśli dodajemy dwa GUIDy, jeden trzeba zmienić na stringa
                Mail = (Guid.NewGuid() + "@onet.pl"),
                User = "Jan Usz"
            });
                
            //sprawdz ze komentarz sie dodal
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
