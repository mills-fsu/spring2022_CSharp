using ListManagement.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ListManagement.Standard.DTO
{
    public class ItemDTO
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }

        }
        public string Description { get; set; }

        public int Id { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {Description}";
        }

        public ItemDTO(Item i)
        {
            Name = i.Name;
            Description = i.Description;
            Id = i.Id;
        }
    }
}
