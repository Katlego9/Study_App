using StudyApp.Reminders;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReminderPage : Page
    {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message;
            var objReminder = new ReminderViewModel();

            string task = string.Empty;
            task = txbReminder.Text;


            DateTimeOffset datepicker = dtpDate.Date;

            string date = datepicker.ToString();
            string reminderdate = date.Substring(0, 10);
          
            if (task != "")
            {
                if (VerifyDateIsFuture(datepicker) == true)
                {
                    try
                    {
                        objReminder.SetReminder(task, reminderdate);
                        message = "Successfully added Reminder" + "\n" + task + " with a due date of " + reminderdate;
                       
                        txbReminder.Text = "";

                    }
                    catch (Exception)
                    {
                        message = "Please fill the correct format";
                    }
                }
                else
                {
                    message = "Date must be later than today.";
                  
                }

            }
            else
            {
               message = "Please specify the reminder name";
            }
            messageBox(message);
              
        }
        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
         }   
        
    }
}
