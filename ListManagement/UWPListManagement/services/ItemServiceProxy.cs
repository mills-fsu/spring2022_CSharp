using ListManagement.services;
using ListManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPListManagement.services
{
    public class ItemServiceProxy
    {
        private ItemService itemService;

        public ItemServiceProxy ()
        {
            itemService = ItemService.Current;
        }


        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                return new ObservableCollection<ItemViewModel>
                    (itemService.Items.Select(i => new ItemViewModel(i)));
            }
        }
    }
}
