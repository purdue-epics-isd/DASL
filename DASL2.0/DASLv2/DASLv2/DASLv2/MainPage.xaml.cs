using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;

namespace DASLv2
{
    public partial class MainPage : ContentPage
    {
        // Default Constructor (Should never be used)
        public MainPage()
        {
            InitializeComponent();                                                      // Link the XAML and C# code
        }

        async void OnEnglishSearch(object sender, EventArgs e)                          // Function called using the Clicked feature in the XAML side of the code for the English Category Search Button 
        {
            List<string> list = Category.GetRootCategories();                           // Gets the root categories names as strings from the database 
            Debug.WriteLine("Opening new Category page (size " + list.Count + ")");     // Line for debugging how many category pages have been opened
            await Navigation.PushAsync(new CategoryPage("Category Page", list, false)); // Pushes the category page onto the navigation stack
        }
        async void OnWOTD(object sender, EventArgs e)                                   // Function called using the Clicked feature in the XAML side of the code for the Word of the Day Button 
        {
            //Call Function for WOTD                                                    // Currently static Word of the Week. Need to make a new method for generating a new one Daily
            await Navigation.PushAsync(new WordPage("Word of the Day", "Sink"));        // Pushes a new word page onto the navigation stack

        }
        async void OnWOTW(object sender, EventArgs e)                                   // Function called using the Clicked feature in the XAML side of the code for the Word of the Week Button 
        {
            //Call Function for WOTW                                                    // Currently static Word of the Week. Need to make a new method for generating a new one Weekly
            await Navigation.PushAsync(new WordPage("Word of the Week", "Circle"));     // Pushes a new word page onto the navigation stack
        }


    }
}