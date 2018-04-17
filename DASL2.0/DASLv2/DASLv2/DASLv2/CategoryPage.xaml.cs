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

    public class PageDataViewModel
    {
        public PageDataViewModel(Type type, string image, string text)
        {
            Type = type;
            Image = image;
            Text = text;
        }

        public Type Type { private set; get; }

        public string Image { private set; get; }

        public string Text { private set; get; }

        static PageDataViewModel()
        {
            All = new List<PageDataViewModel>
        {
            new PageDataViewModel(typeof(CategoryPage), "Images/circlethumb.jpg",
            //new PageDataViewModel(typeof(WordPage), "Images/appleThumb.jpg",
                                  "Interact with a Slider and Button"),

/*
            // Part 2. Essential XAML Syntax
            new PageDataViewModel(typeof(GridDemoPage), "Grid Demo",
                                  "Explore XAML syntax with the Grid"),
            new PageDataViewModel(typeof(AbsoluteDemoPage), "Absolute Demo",
                                  "Explore XAML syntax with AbsoluteLayout"),

            // Part 3. XAML Markup Extensions
            new PageDataViewModel(typeof(SharedResourcesPage), "Shared Resources",
                                  "Using resource dictionaries to share resources"),

            new PageDataViewModel(typeof(StaticConstantsPage), "Static Constants",
                                  "Using the x:Static markup extensions"),

            new PageDataViewModel(typeof(RelativeLayoutPage), "Relative Layout",
                                  "Explore XAML markup extensions"),

            // Part 4. Data Binding Basics
            new PageDataViewModel(typeof(SliderBindingsPage), "Slider Bindings",
                                  "Bind properties of two views on the page"),

            new PageDataViewModel(typeof(SliderTransformsPage), "Slider Transforms",
                                  "Use Sliders with reverse bindings"),

            new PageDataViewModel(typeof(ListViewDemoPage), "ListView Demo",
                                  "Use a ListView with data bindings"),

            // Part 5. From Data Bindings to MVVM
            new PageDataViewModel(typeof(OneShotDateTimePage), "One-Shot DateTime",
                                  "Obtain the current DateTime and display it"),

            new PageDataViewModel(typeof(ClockPage), "Clock",
                                  "Dynamically display the current time"),

            new PageDataViewModel(typeof(HslColorScrollPage), "HSL Color Scroll",
                                  "Use a view model to select HSL colors"),

            new PageDataViewModel(typeof(KeypadPage), "Keypad",
                                  "Use a view model for numeric keypad logic")
  */      };
        }


        public static IList<PageDataViewModel> All { private set; get; }
    }

    public partial class CategoryPage : ContentPage
    {
        //public static int i = 0; //Change to non static once backend is done.
        public bool isWordPage = false;
        public IList<PageDataViewModel> myAll;
        public CategoryPage()
        {
            InitializeComponent();
        }
        public CategoryPage(string name, List<string> items, bool isWordPage)
        {
            InitializeComponent();

            // Part 1. Getting Started with XAML
            PageDataViewModel.All.Clear();
            myAll = new List<PageDataViewModel>();
            items.Sort();
            if (!isWordPage)
            {
                foreach (string str in items)
                {
                    PageDataViewModel.All.Add(new PageDataViewModel(typeof(CategoryPage), "Images/" + str.ToLower().Trim().Replace("  ", "") + "thumb.jpg", str));
                    myAll.Add(new PageDataViewModel(typeof(CategoryPage), "Images/" + str.ToLower().Trim().Replace("  ", "") + "thumb.jpg", str));
                }
            }
            else
            {
                foreach (string str in items)
                {
                    PageDataViewModel.All.Add(new PageDataViewModel(typeof(WordPage), "Images/" + str.ToLower().Trim().Replace("  ", "") + "thumb.jpg", str));
                    myAll.Add(new PageDataViewModel(typeof(WordPage), "Images/" + str.ToLower().Trim().Replace("  ", "") + "thumb.jpg", str));
                }
            }
            //myAll = PageDataViewModel.All;
            // PageDataViewModel.All.Add(new PageDataViewModel(typeof(CategoryPage), "Images/applethumb.jpg",
            //                     "Display a Label with many properties set"));

            CategoryPageTitle.Text = name;
            //CategoryListView.ItemsSource = items;
            this.isWordPage = isWordPage;
            //i++;
        }

        /*void CategoryTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
        }*/

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PageDataViewModel.All.Clear();
            foreach (var item in this.myAll)
            {
                PageDataViewModel.All.Add(item);
            }
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                PageDataViewModel pageData = args.SelectedItem as PageDataViewModel;
                string name = pageData.Text.ToLower().Trim();
                List<string> cats = Category.GetSubCategories(name);
                int i = cats.Count();
                List<string> newList;
                Page page;
                if (i == 0)
                {
                    newList = Category.GetWordNamesFromCategory(name);
                }
                else
                {
                    newList = cats;
                }

                if (isWordPage)
                {
                    page = (Page)Activator.CreateInstance(pageData.Type, CategoryPageTitle.Text, name);
                    await Navigation.PushAsync(page);
                    //await Navigation.PushAsync(new WordPage(name, "This Worked"));
                }
                else if (i == 0)
                {
                    page = (Page)Activator.CreateInstance(pageData.Type, name, newList, true);
                    await Navigation.PushAsync(page);
                    //await Navigation.PushAsync(new CategoryPage(name, newList, true));
                }
                else
                {
                    page = (Page)Activator.CreateInstance(pageData.Type, name, newList, false);
                    await Navigation.PushAsync(page);
                    //await Navigation.PushAsync(new CategoryPage(name, newList, false));
                }
                //
                //comment out if you want to keep selections
                ListView lst = (ListView)sender;
                lst.SelectedItem = null;
                //page = (Page)Activator.CreateInstance(pageData.Type);
                //await Navigation.PushAsync(page);
            }
        }

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