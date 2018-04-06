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
        public WordPage(string pageName, string pageWord, string pageDefinition, string pageSentenceOne, string pageSentenceTwo, string pageSentenceThree)
        {
            InitializeComponent();
            WordPageTitle.Text = pageName;
            WordPageWord.Text = pageWord;
            WordPageDefinition.Text = pageDefinition;
            WordPageSentenceOne.Text = pageSentenceOne;
            WordPageSentenceTwo.Text = pageSentenceTwo;
            WordPageSentenceThree.Text = pageSentenceThree;
            string path;
            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    break;
                case Device.UWP:
                    path = "Images/" + pageWord.ToLower() + ".jpg";
                    break;
                case Device.Android:
                    path = "Resources/drawable/" + pageWord.ToLower() + ".jpg";
                    WordPageImage.Source = path;
                    break;
                default:
                    break;
            }
        }
    }
}