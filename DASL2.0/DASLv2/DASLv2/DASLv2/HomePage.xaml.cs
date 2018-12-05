using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DASLv2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        //Default constructor (This page is just a base tabbed page that allows you to navigate to the Profile and Add Word Pages
        public HomePage ()
        {
            InitializeComponent();                                              // Link XAML to the C# (Nothing in Xaml file for this page only)
            var themeViewModel = new ThemeViewModel();

            var _mainPage = new DASLv2.MainPage();
            var navigationPage = new NavigationPage(_mainPage);     // Create a new instance of a Navigation Page whose main child is the Main Page. This allows the Navigation stack to be used for Category search, Word of the Day, and Word of the Week
            navigationPage.Title = "Navigation";                                // Set the Name that will show up on the menu
            _mainPage.BindingContext = themeViewModel;

            var settingsPage = new SettingsPage();                              // Create a new instance of the settings page
            settingsPage.Title = "Profile";                                     // Set the Name that will show up on the menu
            settingsPage.BindingContext = themeViewModel;

            var addWordPage = new AddWordPage();                                // Create a new instance of the add word page
            addWordPage.Title = "Add Word";                                     // Set the Name that will show up on the menu
            addWordPage.BindingContext = themeViewModel;

            Children.Add(navigationPage);                                       // Add the navigation page as the first element so it is the default view when launching the app
            Children.Add(settingsPage);                                         // Add the settings/profile page to the tabbed page
            Children.Add(addWordPage);
            // Add the Add Word page to the tabbed page
        }
    }
}