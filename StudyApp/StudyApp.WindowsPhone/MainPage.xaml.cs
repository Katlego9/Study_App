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
    public sealed partial class MainPage : Page
    {
        int GetID = 0;
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);
                GetID = (int)e.Parameter;
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddSubjects), GetID);
        }

        private void btnReminder_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReminderPage), GetID);
        }

        private void btnStudy_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StudyPage), GetID);
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReportPage), GetID);
        }

        private void btnProgress_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Progress), GetID);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LogIn));
        }

    }
}
