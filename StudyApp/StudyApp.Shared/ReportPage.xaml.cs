﻿using StudyApp.Reminders;
using StudyApp.StudyTime;
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
    public sealed partial class ReportPage : Page
    {
        SubjectsViewModel SubjectModel = null;
        ObservableCollection<SubjectViewModel> subjets = null;

        RemindersViewModel ReminderModel = null;
        ObservableCollection<ReminderViewModel> reminders = null;

        StudysViewModel StudyModel = null;
        ObservableCollection<StudyViewModel> study = null;

        public ReportPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                  cmbOutput.Items.Add("Progress");
                  cmbOutput.Items.Add("Reminders");
                  cmbOutput.Items.Add("StudyTime");
                  btnClear.IsEnabled = false;
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
        }

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void cmbOutput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string output = string.Empty;
            btnClear.IsEnabled = true;
            
            try
            {
                output = (string)cmbOutput.SelectedItem;

                if (output != null)
                {
                    if (output == "Progress")
                    {
                        SubjectModel = new SubjectsViewModel();
                        try
                        {
                            subjets = SubjectModel.GetAllSubjects();
                            if (subjets != null)
                            {
                                lsvOutput.Items.Clear();
                                foreach (var s in subjets)
                                {
                                    lsvOutput.Items.Add("=========================");
                                    lsvOutput.Items.Add("Progress Details");
                                    lsvOutput.Items.Add("Name: " + s.SbjName);
                                    lsvOutput.Items.Add("Goal Mark: " + s.SbjMark);
                                    lsvOutput.Items.Add("Obtained Mark: " + s.ObtainMark);
                                    lsvOutput.Items.Add("Performance: " + s.Performance);
                                }
                                btnClear.Content = "Delete all Subjects";

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
                    }
                    else if (output == "Reminders")
                    {
                        ReminderModel = new RemindersViewModel();
                        try
                        {
                            reminders = ReminderModel.GetAllReminders();
                            if (reminders != null)
                            {
                                lsvOutput.Items.Clear();
                                foreach (var r in reminders)
                                {
                                    lsvOutput.Items.Add("=========================");
                                    lsvOutput.Items.Add("Reminder Details");
                                    lsvOutput.Items.Add("Name: " + r.rName);
                                    lsvOutput.Items.Add("Due Date: " + r.rDate);
                                }
                                btnClear.Content = "Delete all Reminders";
                                
                            }
                            else
                            {
                                messageBox("No Reminders in the database");
                            }
                        }
                        catch (Exception ex)
                        {
                            messageBox("error " + ex.Message);
                        }
                    }
                    else if (output == "StudyTime")
                    {
                        StudyModel = new StudysViewModel();
                        try
                        {
                            study = StudyModel.GetAllStudies();
                            if (study != null)
                            {
                                lsvOutput.Items.Clear();
                                foreach (var s in study)
                                {
                                    lsvOutput.Items.Add("=========================");
                                    lsvOutput.Items.Add("Study Details");
                                    lsvOutput.Items.Add("Name: " + s.StudyName);
                                    lsvOutput.Items.Add("Duration: " + s.Duration);
                                    lsvOutput.Items.Add("Date: " + s.Date);
                                }
                                btnClear.Content = "Delete all Study Times";
                            }
                            else
                            {
                                messageBox("No Studies in the database");
                            }
                        }
                        catch (Exception ex)
                        {
                            messageBox("error " + ex.Message);
                        }
                    }

                }
                else
                {
                    messageBox("No output is selected above");
                }
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            var objSubject = new SubjectViewModel();
            var objReminder = new ReminderViewModel();
            var objStudy = new StudyViewModel();
            string output = (string)cmbOutput.SelectedItem;
            string table = string.Empty;

            try
            {
                if (output == "Progress")
                {
                    lsvOutput.Items.Clear();
                    objSubject.RemoveSubject();

                }
                else if (output == "Reminders")
                {
                    lsvOutput.Items.Clear();
                    objReminder.RemoveReminder();

                }
                else if (output == "StudyTime")
                {
                    lsvOutput.Items.Clear();
                    objStudy.RemoveStudy();
                }
            }
            catch(Exception ex)
            {
                if (output == "Progress")
                    table = "Subjects";
                else if (output == "Reminders")
                    table = "Reminders";
                else if (output == "StudyTime")
                    table = "StudyTimes";

                messageBox("error " + ex.Message + "\nPlease add " + table);
            }
        }
    }
}
