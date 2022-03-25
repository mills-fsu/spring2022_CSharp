using API.ListManagement.database;
using API.ListManagement.EC;
using Library.ListManagement.Standard.DTO;
using ListManagement.models;
using ListManagement.services;
using Microsoft.AspNetCore.Mvc;

namespace API.ListManagement.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IEnumerable<ItemDTO> Get()
        {
            return new ToDoEC().Get();
        }

        [HttpPost("AddOrUpdate")]
        public ToDo AddOrUpdate([FromBody] ToDo todo)
        {
            if(todo.Id <= 0)
            {
                //CREATE
                todo.Id = ItemService.Current.NextId;
                FakeDatabase.Items.Add(todo);
            } else
            {
                //UPDATE
                var itemToUpdate = FakeDatabase.Items.FirstOrDefault(i => i.Id == todo.Id);
                if(itemToUpdate != null) {
                    var index = FakeDatabase.Items.IndexOf(itemToUpdate);
                    FakeDatabase.Items.Remove(itemToUpdate);
                    FakeDatabase.Items.Insert(index, todo);
                } else
                {
                    //CREATE -- Fall-Back
                    FakeDatabase.Items.Add(todo);
                }
            }


            return todo;
        }


    }
}