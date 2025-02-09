using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyChat002.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Type { get; set; }   //0-Asking; 1-Answer
        public string Text { get; set; }
        public DateTime Date { get; set; }

    }
}
