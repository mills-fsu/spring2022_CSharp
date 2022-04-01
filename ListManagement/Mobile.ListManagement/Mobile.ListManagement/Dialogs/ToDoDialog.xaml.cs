using Library.ListManagement.Standard.DTO;
using ListManagement.models;
using Mobile.ListManagement.Services;
using Mobile.ListManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.ListManagement.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoDialog : ContentPage
    {
        private MainViewModel _mainViewModel;
        private ItemServiceProxy itemServiceProxy = ItemServiceProxy.Current;
        public ToDoDialog(MainViewModel mvm)
        {
            InitializeComponent();
            _mainViewModel = mvm;
        }

        private void OK_Clicked(object sender, EventArgs e)
        {
            //Do some stuff
            itemServiceProxy.Add(new ItemViewModel(new ToDoDTO(new ToDo {Name = "TEST", Description = "TEST DESC" })));
            _mainViewModel.Refresh();
            Navigation.PopModalAsync();
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}