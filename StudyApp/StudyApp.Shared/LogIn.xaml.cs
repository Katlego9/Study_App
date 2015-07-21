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
    public sealed partial class LogIn : Page
    {
        public LogIn()
        {
            this.InitializeComponent();
        }

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message;
            var objLogin = new MemberViewModel();

            string name = string.Empty;
            string pass = string.Empty;
            name = txbName.Text;
            pass = pwbPass.Password;

            if ((name != "") && (pass != ""))
            {
                try
                {
                    var confirm = objLogin.getMember(name, pass);
                    if (confirm != null)
                    {
                        message = "Login successful" + "\nWelcome " + confirm.Name;
                        this.Frame.Navigate(typeof(MainPage));

                    }
                    else
                    {
                        message = "Login not successful, incorrect credentials";
                        txbName.Text = "";
                        pwbPass.Password = "";
                    }
                    messageBox(message);
                }
                catch (Exception)
                {
                }
            }
            else
            {
                messageBox("Please fill all fields.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Register));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtforgot_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void hpbForgot_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FogotPage));
        }
    }
}
