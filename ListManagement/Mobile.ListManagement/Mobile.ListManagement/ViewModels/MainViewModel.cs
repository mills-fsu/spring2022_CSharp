using ListManagement.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mobile.ListManagement.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Item> _Items;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<Item> Items { 
            get
            {
                return _Items.Where(i => string.IsNullOrEmpty(Query) 
                || i.Name.ToUpper().Contains(Query.ToUpper()) 
                || i.Description.ToUpper().Contains(Query.ToUpper()));
            }
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
            _Items = new ObservableCollection<Item>();
            _Items.Add(new Item { Name = "NAME", Description = "DESCRIPTION" });
            _Items.Add(new Item { Name = "FIRST", Description = "1st DESCRIPTION" });
            _Items.Add(new Item { Name = "SECOND", Description = "2nd DESCRIPTION" });
            _Items.Add(new Item { Name = "THIRD", Description = "3rd DESCRIPTION" });
            _Items.Add(new Item { Name = "FOURTH", Description = "4th DESCRIPTION" });
            _Items.Add(new Item { Name = "FIFTH", Description = "5th DESCRIPTION" });
        }
    }
}
