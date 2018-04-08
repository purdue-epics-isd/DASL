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
/*
        public WordPage(string pageName, string pageWord)
        {
            InitializeComponent();
            WordPageTitle.Text = pageName;
            WordPageWord.Text = pageWord;
        }*/
        public WordPage(string pageName, string pageWord)
        {
            string sign;
            Word word = App.Dictionary.NameToWord(pageWord);
            InitializeComponent();
            WordPageTitle.Text = word.SubCategory;
            WordPageWord.Text = word.Name;
            WordPageDefinition.Text = word.Definition;
            WordPageSentenceOne.Text = word.Sentence1;
            WordPageSentenceTwo.Text = word.Sentence2;
            WordPageSentenceThree.Text = word.Sentence3;
            WordPagePartOfSpeech.Text = word.Speech;
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