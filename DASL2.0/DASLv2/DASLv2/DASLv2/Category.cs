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
                    if(String.Equals(word.RootCategory.Trim(),cat))
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
            List<string> categories;
            try
            {
                Debug.WriteLine("Getting sub categories for [" + root + "]");
                var words = GetWordsFromRootCategory(root);
                categories = new List<string>();
                bool exists = false;

                foreach (Word word in words)
                {
                    exists = false;
                    foreach (string cat in categories)
                    {
                        if (String.Equals(word.SubCategory, cat))
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (exists == false)
                    {
                        categories.Add(word.SubCategory);
                    }
                }
                Debug.WriteLine("cat returned " + categories.Count);
                return categories;
            } catch {
                return new List<string>
                {
                    "Word A",
                    "Word B",
                    "Word C"
                };
            } 
        }

        //sorted alphabetically
        public static List<Word> GetWordsFromRootCategory(string category)
        {
            List<Word> words = App.Dictionary.GetAllWords();
            List<Word> wordsInCat = new List<Word>();

            foreach (Word word in words)
            {
                if (word.RootCategory.Trim().Equals(category))
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
                if(word.SubCategory.Trim().Equals(category))
                {
                    wordsInCat.Add(word.Name.Trim());
                }
            }

            return wordsInCat;
        }
    }
}
