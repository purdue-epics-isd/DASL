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
        public HomePage ()
        {
            InitializeComponent();
            var navigationPage = new NavigationPage(new DASLv2.MainPage());
            navigationPage.Title = "Navigation";
            var settingsPage = new SettingsPage(); //Change to Profile settings page when zeeshan gives it to us
            settingsPage.Title = "Settings";
            var addWordPage = new AddWordPage(); //Change to Profile settings page when zeeshan gives it to us
            addWordPage.Title = "Add Word";
            Children.Add(navigationPage);
            Children.Add(settingsPage);
            Children.Add(addWordPage);
        }
    }
}