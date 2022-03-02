using ListManagement.models;
using ListManagement.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPListManagement.ViewModels
{
    public class MainViewModel
    {
        private ItemService itemService = ItemService.Current;

        public ObservableCollection<Item> Items
        {
            get
            {
                return itemService.Items;
            }
        }

        public Item SelectedItem
        {
            get; set;
        }

        public void Add(Item item)
        {
            itemService.Add(item);
        }
    }
}
