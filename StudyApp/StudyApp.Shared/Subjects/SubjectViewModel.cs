using System;
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
                RaisePropertyChanged("sbjMark");
            }
        }

        #endregion "Properties"

        private StudyApp.App app = (Application.Current as App);

        public Subject getSubject(string sbjname)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _sub = db.Query<Subject>("Select * from Subject Where SbjName ='" + sbjname + "'").FirstOrDefault();
                return _sub;

            }
        }

        public Subject getMark(int sbjMark)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _sub = db.Query<Subject>("Select * from Subject Where SbjMark ='" + sbjMark + "'").FirstOrDefault();
                return _sub;

            }
        }
        public void SetSubject(string Name, int Mark)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                int success = db.Insert(new Subject()
                {
                    Id = 0,
                    SbjName = Name,
                    SbjMark = Mark,
                });
            }

        }
    }
}
