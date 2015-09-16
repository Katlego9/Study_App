using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;

namespace StudyApp
{
    public class MemberViewModel : ViewModelBase
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

        private string name = string.Empty;
        public string Name
        {
            get
            { return name; }

            set
            {
                if (name == value)
                { return; }

                name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string password = string.Empty;
        public string Password
        {
            get
            { return password; }

            set
            {
                if (password == value)
                { return; }

                password = value;
                RaisePropertyChanged("Password");
            }
        }

        #endregion "Properties"

        private StudyApp.App app = (Application.Current as App);

        public Members getMember(string name, string pass)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _mem = db.Query<Members>("Select * from Members Where Name ='" + name + "' AND Password = '" + pass + "'").FirstOrDefault();
                return _mem;

            }
        }

        public void SetMember(string name, string pass)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                int success = db.Insert(new Members()
                {
                     Id = 0,
                     Name = name,
                     Password = pass,
                });
            }
        }
 
        public Members getForgot(string name)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var _mem = db.Query<Members>("Select * from Members where name = '" + name + "'").FirstOrDefault();
                return _mem;  

            }
        }
    }
}
