using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
        public WordPage(string pageName, string pageWord, string pageDefinition, string partOfSpeech, string pageSentenceOne, string pageSentenceTwo, string pageSentenceThree)
        {
            string sign;
            InitializeComponent();
            WordPageTitle.Text = pageName;
            WordPageWord.Text = pageWord;
            WordPageDefinition.Text = pageDefinition;
            WordPageSentenceOne.Text = pageSentenceOne;
            WordPageSentenceTwo.Text = pageSentenceTwo;
            WordPageSentenceThree.Text = pageSentenceThree;
            WordPagePartOfSpeech.Text = partOfSpeech;
            sign = "Sign of " + pageWord;
            WordPageSign.Text = sign;
            string path, gifpath;
            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    path = "IOS";
                    gifpath = "gifpath";
                    break;
                case Device.UWP:
                    path = "Images/" + pageWord.ToLower() + ".jpg";
                    gifpath = "Images/" + pageWord.ToLower() + "gif.gif";
                    Debug.Print(path);
                    break;
                case Device.Android:
                    path = "Resources/drawable/" + pageWord.ToLower() + ".jpg";
                    gifpath = "Resources/drawable/" + pageWord.ToLower() + "gif.gif";
                    Debug.Print(path);
                    break;
                default:
                    path = "Default";
                    gifpath = "Default";
                    break;
            }

            WordPageImage.Source = path;
            WordPageGif.Source = gifpath;
        }
    }
}