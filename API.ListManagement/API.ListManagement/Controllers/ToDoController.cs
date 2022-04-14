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
        public ToDoDTO AddOrUpdate([FromBody] ToDoDTO todo)
        {

            return new ToDoEC().AddOrUpdate(todo);
        }

        [HttpPost("Delete")]
        public ToDoDTO Delete([FromBody] DeleteItemDTO deleteItemDTO)
        {
            return new ToDoEC().Delete(deleteItemDTO.IdToDelete);
        }
    }
}