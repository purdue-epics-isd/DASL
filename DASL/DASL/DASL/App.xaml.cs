using DASL.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DASL
{
	public partial class App : Application
	{ //path string for database
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"dbTest.db3") 
        public App()
		{
			InitializeComponent();

			SetMainPage();

            var db = new SQLiteConnection(dbPath);

            db.CreateTable<Word>();

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
