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

        private ObservableCollection<Item> items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get
            {
                items.Clear();
                itemService.Items.ForEach(items.Add);
                return items;
                //return new ObservableCollection<Item>(itemService.Items);
            }
        }

        private Item selectedItem;
        public Item SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                if(value != selectedItem)
                {
                    selectedItem = value;
                }
            }
        }

        public void Add(Item item)
        {
            itemService.Add(item);
        }
    }
}
