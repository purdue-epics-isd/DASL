using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Configuration;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCLStorage;
using System.IO;

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

            if (Xamarin.Forms.Application.Current.Properties.ContainsKey("ImgPath"))
                WordPageImage.Source = Xamarin.Forms.Application.Current.Properties["ImgPath"].ToString();
            else
                WordPageImage.Source = "Images//profilepicture.jpg";
        }

        async void onImageUpload(Object sender, EventArgs args)
        {
            try
            {

                FileData image = await CrossFilePicker.Current.PickFile();
                // the dataarray of the file will be found in filedata.DataArray 
                // file name will be found in file.FileName;
                //etc etc.

                if (image != null)
                {
                    string ext = image.FileName.Remove(0, image.FileName.LastIndexOf(".")).ToLower();

                    IFile file = FileSystem.Current.GetFileFromPathAsync(image.FilePath).Result;
                    IFolder rootFolder = FileSystem.Current.LocalStorage;
                    IFolder folder = await rootFolder.CreateFolderAsync("DASL", CreationCollisionOption.OpenIfExists);
                    IFile newFile = folder.CreateFileAsync("profile" + ext, CreationCollisionOption.GenerateUniqueName).Result;

                    Stream str = file.OpenAsync(PCLStorage.FileAccess.ReadAndWrite).Result;
                    Stream newStr = newFile.OpenAsync(PCLStorage.FileAccess.ReadAndWrite).Result;

                    byte[] buffer = new byte[str.Length];
                    int n;
                    while ((n = str.Read(buffer, 0, buffer.Length)) != 0)
                        newStr.Write(buffer, 0, n);
                    str.Dispose();
                    newStr.Dispose();
                    WordPageImage.Source = newFile.Path;
                    Xamarin.Forms.Application.Current.Properties["ImgPath"] = newFile.Path;
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "Okay I will go kill myself then");
            }
        }

        private void onImageReset(object sender, EventArgs e)
        {
            if (WordPageImage.Source.ToString() != "File: Images//profilepicture.jpg")
            {
                WordPageImage.Source = "Images//profilepicture.jpg";
                Xamarin.Forms.Application.Current.Properties["ImgPath"] = "Images//profilepicture.jpg";
            }
        }
    }
}