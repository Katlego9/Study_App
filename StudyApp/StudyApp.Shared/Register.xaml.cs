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
    public sealed partial class Register : Page
    {

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }

        public Register()
        {
            this.InitializeComponent();
        }

    
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txbUsername.Text = string.Empty;
            pwbPass.Password = string.Empty;
            pwbConfirm.Password = string.Empty;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LogIn));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var objRegister = new MemberViewModel();
            string name = string.Empty;
            string pass = string.Empty;
            string confirm = string.Empty;
            string status = string.Empty;


            name = txbUsername.Text;
            pass = pwbPass.Password;
            confirm = pwbConfirm.Password;

            try
            {
                if ((name != string.Empty) && (pass != string.Empty) && (confirm != string.Empty))
                {
                    if (pass == confirm)
                    {

                        objRegister.SetMember(name, pass);
                        status = "Registration successful";
                        this.Frame.Navigate(typeof(LogIn));
                    }
                    else
                    {
                        status = "Passwords do not match, please try again";
                        pwbPass.Password = "";
                        pwbConfirm.Password = "";

                    }
                }
                else
                {
                    status = "Please fill all the fields";
                }
                messageBox(status);
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
        }
    }
}
