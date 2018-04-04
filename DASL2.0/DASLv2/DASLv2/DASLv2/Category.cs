using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace DASLv2
{
    public static class Category
    {

        public static List<string> GetRootCategories()
        {
            List<Word> words = App.Dictionary.GetAllWords();
            List<string> categories = new List<string>();
            bool exists = false;

            foreach(Word word in words)
            {
                exists = false;
                foreach(string cat in categories)
                {
                    //Debug.WriteLine("Comparing " + word.RootCategory  + " to " + cat);
                    if(String.Equals(word.RootCategory,cat))
                    {
                        Debug.WriteLine("exists");
                        exists = true;
                        break;
                    }
                }
                //Debug.WriteLine(""+exists);
                if(exists == false)
                {
                  //  Debug.WriteLine("Adding category " + word.RootCategory);
                    categories.Add(word.RootCategory);
                }
            }
            //Debug.WriteLine("");
            return categories;
        }

        public static List<string> GetSubCategories(string root)
        {
            var words = GetWordsFromRootCategory(root);
            List<string> categories = new List<string>();
            bool exists = false;

            foreach(Word word in words)
            {
                foreach (string cat in categories)
                {
                    if (word.SubCategory.Equals(cat))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    categories.Add(word.SubCategory);
                }
            }

            return categories;
        }

        //sorted alphabetically
        public static List<Word> GetWordsFromRootCategory(string category)
        {
            List<Word> words = App.Dictionary.GetAllWords();
            List<Word> wordsInCat = new List<Word>();

            foreach (Word word in words)
            {
                if (word.RootCategory.Equals(category))
                {
                    wordsInCat.Add(word);
                }
            }

            wordsInCat.Sort();

            return wordsInCat;
        }

        public static List<string> GetWordNamesFromCategory(string category)
        {
            var words = App.Dictionary.GetAllWords();
            List<string> wordsInCat = new List<string>();

            foreach (Word word in words)
            {
                if(word.SubCategory.Equals(category))
                {
                    wordsInCat.Add(word.Name);
                }
            }

            return wordsInCat;
        }
    }
}
