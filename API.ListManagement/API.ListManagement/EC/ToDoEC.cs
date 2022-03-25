using API.ListManagement.database;
using Library.ListManagement.Standard.DTO;
using ListManagement.models;

namespace API.ListManagement.EC
{
    public class ToDoEC
    {
        public IEnumerable<ItemDTO> Get()
        {
            return FakeDatabase.Items.Select(t => new ItemDTO(t));
        }
    }
}
