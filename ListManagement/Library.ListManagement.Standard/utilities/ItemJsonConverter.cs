using Library.ListManagement.Standard.DTO;
using ListManagement.models;
using Newtonsoft.Json.Linq;
using System;

namespace Library.ListManagement.Standard.utilities
{
    public class ItemJsonConverter : JsonCreationConverter<ItemDTO>
    {
        protected override ItemDTO Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");

            if (jObject["isCompleted"] != null || jObject["IsCompleted"] != null)
            {
                return new ToDoDTO();
            }
            else if (jObject["start"] != null || jObject["Start"] != null)
            {
                return new AppointmentDTO();
            }
            else
            {
                return new ItemDTO();
            }
        }
    }
}
