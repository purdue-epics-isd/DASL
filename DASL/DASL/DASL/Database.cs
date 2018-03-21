using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace DASL
{
    class Database
    {
        //path string for database
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");
        SQLiteConnection db;

        public Database()
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Word>();
        }

        public void AddWord(Word word)
        {
            //Add word capability
            db.Insert(word);
            return;
        }

        public void InitUpdate()
        {
            var reader = new StreamReader(File.OpenRead("DASL dictionary.csv"));
            return;
        }

        public void UpdateDatabase()
        {
            //Used to update the databse with the online database
        }
    }
}
