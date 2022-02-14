using ListManagement.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManagement.models
{
    public class Item: IItem
    {
        private string? _name;
        public string? Name { 
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        
        }
        public string? Description { get; set; }

        public int Id { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {Description}";
        }
    }
}
