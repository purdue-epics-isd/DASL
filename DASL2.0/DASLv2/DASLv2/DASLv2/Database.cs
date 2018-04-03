using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;
using System.Linq;
using System.Diagnostics;

namespace DASLv2
{
    public class Database
    {
        //path string for database
        SQLiteConnection db;
        public string StatusMessage { get; set; }

        public Database(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Word>();
        }

        //Adds a word to the database
        public void AddWord(Word word)
        {
            int result = 0;

            try
            {
                result = db.Insert(word);

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, word.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", word.Name, ex.Message);
            }
        }

        //Returns a list of all the words in the current database
        public List<Word> GetAllWords()
        {
            try
            {
                StatusMessage = "Here are all the words in the current database:";
                return db.Table<Word>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Word>();
        }

        //Gets the words from a csv at first launch of app. Maybe we can just have the database filled with information when they download?
        public void InitUpdate()
        {
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\Dictionary\dictionary.csv";

            var reader = new StreamReader(File.OpenRead(file));

            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var row = line.Split(',');

                AddWord(new Word { Name = row[0], Speech = row[1], Sentence = row[2], RootCategory = row[3], SubCategory = row[4] });
            }
        }

        public void UpdateDatabase()
        {
            //Used to update the databse with the online database
        }
    }
}
