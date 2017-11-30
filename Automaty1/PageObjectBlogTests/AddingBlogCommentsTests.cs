using PageObjectTests;
using System;
using System.Threading;
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
            NotePage.CheckComment();
        }

        [Fact]
        public void CanAddCommentToPreviouslyAddedComment()
        {
            //otworz url
            MainPage.Open();

            //otworz pierwsza notke
            MainPage.OpenFirstNote();

            //otworz pierwszy komentarz
            NotePage.OpenFirstComment();

            Thread.Sleep(10000);
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
