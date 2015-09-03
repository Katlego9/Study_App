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
    
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddSubjects));
        }

        private void btnReminder_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReminderPage));
        }

        private void btnStudy_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StudyPage));
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReportPage));
        }

        private void btnProgress_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Progress));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LogIn));
        }

    }
}
