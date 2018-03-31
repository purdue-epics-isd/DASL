using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DASLv2
{
    [Table("word")]
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("name"), Unique]
        public string Name { get; set; }

        [Column("speech")]
        public string Speech { get; set; }

        [Column("sentence")]
        public string Sentence { get; set; }
        
        [Column("category")]
        public string Category { get; set; }

        public override string ToString()
        {
            return Name + " " + Speech + " " + Sentence + " " + Category;
        }
    }
}
 