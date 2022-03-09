using ListManagement.models;
using Newtonsoft.Json.Linq;
using System;

namespace Library.ListManagement.Standard.utilities
{
    public class ItemJsonConverter : JsonCreationConverter<Item>
    {
        protected override Item Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");

            if (jObject["isCompleted"] != null || jObject["IsCompleted"] != null)
            {
                return new ToDo();
            }
            else if (jObject["startDate"] != null || jObject["StartDate"] != null)
            {
                return new Appointment();
            }
            else
            {
                return new Item();
            }
        }
    }
}
