using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DASL.Models;
using DASL.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DASL.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }
	}
}