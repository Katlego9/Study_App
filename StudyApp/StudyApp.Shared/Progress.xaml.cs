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
        public Progress()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SubjectModel = new SubjectsViewModel();
            try
            {
                subjets = SubjectModel.GetAllSubjects();
                if (subjets != null)
                {
                    foreach (var s in subjets)
                    {
                        cmbSubjects.Items.Add(s.SbjName);
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

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }

        private void btnMark_Click(object sender, RoutedEventArgs e)
        {

            var objSubject = new SubjectViewModel();

            string studyName = string.Empty;
            int mark = 0;

            int verifyNum;

            bool isNumeric = int.TryParse(edtMark.Text, out verifyNum);

            if (isNumeric == true)
            {
                studyName = (string)cmbSubjects.SelectedItem;
                mark = Convert.ToInt16(edtMark.Text);

                if ((mark > 0) && (mark <= 100))
                {
                    try
                    {
                        var confirm = objSubject.getSubject(studyName);
                        if (confirm != null)
                        {
                            if (mark >= confirm.SbjMark)
                            {
                                messageBox("Performing better than the goal mark");
                            }
                            else if (mark <= confirm.SbjMark)
                            {
                                messageBox("Performing Badly than the goal mark");
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
                else
                {
                    messageBox("Please specify a number between 0 and 100");
                }
            }
            else
            {
                 messageBox("Please specify a numeric number");
            }
        }
     }
}
