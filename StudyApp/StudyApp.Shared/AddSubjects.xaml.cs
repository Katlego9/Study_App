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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StudyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSubjects : Page
    {
        public AddSubjects()
        {
            this.InitializeComponent();
           
        }
        
        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }

        private void btnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            string message;
            var objSubject = new SubjectViewModel();

            string sbjName = string.Empty;
            int sbjMark = 0;

            sbjName = txbSubject.Text;
            sbjMark = Convert.ToInt16(txbGoalMark.Text);

            if ((sbjName != "") && (sbjMark != 0))
            {
                if ((sbjMark >= 50) && (sbjMark <= 100))
                {
                    try
                    {
                        objSubject.SetSubject(sbjName, sbjMark);
                        message = "Successfully added" + "\n" + sbjName + " with a goal mark of " + sbjMark;
                        txbSubject.Text = "";
                        txbGoalMark.Text = "";
                        
                    }
                    catch (Exception)
                    {
                        message = "Please fill the correct format";
                    }
                    
                }
                else
                {
                    message = "Please specify the goal mark between 50 and 100.";
                    
                }
                messageBox(message);
            }
            else
            {
                messageBox("Please fill all fields.");
                
            }
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
