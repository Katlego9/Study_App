using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyApp
{
    public class Members
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

    }
}
