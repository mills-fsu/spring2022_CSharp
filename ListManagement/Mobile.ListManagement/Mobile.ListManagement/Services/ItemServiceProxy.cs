using Library.ListManagement.Standard.DTO;
using ListManagement.models;
using ListManagement.services;
using Mobile.ListManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Mobile.ListManagement.Services
{
    public class ItemServiceProxy
    {
        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                return new ObservableCollection<ItemViewModel>(itemService.Items.Select(i => new ItemViewModel(i)));
            }
        }

        private static ItemService itemService = ItemService.Current;
        private static ItemServiceProxy itemServiceProxy;
        public static ItemServiceProxy Current
        {
            get
            {
                if (itemServiceProxy == null)
                {
                    itemServiceProxy = new ItemServiceProxy();
                }
                return itemServiceProxy;
            }
        }
        private ItemServiceProxy()
        {

        }

        public void Add(ItemViewModel itemViewModel)
        {
            itemService.Add(itemViewModel.BoundItem);
        }

        public void Save()
        {
            itemService.Save();
        }
    }
}
