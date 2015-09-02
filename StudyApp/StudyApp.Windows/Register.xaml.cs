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
    public sealed partial class Register : Page
    {
        MembersViewModel MemberModel = null;
        ObservableCollection<MemberViewModel> member = null;
        public Register()
        {
            this.InitializeComponent();
        }

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }
        private bool verifyDuplication(string name)
        {
            bool status = false;

            MemberModel = new MembersViewModel();

            member = MemberModel.GetAllMembers();
            if (member != null)
            {
                foreach (var m in member)
                {
                    if (name == m.Name)
                    {
                        status = true;
                    }
                }
            }
            return status;
        }
    
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txbUsername.Text = string.Empty;
            pwbPass.Password = string.Empty;
            pwbConfirm.Password = string.Empty;
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
                if (verifyDuplication(name) != true)
                {
                    if ((name != string.Empty) && (pass != string.Empty) && (confirm != string.Empty))
                    {
                        if (pass == confirm)
                        {
                            objRegister.SetMember(name, pass);
                            status = "Registration successful";
                            this.Frame.Navigate(typeof(LogIn));

                            txbUsername.Text = string.Empty;
                            pwbPass.Password = string.Empty;
                            pwbConfirm.Password = string.Empty;
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
                    
                }
                else
                {
                    status = "Username already exists. try again";
                }
                messageBox(status);
            }
            catch (Exception ex)
            {
                messageBox("error " + ex.Message);
            }
            
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LogIn));
        }
    }
}
