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
        //Default Constructor (Only used if it doesn't match the other constructors available. 
		public WordPage () 
		{
            InitializeComponent ();
		}

        //Main Constructor Used
        public WordPage(string pageName, string pageWord)
        {
            string sign;
            Word word = App.Dictionary.NameToWord(pageWord);    // grabs the word from the database (necessary becaues if it is lower case, the pageWord passed in won't be lower case but it's important for common nouns to be lower case
            InitializeComponent();                              // Links the Xaml to the C#
            WordPageTitle.Text = pageName;                      // Sets the specified text box with the entry from the database
            WordPageWord.Text = word.Name;                      // Sets the specified text box with the entry from the database
            WordPageDefinition.Text = word.Definition;          // Sets the specified text box with the entry from the database
            WordPageSentenceOne.Text = word.Sentence1;          // Sets the specified text box with the entry from the database
            WordPageSentenceTwo.Text = word.Sentence2;          // Sets the specified text box with the entry from the database
            WordPageSentenceThree.Text = word.Sentence3;        // Sets the specified text box with the entry from the database
            WordPagePartOfSpeech.Text = word.Speech;            // Sets the specified text box with the entry from the database
            sign = "Sign of " + word.Name;                      // Creates the string for the Title of the Page Sign
            WordPageSign.Text = sign;                           // Sets the specified text box with the string from the previous step
            string path, gifpath;
            switch(Device.RuntimePlatform)                      // Each platform has a different area the images should be in
            {
                case Device.iOS:                                // The image path for iOS isn't done yet because it needs to be in 3 places
                    path = "IOS";
                    gifpath = "gifpath";
                    break;
                case Device.UWP:                                // Windows images could be anywhere but we put it in a folder called Images inside the UWP project
                    path = "Images/" + pageWord.ToLower() + ".jpg";
                    gifpath = "Images/" + pageWord.ToLower() + "gif.gif";
                    Debug.Print(path);
                    break;
                case Device.Android:                            // Android needs the images to be within the Resources/drawable folders
                    path = "Resources/drawable/" + pageWord.ToLower() + ".jpg";
                    gifpath = "Resources/drawable/" + pageWord.ToLower() + "gif.gif";
                    Debug.Print(path);
                    break;
                default:                                        //If none of the other three fit the device do this. This should never happen
                    path = "Default";
                    gifpath = "Default";
                    break;
            }

            WordPageImage.Source = path;                        //Set the Image Source to the platform specific path
            WordPageGif.Source = gifpath;                       //Set the GIF Source to the platform specific path
        }
    }
}