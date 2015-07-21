using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace StudyApp.Reminders
{
    public class RemindersViewModel : ViewModelBase
    {
            private ObservableCollection<ReminderViewModel> reminder;
            public ObservableCollection<ReminderViewModel> Reminders
            {
                get
                {
                    return reminder;
                }

                set
                {
                    reminder = value;
                    RaisePropertyChanged("Reminders");
                }
            }
            private StudyApp.App app = (Application.Current as App);

            public ObservableCollection<ReminderViewModel> GetSubjects()
            {
                reminder = new ObservableCollection<ReminderViewModel>();
                using (var db = new SQLite.SQLiteConnection(app.dbPath))
                {
                    var query = db.Table<Reminder>().OrderBy(c => c.rName);
                    foreach (var _reminder in query)
                    {
                        var reminders = new ReminderViewModel()
                        {
                            Id = _reminder.Id,
                            rName = _reminder.rName,
                            rDate = _reminder.rDate

                        };
                        reminder.Add(reminders);
                    }
                }
                return reminder;
            }
            public ObservableCollection<ReminderViewModel> GetAllReminders()
            {
                reminder = new ObservableCollection<ReminderViewModel>();
                using (var db = new SQLite.SQLiteConnection(app.dbPath))
                {
                    var q = db.Query<Reminder>("select * from reminder");
                    foreach (var _reminder in q)
                    {
                        var reminders = new ReminderViewModel()
                        {
                            Id = _reminder.Id,
                            rName = _reminder.rName,
                            rDate = _reminder.rDate,

                        };
                        reminder.Add(reminders);
                    }
                }
                return reminder;
            }

        }


}
