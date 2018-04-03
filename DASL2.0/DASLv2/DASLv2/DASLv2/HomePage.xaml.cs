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
            var navigationPage2 = new NavigationPage(new DASLv2.MainPage());
            navigationPage2.Title = "Settings";
            Children.Add(navigationPage);
            Children.Add(navigationPage2);
        }
    }
}