using Library.ListManagement.Standard.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManagement.models
{
    public class Appointment : Item
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<string> Attendees { get; set; }

    public Appointment()
        {
            Attendees = new List<string>();
        }

        public override string ToString()
        {
            return $"{Name} {Description} From {Start} to {End}";
        }
        public Appointment(AppointmentDTO dto)
        { 
            Name = dto.Name;
            Description = dto.Description;
            Id = dto.Id;
            Start = dto.Start;
            End = dto.End;
            Attendees = dto.Attendees;
        }
    }
}
