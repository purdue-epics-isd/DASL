using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using SQLite;
using System.IO;

namespace DASLv2
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        
        async void OnEnglishSearch (object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                    "English Search",
                    "Would you like to call ?",
                    "Yes",
                    "No"))
            {
            }
        }
        async void OnWOTD(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new WordPage("Word of the Day", "Hello There"));
            try
            {
                if (await this.DisplayAlert("Database Test", "Would you like to add a word?", "Yes", "No"))
                {
                    Word word = new Word { Name = "Tree", Speech = "Noun", Sentence = "Trees can become very big", RootCategory = "Nature" };

                    //App.Dictionary.InitUpdate();
                    App.Dictionary.AddWord(word);
                    Debug.WriteLine(App.Dictionary.StatusMessage);
                    Debug.WriteLine(word.ToString());
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            
        }
        async void OnWOTW(object sender, EventArgs e)
        {
            if(await this.DisplayAlert("Database Test 2", "Would you like to see all the words?", "Yes", "No"))
            {
                List<Word> words = App.Dictionary.GetAllWords();

                Debug.WriteLine(App.Dictionary.StatusMessage);

                foreach(Word word in words)
                {
                    Debug.WriteLine(word);
                }
            }
        }
    }
}
