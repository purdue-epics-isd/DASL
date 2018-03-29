using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;
using System.Linq;
using System.Diagnostics;

namespace DASL
{
    public static class Database
    {
        //path string for database
        static string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");
        static SQLiteConnection db;
        static StreamReader reader;

        static Database()
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Word>();
        }

        public static void AddWord(Word word)
        {
            //Add word capability
            db.Insert(word);
            //reader.Append(word.ToString);
            return;
        }

        public static void InitUpdate()
        {
            reader = new StreamReader(File.OpenRead("DASL dictionary.csv"));
            return;
        }

        public static void UpdateDatabase()
        {
            //Used to update the databse with the online database
        }

        public static void TestDb()
        {
            Console.WriteLine("How do you do");

            var table = db.Table<Word>();
            string toCommand;

            foreach(var item in table)
            {
                Word word = new Word(item.Name, item.Speech, item.Sentence, item.Category);
                toCommand = word.ToString();
                Debug.WriteLine(toCommand + "\n");
            }
        }
    }
}
