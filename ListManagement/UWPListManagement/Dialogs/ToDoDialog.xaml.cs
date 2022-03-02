using ListManagement.models;
using ListManagement.services;
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
        private ObservableCollection<Item> _toDoCollection;
        public ToDoDialog(ObservableCollection<Item> list)
        {
            this.InitializeComponent();
            _toDoCollection = list;

            DataContext = new ToDo();
        }

        public ToDoDialog(ObservableCollection<Item> list, Item item)
        {
            this.InitializeComponent();
            _toDoCollection = list;
            DataContext = item;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var item = DataContext as ToDo;
            if(_toDoCollection.Any(i => i.Id == item.Id))
            {
                var itemToUpdate = _toDoCollection.FirstOrDefault(i => i.Id == item.Id);
                var index = _toDoCollection.IndexOf(itemToUpdate);
                _toDoCollection.RemoveAt(index);
                _toDoCollection.Insert(index, item);
            } else
            {
                ItemService.Current.Add(DataContext as ToDo);
            }

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
