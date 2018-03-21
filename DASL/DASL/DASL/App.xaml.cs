using DASL.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DASL
{
	public partial class App : Application
	{
        Database database = new Database();
        
        public App()
		{
			InitializeComponent();

			SetMainPage();

            database.InitUpdate();
		}


		public static void SetMainPage()
		{
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                }
            };
        }
	}
}
