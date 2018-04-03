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
        public static ObservableCollection<string> CategoryItems { get; set; }
        public CategoryPage()
        {
            InitializeComponent();

            /*CategoryListView.ItemsSource = new ObservableCollection<string>()
            {
                "Harry Potter",
                "Ron Weasly",
                "Hermione Granger",
                "Mad Eye Moody",
                "Draco Malfoy"
            };*/
   
            /*CategoryListView.ItemsSource = new List<string> {
                "Harry Potter",
                "Ron Weasly",
                "Hermione Granger",
                "Mad Eye Moody",
                "Draco Malfoy"
            };*/

        }
        public CategoryPage(string name, List<string> items)
        {
            InitializeComponent();
            CategoryPageTitle.Text = name;
            CategoryListView.ItemsSource = items;
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
            //Call getSubCategories(e.SelectedItem.ToString();
            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            List<string> list = new List<string> {
                "Zenyatta",
                "Moira",
                "Lucio",
                "Torbjorn",
                "Pharah"
            };

            await Navigation.PushAsync(new CategoryPage(e.SelectedItem.ToString(), list));
            //await Navigation.PushAsync(new WordPage(e.SelectedItem.ToString(), "This Worked"));
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