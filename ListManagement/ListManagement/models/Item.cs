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
        public string? Name { get; set; }
        public string? Description { get; set; }

        internal string? test;
        public override string ToString()
        {
            Name = null;
            return $"{Name} {Description}";
        }
    }
}
