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
            return Name + " " + Speech + " " + Sentence + " " + Category;
        }

        public Word(string name, string speech, string sentence, string category)
        {
            Name = name;
            Speech = speech;
            Sentence = sentence;
            Category = category;
        }

        public Word()
        {
            
        }
    }
}
 