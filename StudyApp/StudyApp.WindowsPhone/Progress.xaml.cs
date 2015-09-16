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
    public sealed partial class Progress : Page
    {
        SubjectsViewModel SubjectModel = null;
        ObservableCollection<SubjectViewModel> subjets = null;
        int GetID = 0;
        public Progress()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += OnBackPressed;
        }

        private void OnBackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = true;
            this.Frame.Navigate(typeof(MainPage),GetID);

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string status = string.Empty;

            try
            {
                base.OnNavigatedTo(e);
                GetID = (int)e.Parameter;
                SubjectModel = new SubjectsViewModel();
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
                    status = "No Subjects found";
                }
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }

            if (status != string.Empty)
                messageBox(status);


        }

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }

        private void btnMark_Click(object sender, RoutedEventArgs e)
        {

            var objSubject = new SubjectViewModel();

            string studyName = string.Empty;
            string Performance = string.Empty;
            string status = string.Empty;
            int mark = 0;

            int verifyNum;

            try
            {
                bool isNumeric = int.TryParse(edtMark.Text, out verifyNum);
                studyName = (string)cmbSubjects.SelectedItem;

                var confirm = objSubject.getSubject(studyName, GetID);
                if (confirm != null)
                {
                    if (isNumeric == true)
                    {
                        mark = Convert.ToInt16(edtMark.Text);

                        if ((mark > 0) && (mark <= 100))
                        {
                            if (mark > confirm.SbjMark)
                            {
                                Performance = "Better";
                                status = "Performing better than the goal mark of " + Convert.ToString(confirm.SbjMark);
                            }
                            else if (mark == confirm.SbjMark)
                            {
                                Performance = "Good";
                                status = "Performing good, the marks are equal of " + Convert.ToString(confirm.SbjMark);
                            }
                            else if (mark < confirm.SbjMark)
                            {
                                Performance = "Badly";
                                status = "Performing badly than the goal mark of " + Convert.ToString(confirm.SbjMark);
                            }
                            objSubject.UpdateSubject(studyName, mark, Performance, GetID);
                            messageBox(status);

                        }
                        else
                        {
                            messageBox("Please specify a number between 0 and 100");
                        }
                    }
                    else
                    {
                        messageBox("Please specify a numeric obtained mark");
                    }
                }
                else
                {
                    messageBox("Please select a subject");
                }
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
        }
     }
}
