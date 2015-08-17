using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace StudyApp.Subjects
{
        public class SubjectsViewModel : ViewModelBase
        {
            private ObservableCollection<SubjectViewModel> subjects;
            public ObservableCollection<SubjectViewModel> Subjects
            {
                get
                {
                    return subjects;
                }

                set
                {
                    subjects = value;
                    RaisePropertyChanged("Subjects");
                }
            }
            private StudyApp.App app = (Application.Current as App);

            public ObservableCollection<SubjectViewModel> GetSubjects()
            {
                subjects = new ObservableCollection<SubjectViewModel>();
                using (var db = new SQLite.SQLiteConnection(app.dbPath))
                {
                    var query = db.Table<Subject>().OrderBy(c => c.SbjName);
                    foreach (var _subject in query)
                    {
                        var subject = new SubjectViewModel()
                        {
                            Id = _subject.Id,
                            SbjName = _subject.SbjName,
                            SbjMark = _subject.SbjMark,
                            ObtainMark = _subject.ObtainMark,
                            Performance = _subject.Performance

                        };
                        subjects.Add(subject);
                    }
                }
                return subjects;
            }
            public ObservableCollection<SubjectViewModel> GetAllSubjects()
            {
                subjects = new ObservableCollection<SubjectViewModel>();
                using (var db = new SQLite.SQLiteConnection(app.dbPath))
                {
                    var q = db.Query<Subject>("select * from subject");
                    foreach (var _subject in q)
                    {
                        var subject = new SubjectViewModel()
                        {
                            Id = _subject.Id,
                            SbjName = _subject.SbjName,
                            SbjMark = _subject.SbjMark,
                            ObtainMark = _subject.ObtainMark,
                            Performance = _subject.Performance,

                        };
                        subjects.Add(subject);
                    }
                }
                return subjects;
            }

        }
    
}
