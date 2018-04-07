using System;
using System.Diagnostics;
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
        //public static int i = 0; //Change to non static once backend is done.
        public bool isWordPage = false;
        public CategoryPage()
        {
            InitializeComponent();
        }
        public CategoryPage(string name, List<string> items, bool isWordPage)
        {
            InitializeComponent();
            CategoryPageTitle.Text = name;
            CategoryListView.ItemsSource = items;
            this.isWordPage = isWordPage;
            //i++;
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

            List<string> cats = Category.GetSubCategories(e.SelectedItem.ToString());
            int i = cats.Count();
            List<string> newList;

            if (i == 0)
            {
                newList = Category.GetWordNamesFromCategory(e.SelectedItem.ToString());
            }
            else
            {
                newList = cats;
            }

            if (isWordPage)
            {
                await Navigation.PushAsync(new WordPage(e.SelectedItem.ToString(), "This Worked"));
            }
            else if (i == 0)
            {
                await Navigation.PushAsync(new CategoryPage(e.SelectedItem.ToString(), newList, true));
            }
            else
            {
                await Navigation.PushAsync(new CategoryPage(e.SelectedItem.ToString(), newList, false));
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