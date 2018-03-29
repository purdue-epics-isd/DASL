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
            await Navigation.PushAsync(new WordPage("Word of the Day", "Hello There"));
        }
        async void OnWOTW(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WordPage("Word of the Week", "Hello There"));
        }
    }
}
