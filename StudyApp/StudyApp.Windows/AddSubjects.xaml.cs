using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSubjects : Page
    {
        SubjectsViewModel SubjectModel = null;
        ObservableCollection<SubjectViewModel> subjets = null;
        int GetID = 0;
        public AddSubjects()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);
                GetID = (int)e.Parameter;
                lstOutput.Items.Clear();
            }
            catch
            {
 
            }                
        }
        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }

        private bool verifyDuplication(string name)
        {
            bool status = false;

            SubjectModel = new SubjectsViewModel();

            subjets = SubjectModel.GetAllSubjects(GetID);
            if (subjets != null)
            {
                foreach (var s in subjets)
                {
                    if (name == s.SbjName)
                    {
                        status = true;
                    }
                }
            }
            return status;
        }
        private void btnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            var objSubject = new SubjectViewModel();

            string sbjName = string.Empty;
            int sbjMark = 0;
            int verifyNum;
            string status = string.Empty;

            try
            {
                bool isNumeric = int.TryParse(txbGoalMark.Text, out verifyNum);

                if (isNumeric == true)
                {
                    sbjName = txbSubject.Text;
                    sbjMark = Convert.ToInt16(txbGoalMark.Text);

                    if (!sbjName.Equals(""))
                    {
                        if ((sbjMark >= 50) && (sbjMark <= 100))
                        {
                            if (verifyDuplication(sbjName) != true)
                            {
                                
                                objSubject.SetSubject(sbjName, sbjMark, GetID);
                                status = "Successfully added" + "\n" + sbjName + " with a goal mark of " + sbjMark;
                                lstOutput.Items.Add("Name: " + sbjName + "\nGoal mark of: " + sbjMark);

                                txbSubject.Text = "";
                                txbGoalMark.Text = "";

                            }
                            else
                            {
                                status = "Subject name already exist. \nPlease choose another name.";
                            }
                        }
                        else
                        {
                            status  = "Please specify the goal mark between 50 and 100.";

                        }
                    }
                    else
                    {
                        status  = "Please fill the subject name";
                    }
                }
                else
                {
                    status = "Please enter a numeric number on the goal mark.";
                }
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }

            if (status != string.Empty)
                messageBox(status);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage),GetID);
        }
    }
}
