﻿using System;
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
        public MainPage()
        {
            InitializeComponent();

        }

        async void OnEnglishSearch(object sender, EventArgs e)
        {
            /*List<string> list = new List<string> {
                "Harry Potter",
                "Ron Weasly",
                "Hermione Granger",
                "Mad Eye Moody",
                "Draco Malfoy"
            };*/
            List<string> list = Category.GetRootCategories();
            Debug.WriteLine("Opening new Category page (size " + list.Count + ")");
            await Navigation.PushAsync(new CategoryPage("Category Page", list, false));
        }
        async void OnWOTD(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new WordPage("Word of the Day", "Apple", "A fruit that comes from a tree", "Noun", "The apple was yummy", "Apples are a good source of fiber", "Joe likes granny apples"));
            await Navigation.PushAsync(new WordPage("Word of the Day", "Sink"));

        }
        async void OnWOTW(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WordPage("Word of the Week", "Circle"));
        }


    }
}