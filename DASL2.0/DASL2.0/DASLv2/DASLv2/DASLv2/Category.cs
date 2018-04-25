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
                    if(String.Equals(word.RootCategory.Trim(),cat))
                    {
                        exists = true;
                        break;
                    }
                }
                if(exists == false)
                {
                    categories.Add(word.RootCategory.Trim());
                }
            }
            return categories;
        }

        public static List<string> GetSubCategories(string root)
        {
            List<string> categories;
            try
            {
                List<Word> words = GetWordsFromRootCategory(root);
                categories = new List<string>();
                bool exists = false;

                foreach (Word word in words)
                {
                    exists = false;
                    foreach (string cat in categories)
                    {
                        if (String.Equals(word.SubCategory.Trim().ToLower(), cat.Trim().ToLower()))
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (exists == false)
                    {
                        categories.Add(word.SubCategory.Trim());
                    }
                }
                return categories;
            }
            catch
            {
                return new List<string>();
            } 
        }

        //sorted alphabetically
        public static List<Word> GetWordsFromRootCategory(string category)
        {
            List<Word> words = App.Dictionary.GetAllWords();
            List<Word> wordsInCat = new List<Word>();

            foreach (Word word in words)
            {
                if (String.Equals(word.RootCategory.Trim().ToLower(), category.Trim().ToLower()))
                {
                    wordsInCat.Add(word);
                }
            }
            return wordsInCat;
        }

        public static List<string> GetWordNamesFromCategory(string category)
        {
            var words = App.Dictionary.GetAllWords();
            List<string> wordsInCat = new List<string>();

            foreach (Word word in words)
            {
                if(String.Equals(word.SubCategory.Trim().ToLower(), category.Trim().ToLower()))
                {
                    wordsInCat.Add(word.Name.Trim());
                }
            }

            return wordsInCat;
        }
    }
}
