using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;

namespace StudyApp.StudyTime
{
    public class StudyViewModel : ViewModelBase
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

        private string studyName = string.Empty;
        public string StudyName
        {
            get
            { return studyName; }

            set
            {
                if (studyName == value)
                { return; }

                studyName = value;
                RaisePropertyChanged("StudyName");
            }
        }

        private string duration = string.Empty;
        public string Duration
        {
            get
            { return duration; }

            set
            {
                if (duration == value)
                { return; }

                duration = value;
                RaisePropertyChanged("Duration");
            }
        }

        private DateTimeOffset date;
        public DateTimeOffset Date
        {
            get
            { return date; }

            set
            {
                if (date == value)
                { return; }

                date = value;
                RaisePropertyChanged("Date");
            }
        }

        #endregion "Properties"

        private StudyApp.App app = (Application.Current as App);

        public Study getStudyTime(string name, int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _sub = db.Query<Study>("Select * from Study Where StudyName ='" + name + "' AND MemID = '" + CurrentID +"' ").FirstOrDefault();
                return _sub;

            }
        }
        public Study RemoveStudy(int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _sub = db.Query<Study>("Delete from Study where MemID = '" +CurrentID+ "'").FirstOrDefault();
                return _sub;

            }
        }
        public void SetStudy(string name, string duration, int CurrentID)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                int success = db.Insert(new Study()
                {
                    Id = 0,
                    StudyName = name,
                    Duration = duration,
                    Date = DateTimeOffset.Now,
                    MemID = CurrentID,
                });
            }

        }
    }
}
