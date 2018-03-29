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
	public partial class WordPage : ContentPage
	{
		public WordPage ()
		{
            InitializeComponent ();
		}
        public WordPage(string pageName, string pageWord)
        {
            InitializeComponent();
            WordPageTitle.Text = pageName;
            WordPageWord.Text = pageWord;
        }
    }
}