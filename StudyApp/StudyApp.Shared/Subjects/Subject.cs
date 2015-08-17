using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyApp.Subjects
{
    public class Subject
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string SbjName { get; set; }
        public int SbjMark { get; set; }
        public int ObtainMark { get; set; }
        public string Performance { get; set; }

    }
}

