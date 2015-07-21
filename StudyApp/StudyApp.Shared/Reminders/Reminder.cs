using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyApp.Reminders
{
    public class Reminder
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string rName { get; set; }
        public DateTime rDate { get; set; }

    }
}
