using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DASLv2
{
    public partial class App : Application
	{
        public static Database Dictionary { get; private set; }
		public App (string dbPath)
		{
			InitializeComponent();
            if (Application.Current.Properties.ContainsKey("Theme"))
            {
                Theme.CurrentTheme = Convert.ToInt32(Application.Current.Properties["Theme"].ToString());
            }
            if (Application.Current.Properties.ContainsKey("MainColor"))
            {
                Theme.currentTheme.mainColor = Application.Current.Properties["MainColor"].ToString();
            }
            if (Application.Current.Properties.ContainsKey("AltColor"))
            {
                Theme.currentTheme.altColor = Application.Current.Properties["AltColor"].ToString();
            }
            if (Application.Current.Properties.ContainsKey("BgColor"))
            {
                 Theme.currentTheme.bgColor = Application.Current.Properties["BgColor"].ToString();
            }

            MainPage = new HomePage();

            Dictionary = new Database(dbPath);
            Dictionary.InitUpdate();

            //MainPage = new NavigationPage(new DASLv2.MainPage());
        }

        protected override void OnStart ()
		{
            // Handle when your app starts

        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
