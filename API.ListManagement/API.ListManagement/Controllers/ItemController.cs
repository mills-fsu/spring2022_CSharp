using API.ListManagement.EC;
using Library.ListManagement.Standard.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.ListManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;

        public ItemController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IEnumerable<ItemDTO> Get()
        {
            List<ItemDTO> results = new List<ItemDTO>();
            results.AddRange(new ToDoEC().Get().ToList());
            results.AddRange(new AppointmentEC().Get());
            return results;
        }
    }
}
