using ListManagement.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ListManagement.Standard.DTO
{
    public class ToDoDTO : ItemDTO
    {
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public ToDoDTO(Item i):base(i)
        {
            var t = i as ToDo;
            if(t != null)
            {
                Deadline = t.Deadline;
                IsCompleted = t.IsCompleted;
            }
        }

        public ToDoDTO()
        {

        }
    }
}
