using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace DASLv2
{
    public static class Category
    {
        //THis method looks at all of the words in the database and finds the names for all of the root categories. (root categoires are stored as an intrinsic part of a word)
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

        //Same as the GetRootCategories class, except that it does it for all of the sub-categories in a root category
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

        //This gets all of the words within a root category. It is currently just used in the GetSubCategories method.
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

        //Given a sub category, this method will return all of the names of the words that fall beneath it.
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
