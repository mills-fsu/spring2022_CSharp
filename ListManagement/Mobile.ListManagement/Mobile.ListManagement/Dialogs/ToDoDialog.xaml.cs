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
        public ToDoDialog(MainViewModel mvm, bool edit = false)
        {
            InitializeComponent();
            _mainViewModel = mvm;

            if(edit)
            {
                BindingContext = mvm.SelectedItem;
            } else
            {
                BindingContext = new ItemViewModel(new ToDoDTO(new Item()));
            }
        }


        private void OK_Clicked(object sender, EventArgs e)
        {
            //Do some stuff
            itemServiceProxy.Add(BindingContext as ItemViewModel);
            _mainViewModel.Refresh();
            Navigation.PopModalAsync();
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}