using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DASLv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public static int i = 0; //Change to non static once backend is done.
        public CategoryPage()
        {
            InitializeComponent();
        }
        public CategoryPage(string name, List<string> items)
        {
            InitializeComponent();
            CategoryPageTitle.Text = name;
            CategoryListView.ItemsSource = items;
            i++;
        }

        /*void CategoryTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
        }*/

        async void CategorySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }


            //give all categories that are 1 level below the given category
            //static List<String> getSubCategories(string category);
            //i = getSubCategories(e.SelectedItem.ToString()).Count();
            List<string> newList;
            if(i % 2 == 0)
            {
                newList = Category.GetRootCategories();
                /*newList = new List<string> {
                "Zenyatta",
                "Moira",
                "Lucio",
                "Torbjorn",
                "Pharah"
            };*/
            } else
            {
                newList = new List<string> {
                "Han Solo",
                "Luke Skywalker",
                "Leia Skywalker",
                "Anakin Skywalker",
                "Obi-Wan Kenobi",
                "Ahsoka Tano"
                };
            }

            if (i > 2)
            {
                await Navigation.PushAsync(new WordPage(e.SelectedItem.ToString(), "This Worked"));
            } else
            {
               await Navigation.PushAsync(new CategoryPage(e.SelectedItem.ToString(), newList));
            }
            //
            //comment out if you want to keep selections
            ListView lst = (ListView)sender;
            lst.SelectedItem = null;
        }
        /*
        void CategoryRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            //put your refreshing logic here
            var itemList = CategoryItems.Reverse().ToList();
            CategoryItems.Clear();
            foreach (var s in itemList)
            {
                CategoryItems.Add(s);
            }
            //make sure to end the refresh state
            list.IsRefreshing = false;
        }*/
    }
}