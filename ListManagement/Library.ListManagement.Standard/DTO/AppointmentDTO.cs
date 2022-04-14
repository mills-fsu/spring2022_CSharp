using ListManagement.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ListManagement.Standard.DTO
{
    public class AppointmentDTO: ItemDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<string> Attendees { get; set; }

        public AppointmentDTO(Item i) : base(i)
        {
            var a = i as Appointment;
            if(a != null)
            {
                Start = a.Start;
                End = a.End;

                Attendees = a.Attendees;
            }
        }

        public AppointmentDTO()
        {

        }
    }
}
