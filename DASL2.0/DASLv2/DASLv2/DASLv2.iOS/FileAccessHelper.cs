using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DASLv2.iOS
{
    public class FileAccessHelper
    {
        //This is used to get the file path of the database. It must be done in OS specific development as the way to do it is different for every OS.
        public static string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library");

            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }

            return System.IO.Path.Combine(libFolder, filename);
        }
    }
}