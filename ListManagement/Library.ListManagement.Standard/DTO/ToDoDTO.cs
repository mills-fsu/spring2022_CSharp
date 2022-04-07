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

        }

        public ToDoDTO()
        {

        }
    }
}
