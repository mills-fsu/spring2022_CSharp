using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPListManagement.Dialogs;
using UWPListManagement.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPListManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new MainViewModel();
        }

        private async void AddToDoClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Add(
                new ListManagement.models.ToDo { Name = "Test", Description = "Test Description" }
                );

            var dialog = new ToDoDialog();
            await dialog.ShowAsync();
        }

        private async void AddAppointmentClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).Add(
                new ListManagement.models.Appointment { Name = "Test", Description = "Test Description" }
                );

            var dialog = new AppointmentDialog();
            await dialog.ShowAsync();
        }
    }
}
