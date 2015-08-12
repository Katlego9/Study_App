using StudyApp.Subjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimeTable : Page
    {
        SubjectsViewModel SubjectModel = null;
        ObservableCollection<SubjectViewModel> subjets = null;

        public TimeTable()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
          
        }

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            DispatcherTimer timer = new DispatcherTimer();
            TimeSpan startTime;
            timer.Start();

            grdTimeTable.Items.Add("Subject Name" + "\t\t" + "Time\t\t\t");
            SubjectModel = new SubjectsViewModel();
            try
            {
                subjets = SubjectModel.GetAllSubjects();
                if (subjets != null)
                {
                    startTime = new TimeSpan(18, 0, 0);
                    foreach (var s in subjets)
                    {
                        grdTimeTable.Items.Add(s.SbjName + "\t\t" + Convert.ToString(startTime));
                        grdTimeTable.SelectionChanged += grdTimeTable_SelectionChanged;
                        startTime += new TimeSpan(1, 30, 0);
                    }
                }
                else
                {
                    messageBox("No Subjects in the database");
                }
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
            base.OnNavigatedTo(e);
        }
        private void grdTimeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
