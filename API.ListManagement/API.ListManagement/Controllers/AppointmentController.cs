using API.ListManagement.database;
using Microsoft.AspNetCore.Mvc;

namespace API.ListManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;

        public AppointmentController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public double Get()
        {
            return FakeDatabase.Doubles[0];
        }
    }
}
