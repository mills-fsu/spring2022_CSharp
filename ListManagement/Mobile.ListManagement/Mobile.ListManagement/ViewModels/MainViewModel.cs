using ListManagement.models;
using Mobile.ListManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mobile.ListManagement.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ItemServiceProxy itemServiceProxy = ItemServiceProxy.Current;
        public ItemViewModel SelectedItem { get; set; }
        public IEnumerable<ItemViewModel> Items { 
            get
            {
                if(ShowComplete)
                {
                    return itemServiceProxy.Items.Where(i => ShowComplete && (string.IsNullOrEmpty(Query)
                        || i.Name.ToUpper().Contains(Query.ToUpper())
                        || i.Description.ToUpper().Contains(Query.ToUpper())));
                }
                return itemServiceProxy.Items.Where(i => !ShowComplete && !(i.BoundToDo?.IsCompleted ?? false) && (string.IsNullOrEmpty(Query)
                    || i.Name.ToUpper().Contains(Query.ToUpper())
                    || i.Description.ToUpper().Contains(Query.ToUpper())));
            }
        }

        private bool _ShowComplete;
        public bool ShowComplete
        {
            set
            {
                _ShowComplete = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Items");
            }

            get
            {
                return _ShowComplete;
            }
        }

        public void Save()
        {
            itemServiceProxy.Save();
        }

        private string _Query;
        public string Query
        {
            set
            {
                _Query = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Items");
            }

            get
            {
                return _Query;
            }
        }

        public MainViewModel()
        {
            
            ShowComplete = true;
        }

        public void Refresh()
        {
            NotifyPropertyChanged("Items");
        }

        public void ClearSelection()
        {
            if(SelectedItem != null)
            {
                SelectedItem = null;
                NotifyPropertyChanged("SelectedItem");
            }
        }
    }
}
