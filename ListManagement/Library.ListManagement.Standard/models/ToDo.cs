using Library.ListManagement.Standard.DTO;
using ListManagement.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManagement.models
{
    public class ToDo: Item
    {
        public ToDo()
        {
        }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{Name} {Priority} {Description} Completed: {IsCompleted}";
        }


        public ToDo(ToDoDTO dto)
        {
            Name = dto.Name;
            Description = dto.Description;
            Id = dto.Id;
            Deadline = dto.Deadline;
            IsCompleted = dto.IsCompleted;
        }
    }
}
