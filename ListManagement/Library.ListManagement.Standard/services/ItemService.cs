using Library.ListManagement.helpers;
using Library.ListManagement.Standard.utilities;
using ListManagement.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManagement.services
{
    public class ItemService
    {
        private ObservableCollection<Item> items;
        private ListNavigator<Item> listNav;
        private string persistencePath;
        private JsonSerializerSettings serializerSettings
            = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        static private ItemService instance;

        public bool ShowComplete { get; set; }
        public ObservableCollection<Item> Items {
            get {
                return items;
            }
        }

        public string Query { get; set; }

        public IEnumerable<Item> FilteredItems
        {
            get
            {
                var incompleteItems = Items.Where(i =>
                (!ShowComplete && !((i as ToDo)?.IsCompleted ?? true)) //incomplete only
                || ShowComplete);
                //show complete (all)

                var searchResults = incompleteItems.Where(i => string.IsNullOrWhiteSpace(Query)
                //there is no query
                || (i?.Name?.ToUpper()?.Contains(Query.ToUpper()) ?? false)   
                //i is any item and its name contains the query
                || (i?.Description?.ToUpper()?.Contains(Query.ToUpper()) ?? false)                                        
                //or i is any item and its description contains the query
                ||((i as Appointment)?.Attendees?.Select(t => t.ToUpper())?.Contains(Query.ToUpper()) ?? false));         
                //or i is an appointment and has the query in the attendees list
                return searchResults;
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
            items = new ObservableCollection<Item>();
            persistencePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\SaveData.json";
            try
            {
                LoadFromServer();
            } catch(Exception)
            {
                LoadFromDisk();
            }
        }

        private void LoadFromServer()
        {
            var payload = JsonConvert
            .DeserializeObject<List<Item>>(new WebRequestHandler()
            .Get("http://localhost:7020/ToDo").Result);

            payload.ToList().ForEach(items.Add);

            listNav = new ListNavigator<Item>(FilteredItems, 2);
        }

        private void LoadFromDisk()
        {
            
            if (File.Exists(persistencePath))
            {
                try
                {
                    var state = File.ReadAllText(persistencePath);
                    if (state != null)
                    {
                        items = JsonConvert
                        .DeserializeObject<ObservableCollection<Item>>(state, serializerSettings) ?? new ObservableCollection<Item>();
                    }
                }
                catch (Exception e)
                {
                    File.Delete(persistencePath);
                    items = new ObservableCollection<Item>();
                }
            }
        }

        public void Add(Item i)
        {
            if (i.Id <= 0)
            {
                i.Id = NextId;
            }
            items.Add(i);
        }

        public void Remove(Item i)
        {
            //items.Remove(i);
        }

        public void Save()
        {
            //first save to disk (pass-through cache)
            var listJson = JsonConvert.SerializeObject(Items, serializerSettings);
            if (File.Exists(persistencePath))
            {
                File.Delete(persistencePath);
            }
            File.WriteAllText(persistencePath, listJson);

            //post request to add each of these items to the list
            foreach(var i in Items)
            {
                if(i is ToDo)
                {
                    JsonConvert.DeserializeObject<List<Item>>(
                    new WebRequestHandler().Post("http://localhost:7020/ToDo/AddOrUpdate", i).Result);
                }
            }
        }

        public Dictionary<object, Item> GetPage()
        {
            var page = listNav.GetCurrentPage();
            if (listNav.HasNextPage)
            {
                //page.Add("N", new ItemViewModel { Name = "Next" });
            } if (listNav.HasPreviousPage)
            {
                //page.Add("P", new Item { Name = "Previous" });
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

        public int NextId {
            get
            {
                if(Items.Any())
                {
                    return Items.Select(i => i.Id).Max() + 1;
                }
                return 1;
            }
        }
    }
}
