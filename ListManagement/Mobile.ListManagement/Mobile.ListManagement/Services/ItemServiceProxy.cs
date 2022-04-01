using Library.ListManagement.Standard.DTO;
using ListManagement.models;
using Mobile.ListManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mobile.ListManagement.Services
{
    public class ItemServiceProxy
    {
        public ObservableCollection<ItemViewModel> Items
        {
            get; private set;
        }
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
            Items = new ObservableCollection<ItemViewModel>();
            Items.Add(new ItemViewModel(new ToDoDTO(new ToDo { Name = "NAME", Description = "DESCRIPTION" })));
            Items.Add(new ItemViewModel(new ToDoDTO (new ToDo {Name = "FIRST", Description = "1st DESCRIPTION" })));
            Items.Add(new ItemViewModel(new ToDoDTO (new ToDo{ Name = "SECOND", Description = "2nd DESCRIPTION" })));
        }

        public void Add(ItemViewModel itemViewModel)
        {
            Items.Add(itemViewModel);
        }
    }
}
