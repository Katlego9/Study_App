using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyApp.StudyTime
{
    public class Study
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string StudyName { get; set; }
        public string Duration { get; set; }
    }
}
