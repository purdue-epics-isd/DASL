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
                /*
                example of how to add a new page to the PageDataViewModel list
                new PageDataViewModel(typeof(CategoryPage), "Images/circlethumb.jpg",
                    "Interact with a Slider and Button"),
                */
                           new PageDataViewModel(typeof(CategoryPage), "Images/circlethumb.jpg",
                    "Interact with a Slider and Button"),
            };
        }


        public static IList<PageDataViewModel> All { private set; get; }
    }

    public partial class CategoryPage : ContentPage
    {
        public bool isWordPage = false;
        public IList<PageDataViewModel> myAll; //list of all elements to be displayed
        public CategoryPage()
        {
            InitializeComponent();            
        }
        public CategoryPage(string name, List<string> items, bool isWordPage)
        {
            InitializeComponent();

            // Part 1. Getting Started with XAML
            int i = 0;
            PageDataViewModel.All.Clear(); //clear the current list of viewmodels
            myAll = new List<PageDataViewModel>(); //load myall with a fresh empty list
            items.Sort();   //sort the Categories/words alpabetically
            if (!isWordPage)
            {
                //Category page section
                foreach (string str in items) //for each category:
                {
                    if (i++ == 0) //used to make sure the first item is skipped (work-around for UWP bug)
                    { // (a dummy page)
                        PageDataViewModel.All.Add(new PageDataViewModel(typeof(CategoryPage), "_", "\t"));
                        myAll.Add(new PageDataViewModel(typeof(CategoryPage), "_", "\t"));
                        continue;
                    } 
                    //adds a new element to the list view
                    PageDataViewModel.All.Add(new PageDataViewModel(typeof(CategoryPage), "Images/" + str.ToLower().Trim().Replace(" ", "").Replace(@"'", "").Replace("?", "") + "thumb.jpg", str));
                    //also adds it to the local copy of the list, this is needed for reloading the page
                    myAll.Add(new PageDataViewModel(typeof(CategoryPage), "Images/" + str.ToLower().Trim().Replace(" ", "").Replace(@"'", "").Replace("?", "") + "thumb.jpg", str));
                }
            }
            else
            {
                //Same as category page except it loads a Word Page instead
                foreach (string str in items)
                {
                    if (i++ == 0)
                    {
                        PageDataViewModel.All.Add(new PageDataViewModel(typeof(CategoryPage), "_", "\t"));
                        myAll.Add(new PageDataViewModel(typeof(CategoryPage), "_", "\t"));
                        continue;
                    }
                    PageDataViewModel.All.Add(new PageDataViewModel(typeof(WordPage), "Images/" + str.ToLower().Trim().Replace(" ", "").Replace(@"'", "").Replace("?", "") + "thumb.jpg", str));
                    myAll.Add(new PageDataViewModel(typeof(WordPage), "Images/" + str.ToLower().Trim().Replace(" ", "").Replace(@"'", "").Replace("?", "") + "thumb.jpg", str));
                }
            }

            CategoryPageTitle.Text = name;
            this.isWordPage = isWordPage;
        }

        protected override void OnAppearing()
        {
            //whenever the page is reopened, reload all of the list elements back into it from this.myAll
            base.OnAppearing();
            if (listView != null)
            {
                listView.ClearValue(ListView.SelectedItemProperty);
            }
            PageDataViewModel.All.Clear();
            foreach (var item in this.myAll)
            {
                PageDataViewModel.All.Add(item);
            }
        }

        //triggers whenever a category/word is clicked on
        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;
            
            if (args.SelectedItem != null)
            {
                PageDataViewModel pageData = args.SelectedItem as PageDataViewModel;
                string name = pageData.Text.Trim();
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
                }
                else if (i == 0)
                {
                    page = (Page)Activator.CreateInstance(pageData.Type, name, newList, true);
                    await Navigation.PushAsync(page);
                }
                else
                {
                    page = (Page)Activator.CreateInstance(pageData.Type, name, newList, false);
                    await Navigation.PushAsync(page);
                }
                //
                //comment out if you want to keep selections
                page.BindingContext = this.BindingContext;
                ListView lst = (ListView)sender;
                lst.SelectedItem = null;
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
    }
}