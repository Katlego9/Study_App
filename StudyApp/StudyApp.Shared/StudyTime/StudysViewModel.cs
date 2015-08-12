using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace StudyApp.StudyTime
{
    public class StudysViewModel : ViewModelBase
    {
        private ObservableCollection<StudyViewModel> study;
        public ObservableCollection<StudyViewModel> Study
        {
            get
            {
                return study;
            }

            set
            {
                study = value;
                RaisePropertyChanged("Study");
            }
        }
        private StudyApp.App app = (Application.Current as App);

        public ObservableCollection<StudyViewModel> GetSubjects()
        {
            study = new ObservableCollection<StudyViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Table<Study>().OrderBy(c => c.StudyName);
                foreach (var _subject in query)
                {
                    var studytime = new StudyViewModel()
                    {
                        Id = _subject.Id,
                        StudyName = _subject.StudyName,
                        Duration = _subject.Duration

                    };
                    study.Add(studytime);
                }
            }
            return study;
        }
        public ObservableCollection<StudyViewModel> GetAllSubjects()
        {
            study = new ObservableCollection<StudyViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Study>("select * from study");
                foreach (var _subject in q)
                {
                    var studytime = new StudyViewModel()
                    {
                        Id = _subject.Id,
                        StudyName = _subject.StudyName,
                        Duration = _subject.Duration,

                    };
                    study.Add(studytime);
                }
            }
            return study;
        }
    }
}
