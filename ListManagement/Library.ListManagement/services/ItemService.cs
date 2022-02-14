using Library.ListManagement.helpers;
using ListManagement.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManagement.services
{
    public class ItemService
    {
        private List<Item> items;
        private ListNavigator<Item> listNav;
        private string persistencePath;
        private JsonSerializerSettings serializerSettings
            = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        static private ItemService instance;

        public bool ShowComplete { get; set; }
        public List<Item> Items {
            get {
                return items;
            }
        }

        public IEnumerable<Item> FilteredItems
        {
            get
            {
                return Items.Where(i =>
                (!ShowComplete && !((i as ToDo)?.IsCompleted ?? true)) //incomplete only
                || ShowComplete);
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

            persistencePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (File.Exists(persistencePath))
            {
                try
                {
                    var state = File.ReadAllText(persistencePath);
                    if (state != null)
                    {
                        items = JsonConvert.DeserializeObject<List<Item>>(state, serializerSettings) ?? new List<Item>();
                    }
                } catch (Exception e)
                {
                    File.Delete(persistencePath);
                    items = new List<Item>();
                }
            }

            listNav = new ListNavigator<Item>(FilteredItems, 2);
        }

        public void Add(Item i)
        {
            if (i.Id <= 0)
            {
                i.Id = nextId;
            }
            items.Add(i);
        }

        public void Remove(Item i)
        {
            items.Remove(i);
        }

        public void Save()
        {

            var listJson = JsonConvert.SerializeObject(Items, serializerSettings);
            if (File.Exists(persistencePath))
            {
                File.Delete(persistencePath);
            }
            File.WriteAllText(persistencePath, listJson);
        }

        public Dictionary<object, Item> GetPage()
        {
            var page = listNav.GetCurrentPage();
            if (listNav.HasNextPage)
            {
                page.Add("N", new Item { Name = "Next" });
            } if (listNav.HasPreviousPage)
            {
                page.Add("P", new Item { Name = "Previous" });
            }
            return page;
        }

        public Dictionary<object, Item> NextPage()
        {
            return listNav.GoForward();
        }

        public Dictionary<object, Item> PreviousPage()
        {
            return listNav.GoBackward();
        }

        private int nextId {
            get
            {
                return Items.Select(i => i.Id).Max() + 1;
            }
        }
    }
}
