using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Configuration;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DASLv2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        // Default constructor
        // As I only did the layout, none of the functionality for this is done
        // The code in this should be similar to how we handle data for the Main Page buttons
        // Look there to see the functions we had for on press and accept
        // Functions will be a bit different for the drop down menus and text boxes
		public SettingsPage ()
		{
			InitializeComponent ();
           // BindingContext = new ThemeViewModel();
            //ThemePicker.SelectedIndex = Theme.CurrentTheme;
        }


        //change theme
        /*void onThemeChosen(Object sender, EventArgs args)
        {
            Theme.CurrentTheme = ThemePicker.SelectedIndex;            
            profileFrame.BackgroundColor = 
            nameLabel.TextColor = 
            themeLabel.TextColor = 
            readingLabel.TextColor = 
            Xamarin.Forms.Color.FromHex(Theme.currentTheme.altColor);
            profileLabel.TextColor = Xamarin.Forms.Color.FromHex(Theme.currentTheme.mainColor);
            
        }
        */
	}
}