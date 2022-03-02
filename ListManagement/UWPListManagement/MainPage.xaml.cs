using System;
using UWPListManagement.Dialogs;
using UWPListManagement.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            var dialog = new ToDoDialog((DataContext as MainViewModel).Items);
            await dialog.ShowAsync();
        }

        private async void EditToDoClick(object sender, RoutedEventArgs e)
        {
            var dialog = new ToDoDialog((DataContext as MainViewModel).Items, (DataContext as MainViewModel).SelectedItem);
            await dialog.ShowAsync();
        }
    }
}
