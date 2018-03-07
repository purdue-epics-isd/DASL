using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DASL
{
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public string Name { get; set; }

        public string Speech { get; set; }

        public string Sentence { get; set; }
        
        public string Category { get; set; }

        public override string ToString()
        {
            return string.Format("[Word: Name = {0}, Part of Speech: Speech = {1}", Name, Speech);
        }
    }
}
 