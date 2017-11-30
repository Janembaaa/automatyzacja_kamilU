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

            //dodaj nowy post
            PostPage.EnterPostMenu();

        }
    }
}
