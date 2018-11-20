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
		}
	}
}