using API.ListManagement.database;
using Library.ListManagement.Standard.DTO;

namespace API.ListManagement.EC
{
    public class AppointmentEC
    {
        public IEnumerable<AppointmentDTO> Get()
        {
            return FakeDatabase.Appointments.Select(t => new AppointmentDTO(t));
        }
    }
}
