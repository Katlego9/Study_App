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
    public sealed partial class FogotPage : Page
    {
        public FogotPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += OnBackPressed;
        }

        private void OnBackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = true;
            this.Frame.Navigate(typeof(LogIn));

        } 

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }
       
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var objForgot = new MemberViewModel();

            string name = string.Empty;
            string status = string.Empty;
            name = txbUsername.Text;

            try
            {
                if (name != string.Empty)
                {

                    var valid = objForgot.getForgot(name);
                    if (valid != null)
                    {
                        status = "Your Password is" + "\n" + valid.Password;
                        this.Frame.Navigate(typeof(LogIn));

                    }
                    else
                    {
                        status = "Incorrect username, please try again";
                        txbUsername.Text = "";

                    }
                    messageBox(status);
                }
                else
                {
                    messageBox("Please enter username.");
                }
            } 
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
        }
    }
}
