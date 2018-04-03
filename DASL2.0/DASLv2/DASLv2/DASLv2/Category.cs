﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DASLv2
{
    public static class Category
    {

        public static List<string> GetRootCategories()
        {
            var words = App.Dictionary.GetAllWords();
            List<string> categories = new List<string>();
            bool exists = false;

            foreach(Word word in words)
            {
                foreach(string cat in categories)
                {
                    if(word.RootCategory.Equals(cat))
                    {
                        exists = true;
                        break;
                    }
                }

                if(!exists)
                {
                    categories.Add(word.RootCategory);
                }
            }

            return categories;
        }

        public static List<string> getSubCategories(string root)
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
            var words = App.Dictionary.GetAllWords();
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
