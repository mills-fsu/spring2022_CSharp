using Library.ListManagement.Standard.DTO;
using ListManagement.models;
using ListManagement.services;
using ListManagement.ViewModels;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPListManagement.Dialogs
{
    public sealed partial class ToDoDialog : ContentDialog
    {
        private ObservableCollection<ItemViewModel> _toDoCollection;
        public ToDoDialog(ObservableCollection<ItemViewModel> _items)
        {
            this.InitializeComponent();
            _toDoCollection = _items;

            DataContext = new ToDo();
        }

        public ToDoDialog(Item item, ObservableCollection<ItemViewModel> _items)
        {
            this.InitializeComponent();
            _toDoCollection = _items;
            DataContext = item;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var item = new ItemViewModel(DataContext as ToDoDTO);
            if(_toDoCollection.Any(i => i.Id == item.Id))
            {
                var itemToUpdate = _toDoCollection.FirstOrDefault(i => i.Id == item.Id);
                var index = _toDoCollection.IndexOf(itemToUpdate);
                _toDoCollection.RemoveAt(index);
                _toDoCollection.Insert(index, item);
            } else
            {
                ItemService.Current.Add(DataContext as ToDoDTO);
            }

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
