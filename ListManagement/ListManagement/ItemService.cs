using ListManagement.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManagement
{
    public class ItemService
    {
        private List<Item> items;

        static private ItemService instance;

        public List<Item> Items {
            get {
                return items;
            }
        }

        public static ItemService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemService();
                }
                return instance;
            }
        }

        private ItemService()
        {
            items = new List<Item>();
        }

        public void Add(Item i)
        {
            items.Add(i);
        }

        public void Remove (Item i)
        {
            items.Remove(i);
        }
    }
}
