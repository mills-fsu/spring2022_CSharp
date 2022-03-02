using API.ListManagement.database;
using ListManagement.models;
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
        public IEnumerable<Item> Get()
        {
            return FakeDatabase.Items;
        }

        [HttpGet("GetAnInt/{index}")]
        public ActionResult GetAnInt(int index)
        {
            if(index > FakeDatabase.Ints.Count)
            {
                return BadRequest();
            }
            return Ok(FakeDatabase.Ints[index]);
        }

        [HttpGet("AddNext")]
        public int AddNext()
        {
            var max = FakeDatabase.Ints.Max() + 1;
            FakeDatabase.Ints.Add(max);
            return max;
        }

        [HttpPost("AddNumber")]
        public int AddNumber([FromBody] int num)
        {
            FakeDatabase.Ints.Add(num);
            return num;
        }
    }
}