using StudyApp.Reminders;
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
    public sealed partial class ReminderPage : Page
    {
        RemindersViewModel ReminderModel = null;
        ObservableCollection<ReminderViewModel> reminders = null;
        public ReminderPage()
        {
            this.InitializeComponent();
        }

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }

        private bool VerifyDateIsFuture(DateTimeOffset date)
        {
            if (date > DateTimeOffset.Now)
            {
                return true;
            }
            return false;
        }
        private bool verifyDuplication(string name)
        {
            bool status = false;

            ReminderModel = new RemindersViewModel();

            reminders = ReminderModel.GetAllReminders();
            if (reminders != null)
            {
                foreach (var r in reminders)
                {
                    if (name == r.rName)
                    {
                        status = true;
                    }
                }
            }
            return status;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ReminderModel = new RemindersViewModel();

            reminders = ReminderModel.GetAllReminders();
            string status = string.Empty;
            try
            {
                if (reminders != null)
                {
                    DateTimeOffset datepicker = System.DateTimeOffset.Now.AddDays(1);
                    string date = datepicker.ToString();
                    string reminderdate = date.Substring(0, 10);

                    DateTimeOffset datepicker1 = System.DateTimeOffset.Now.AddDays(0);
                    string date1 = datepicker1.ToString();
                    string reminderdate1 = date1.Substring(0, 10);
                    lstOutput.Items.Clear();

                    foreach (var r in reminders)
                    {
                        if (r.rDate == reminderdate1)
                        {
                            lstOutput.Items.Add(r.rName + " is due today!!.");
                        }
                        else if (r.rDate == reminderdate)
                        {
                            lstOutput.Items.Add(r.rName + " is due the next day.");
                        }
                    }
                }
                else
                {
                    status = "No reminders found for the next 3 days";
                }

                if (status != string.Empty)
                    messageBox(status);
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }

            base.OnNavigatedTo(e);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var objReminder = new ReminderViewModel();

            string task = string.Empty;
            string status = string.Empty;
            task = txbReminder.Text;

            try
            {
                DateTimeOffset datepicker = dtpDate.Date;

                string date = datepicker.ToString();
                string reminderdate = date.Substring(0, 10);

                if (task != string.Empty)
                {
                    if (VerifyDateIsFuture(datepicker) == true)
                    {
                        if (verifyDuplication(task) != true)
                        {
                            objReminder.SetReminder(task, reminderdate);
                            status = "Successfully added Reminder" + "\n" + task + " with a due date of " + reminderdate;
                            txbReminder.Text = "";
                        }
                        else
                        {
                            status = "Reminder name already exist. \nPlease choose another name.";
                        }
                    }
                    else
                    {
                        status = "Date must be later than today.";
                    }
                }
                else
                {
                    status = "Please specify the reminder name";
                }

                if (status != string.Empty)
                    messageBox(status);
                
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            string status = string.Empty;
            try
            {
                ReminderModel = new RemindersViewModel();
                reminders = ReminderModel.GetAllReminders();

                if (reminders != null)
                {
                    DateTimeOffset datepicker = System.DateTimeOffset.Now.AddDays(2);
                    string date = datepicker.ToString();
                    string reminderdate = date.Substring(0, 10);
                    lstOutput.Items.Clear();

                    foreach (var r in reminders)
                    {
                        if (r.rDate == reminderdate)
                        {
                            lstOutput.Items.Add(r.rName + " is due in the next 2 days.");
                        }
                    }
                }
                else
                {
                    status = "No reminders found for the next 2 days.";
                }

                if (status != string.Empty)
                    messageBox(status);
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
            
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            ReminderModel = new RemindersViewModel();
            reminders = ReminderModel.GetAllReminders();
            string status = string.Empty;

            try
            {
                if (reminders != null)
                {
                    DateTimeOffset datepicker = System.DateTimeOffset.Now.AddDays(3);
                    string date = datepicker.ToString();
                    string reminderdate = date.Substring(0, 10);

                    lstOutput.Items.Clear();
                    foreach (var r in reminders)
                    {

                        if (r.rDate == reminderdate)
                        {
                            lstOutput.Items.Add(r.rName + " is due in the next 3 days.");
                        }
                    }
                }
                else
                {
                    status = "No reminders found for the next 3 days.";
                }

                if (status != string.Empty)
                    messageBox(status);
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
        }
    }

}
    
