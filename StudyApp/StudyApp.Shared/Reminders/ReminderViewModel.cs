﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using System.Linq;

namespace StudyApp.Reminders
{
    public class ReminderViewModel : ViewModelBase
    {

        #region Properties

        private int id = 0;
        public int Id
        {
            get
            { return id; }

            set
            {
                if (id == value)
                { return; }

                id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string RName = string.Empty;
        public string rName
        {
            get
            { return RName; }

            set
            {
                if (RName == value)
                { return; }

                RName = value;
                RaisePropertyChanged("RName");
            }
        }

        private string RDate = string.Empty;
        public string rDate
        {
            get
            { return RDate; }

            set
            {
                if (RDate == value)
                { return; }

                RDate = value;
                RaisePropertyChanged("rDate");
            }
        }

        #endregion "Properties"

        private StudyApp.App app = (Application.Current as App);

        public Reminder getReminder(string rName, int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _rem = db.Query<Reminder>("Select * from Reminder Where rName ='" + rName + "' AND MemID =  '"+CurrentID + "'").FirstOrDefault();
                return _rem;

            }
        }

        public Reminder getDate(string date, int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _rem = db.Query<Reminder>("Select * from Reminder Where rDate = '" + date + "' AND MemID = '" + CurrentID + "' ").FirstOrDefault();
                return _rem;

            }
        }

        public Reminder RemoveReminder(int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _sub = db.Query<Reminder>("Delete From Reminder Where MemID = '" + CurrentID + "'").FirstOrDefault();
                return _sub;

            }
        }
        public void SetReminder(string Name, string Date, int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                int success = db.Insert(new Reminder()
                {
                    Id = 0,
                    rName = Name,
                    rDate = Date,
                    MemID = CurrentID,
                });
            }

        }
    }
}
