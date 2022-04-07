using ListManagement.models;
using Mobile.ListManagement.Dialogs;
using Mobile.ListManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.ListManagement
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();


        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            var diag = new ToDoDialog(BindingContext as MainViewModel);
            Navigation.PushModalAsync(diag);
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var diag = new ToDoDialog(BindingContext as MainViewModel, true);
            Navigation.PushModalAsync(diag);
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Save();
        }
    }
}
