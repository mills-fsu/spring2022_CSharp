using Api.ToDoApplication.Persistence;
using API.ListManagement.database;
using Library.ListManagement.Standard.DTO;
using ListManagement.models;
using ListManagement.services;

namespace API.ListManagement.EC
{
    public class ToDoEC
    {
        public IEnumerable<ToDoDTO> Get()
        {
            //return FakeDatabase.ToDos.Select(t => new ToDoDTO(t));
            return Filebase.Current.ToDos.Select(t => new ToDoDTO(t));
        }

        public ToDoDTO AddOrUpdate(ToDoDTO todo)
        {
            if (todo.Id <= 0)
            {
                //CREATE
                todo.Id = ItemService.Current.NextId;
                //FakeDatabase.ToDos.Add(new ToDo(todo));
                Filebase.Current.AddOrUpdate(new ToDo(todo));
            }
            else
            {
                //UPDATE
                var itemToUpdate = FakeDatabase.ToDos.FirstOrDefault(i => i.Id == todo.Id);
                if (itemToUpdate != null)
                {
                    var index = FakeDatabase.ToDos.IndexOf(itemToUpdate);
                    FakeDatabase.ToDos.Remove(itemToUpdate);
                    FakeDatabase.ToDos.Insert(index, new ToDo(todo));
                }
                else
                {
                    //CREATE -- Fall-Back
                    FakeDatabase.ToDos.Add(new ToDo(todo));
                }
            }

            return todo;
        }

        public ToDoDTO Delete(int id)
        {
            var todoToDelete = FakeDatabase.ToDos.FirstOrDefault(i => i.Id == id);
            if(todoToDelete != null)
            {
                FakeDatabase.ToDos.Remove(todoToDelete);
            }

            return new ToDoDTO(todoToDelete);
        }
    }
}
