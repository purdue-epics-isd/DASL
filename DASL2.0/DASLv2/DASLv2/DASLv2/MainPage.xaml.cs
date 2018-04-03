using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            List<string> list = new List<string> {
                "Harry Potter",
                "Ron Weasly",
                "Hermione Granger",
                "Mad Eye Moody",
                "Draco Malfoy"
            };
            await Navigation.PushAsync(new CategoryPage("Category Page", list));
        }
        async void OnWOTD(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WordPage("Word of the Day", "Hello There"));
        }
        async void OnWOTW(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WordPage("Word of the Week", "General Kenobi"));
        }

        
    }
}
