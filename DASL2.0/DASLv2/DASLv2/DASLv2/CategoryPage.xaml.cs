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
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();


            CategoryView.ItemsSource = new string[]
            {
                "Hello",
                "There",
                "General",
                "Kenobi"
            };
        }
        class Word{

        }
	}
}