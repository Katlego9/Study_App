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
            var objSubject = new SubjectViewModel();

            string sbjName = string.Empty;
            int sbjMark = 0;
            int verifyNum;

            bool isNumeric = int.TryParse(txbGoalMark.Text, out verifyNum);

            if (isNumeric == true)
            {
                sbjName = txbSubject.Text;
                sbjMark = Convert.ToInt16(txbGoalMark.Text);

                if (!sbjName.Equals(""))
                {
                        if ((sbjMark >= 50) && (sbjMark <= 100))
                        {
                            try
                            {
                                objSubject.SetSubject(sbjName, sbjMark);
                                messageBox("Successfully added" + "\n" + sbjName + " with a goal mark of " + sbjMark);
                                txbSubject.Text = "";
                                txbGoalMark.Text = "";
                            }
                            catch (Exception ex)
                            {
                                messageBox("error " + ex.Message);
                            }
                        }
                        else
                        {
                            messageBox("Please specify the goal mark between 50 and 100.");

                        }
                }
                else
                {
                    messageBox("Please fill the subject name");
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
