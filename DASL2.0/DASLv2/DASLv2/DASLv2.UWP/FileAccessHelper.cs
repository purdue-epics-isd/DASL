using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DASLv2.UWP
{
    public class FileAccessHelper
    {
        //This is used to get the file path of the database. It must be done in OS specific development as the way to do it is different for every OS.
        public static string GetLocalFilePath(string filename)
        {
            string path = global::Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return System.IO.Path.Combine(path, filename);
        }
    }
}
