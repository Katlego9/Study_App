using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace StudyApp
{
    public class MembersViewModel : ViewModelBase
    {
        private ObservableCollection<MemberViewModel> members;
        public ObservableCollection<MemberViewModel> Members
        {
            get
            {
                return members;
            }

            set
            {
                members = value;
                RaisePropertyChanged("Members");
            }
        }
        private StudyApp.App app = (Application.Current as App);

        public ObservableCollection<MemberViewModel> GetMembers()
        {
            members = new ObservableCollection<MemberViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Table<Members>().OrderBy(c => c.Name);
                foreach (var _member in query)
                {
                    var member = new MemberViewModel()
                    {
                        Id = _member.Id,
                        Name = _member.Name,
                        Password = _member.Password,

                    };
                    members.Add(member);
                }
            }
            return members;
        }
        public ObservableCollection<MemberViewModel> GetAllMembers()
        {
            members = new ObservableCollection<MemberViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var q = db.Query<Members>("select * from members");
                foreach (var _member in q)
                {
                    var member = new MemberViewModel()
                    {
                        Id = _member.Id,
                        Name = _member.Name,
                        Password = _member.Password,

                    };
                    members.Add(member);
                }
            }
            return members;
        }

    }
}
