using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

//This is the word class. The database structures itself based around this class.
namespace DASLv2
{
    [Table("word")]
    public class Word
    {
        //Names are set to unique so that you do not add two instances of the same word
        [Column("name"),Unique]
        public string Name { get; set; }

        [Column("speech")]
        public string Speech { get; set; }

        [Column("sentence1")]
        public string Sentence1 { get; set; }

        [Column("sentence2")]
        public string Sentence2 { get; set; }

        [Column("sentence3")]
        public string Sentence3 { get; set; }

        [Column("definition")]
        public string Definition { get; set; }

        [Column("parent category")]
        public string RootCategory { get; set; }

        [Column("child category")]
        public string SubCategory { get; set; }

        public override string ToString()
        {
            return Name + " " + Speech + " " + Sentence1 + " " + Sentence2 + " " + Sentence3 + " " + Definition + " " + RootCategory + " " + SubCategory;
        }
    }
}
 