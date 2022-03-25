using ListManagement.models;
using ListManagement.services;
using ListManagement.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPListManagement.services;

namespace UWPListManagement.ViewModels
{
    public class MainViewModel
    {
        private ItemServiceProxy itemService = new ItemServiceProxy();

        public MainViewModel()
        {

        }

        public ObservableCollection<ItemViewModel> Items
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
            //itemService.Add(item);
        }

        private void Load(string path)
        {
            MainViewModel mvm;
            if (File.Exists(path))
            {
                try
                {
                    mvm = JsonConvert
                    .DeserializeObject<MainViewModel>(File.ReadAllText(path));

                    SelectedItem = mvm.SelectedItem;

                }
                catch (Exception)
                {
                    File.Delete(path);
                }

            }
        }

        public void Save()
        {
            //itemService.Save();
        }
    }
}
