﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;

namespace StudyApp.Subjects
{
    public class SubjectViewModel : ViewModelBase
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

        private string Sbjname = string.Empty;
        public string SbjName
        {
            get
            { return Sbjname; }

            set
            {
                if (Sbjname == value)
                { return; }

                Sbjname = value;
                RaisePropertyChanged("SbjName");
            }
        }

        private int Sbjmark = 0;
        public int SbjMark
        {
            get
            { return Sbjmark; }

            set
            {
                if (Sbjmark == value)
                { return; }

                Sbjmark = value;
                RaisePropertyChanged("SbjMark");
            }
        }

        private int Obtainmark = 0;
        public int ObtainMark
        {
            get
            { return Obtainmark; }

            set
            {
                if (Obtainmark == value)
                { return; }

                Obtainmark = value;
                RaisePropertyChanged("ObtainMark");
            }
        }

        private string performance = string.Empty;
        public string Performance
        {
            get
            { return performance; }

            set
            {
                if (performance == value)
                { return; }

                performance = value;
                RaisePropertyChanged("Performance");
            }
        }
        #endregion "Properties"

        private StudyApp.App app = (Application.Current as App);

        public Subject getSubject(string sbjname, int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _sub = db.Query<Subject>("Select * from Subject Where SbjName ='" + sbjname + "' AND MemID = "+CurrentID+" ").FirstOrDefault();
                return _sub;

            }
        }

        public Subject UpdateSubject(string sbjname, int mark, string status,int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _sub = db.Query<Subject>("Update Subject set ObtainMark = " + mark + ", Performance = '" + status + "' Where SbjName ='" + sbjname + "'AND MemID = "+ CurrentID+" ").FirstOrDefault();
                return _sub;

            }
        }

        public Subject RemoveSubject(int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _sub = db.Query<Subject>("Delete from Subject where MemID = '"+CurrentID+"'").FirstOrDefault();
                return _sub;

            }
        }
        public void SetSubject(string Name, int Mark, int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                int success = db.Insert(new Subject()
                {
                    Id = 0,
                    SbjName = Name,
                    SbjMark = Mark,
                    ObtainMark = 0,
                    Performance = "N/A",
                    MemID = CurrentID,
                });
            }

        }
    }
}
