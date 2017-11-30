using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace WordPress
{
    public class AddNewNoteInWordPress
    {
        [Fact]
        public void CanAddNoteInWordPress()
        {
            //otworz url
            MainPage.Open();

            //wpisz dane i przejdz dalej
            MainPage.EnterCredentials(new Credentials
            {
                Mail = "autotestdotnet@gmail.com",
                Password = "P@ssw0rd1"
            });
            Thread.Sleep(5000);

            //otworz menu postów
            PostPage.EnterPostMenu();

            //dodaj nowy post
            PostPage.EnterPostBody();
            Thread.Sleep(5000);

            //sprawdz dodany post
            PostPage.ViewAddedPost();

            //wyloguj usera
            PostPage.LogoutUser();
            Thread.Sleep(1500);

            //otworz url
            MainPage.Open();

            //wpisz dane i przejdz dalej
            MainPage.EnterCredentials(new Credentials
            {
                Mail = "autotestdotnet@gmail.com",
                Password = "P@ssw0rd1"
            });
            Thread.Sleep(5000);

            //otworz menu postów
            PostPage.EnterAllPostMenu();

            //zaznacz post i usun
            PostPage.RemovePostFromTheList();
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
