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
using StudyApp.Subjects;
using StudyApp.StudyTime;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudyPage : Page
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private TimeSpan startTime;
        private TimeSpan endTime;
        private TimeSpan now;
        TimeSpan time;


        SubjectsViewModel SubjectModel = null;
        ObservableCollection<SubjectViewModel> subjets = null;

        int GetID = 0;
        bool navigate = true;

        public StudyPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            startTime = tmpStart.Time;
            endTime = tmpEnd.Time;
            now = DateTime.Now.TimeOfDay;
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += Each_Tick;

            Windows.Phone.UI.Input.HardwareButtons.BackPressed += OnBackPressed;
        }

        private void OnBackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = navigate;
            if (navigate != true)
            {
                this.Frame.Navigate(typeof(StudyPage), GetID);
            }
            else
            {
                this.Frame.Navigate(typeof(MainPage), GetID);
            }
        }

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            cmbSubjects.Items.Clear();
            SubjectModel = new SubjectsViewModel();

            string status = string.Empty;

            try
            {
                base.OnNavigatedTo(e);
                GetID = (int)e.Parameter;
                if (timer.IsEnabled != true)
                {
                    subjets = SubjectModel.GetAllSubjects(GetID);
                    if (subjets != null)
                    {
                        foreach (var s in subjets)
                        {
                            cmbSubjects.Items.Add(s.SbjName);
                        }
                    }
                    else
                    {
                        status = "No Subjects in the database";
                    }
                }
                else
                {
                    status = "Study Time has already been started, please try again after time is finished";
                }
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }

            if (status != string.Empty)
                messageBox(status);


        }

        public void TimeTrimmer(TimeSpan timeDifference)
        {
            if (timeDifference < TimeSpan.FromMinutes(1))
            {
                txtTime.Text = timeDifference.Seconds.ToString() + "s";
            }
            if (timeDifference < TimeSpan.FromHours(1) && timeDifference > TimeSpan.FromMinutes(1))
            {
                txtTime.Text = timeDifference.Minutes.ToString() + "m" + timeDifference.Seconds.ToString() + "s";
            }
            if (timeDifference < TimeSpan.FromDays(1) && timeDifference > TimeSpan.FromHours(1))
            {
                txtTime.Text = timeDifference.Hours.ToString() + "h" + timeDifference.Minutes.ToString() + "m" + timeDifference.Seconds.ToString() + "s";
            }
        }

        private void Each_Tick(object sender, object e)
        {
            var studyStartTime = tmpStart.Time;
            var studyEndTime = studyStartTime + TimeSpan.FromSeconds(10);


            var studyStartTime1 = tmpEnd.Time;
            var studyEndTime1 = studyStartTime1 + TimeSpan.FromSeconds(10);

            //Time right now
            var now = DateTime.Now.TimeOfDay;
            var timeDifference = TimeSpan.Zero;

            navigate = false;
            
            if (txtTime.Text != "It is now Time to finish studying!!")
            {
                if (now < studyStartTime)
                {
                    timeDifference = studyStartTime - now;
                    txtElapsedTime.Text = "Time to start studying is in...";
                    TimeTrimmer(timeDifference);
                }

                if (now > studyStartTime && now < studyEndTime)
                {
                    txtElapsedTime.Text = "Yay!";
                    txtTime.Text = "It is now Time to start studying!!";
                }

                if (now > studyEndTime && now < studyStartTime1)
                {
                    timeDifference = studyStartTime1 - now;
                    txtElapsedTime.Text = "Studying has started: Elapsed time is in...";
                    TimeTrimmer(timeDifference);
                }

                if (now > studyStartTime1 && now < studyEndTime1)
                {
                    txtElapsedTime.Text = "Yay!";
                    txtTime.Text = "It is now Time to finish studying!!";
                }
            }
            else
            {
                timer.Stop();
                txtElapsedTime.Text = "";
                txtTime.Text = "";
                navigate = true;
              
            }
        }

        public bool FutureTime()
        {
            if (tmpStart.Time > DateTime.Now.TimeOfDay)
            {
                return true;
            }
            return false;
        }

        public bool GreaterEndTime()
        {
            if (tmpEnd.Time > tmpStart.Time)
            {
                return true;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var studyStartTime = tmpStart.Time;
            var studyEndTime = studyStartTime + TimeSpan.FromSeconds(10);

            var studyStartTime1 = tmpEnd.Time;
            var studyEndTime1 = studyStartTime1 + TimeSpan.FromSeconds(10);

            time = studyEndTime1 - studyEndTime;
            var objStudy = new StudyViewModel();
            string studyName = string.Empty;

            var objSubject = new SubjectViewModel();
            string status = string.Empty;
            studyName = (string)cmbSubjects.SelectedItem;

            try
            {
                studyName = (string)cmbSubjects.SelectedItem;

                var confirm = objSubject.getSubject(studyName, GetID);
                if (confirm != null)
                {
                    if (FutureTime())
                    {
                        if (GreaterEndTime())
                        {
                            objStudy.SetStudy(studyName, time.ToString(), GetID);
                            timer.Start();

                        }
                        else
                        {
                            status = "End time must be greater than the start time";
                        }
                    }
                    else
                    {
                        status = "Start time must be greater than the current time";
                    }
                }
                else
                {
                    status = "Please select a subject to study";
                }
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }

            if (status != string.Empty)
                messageBox(status);

        }
    }
}
