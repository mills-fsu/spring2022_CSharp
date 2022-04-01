using Library.ListManagement.Standard.DTO;
using ListManagement.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.ListManagement.ViewModels
{
    public class ItemViewModel
    {
        //public Visibility IsCompleteVisibility
        //{
        //    get
        //    {
        //        return IsTodo ? Visibility.Visible : Visibility.Collapsed;
        //    }
        //}
        public string Name
        {
            get
            {
                return BoundItem?.Name ?? string.Empty;
            }
        }

        public string Description
        {
            get
            {
                return IsTodo
                    ? BoundToDo?.Description ?? string.Empty
                    : BoundAppointment?.Description ?? string.Empty;
            }
        }

        public ItemDTO BoundItem
        {
            get
            {
                if (IsTodo)
                {
                    return BoundToDo;
                }

                return BoundAppointment;
            }
        }

        public int Id
        {
            get
            {
                return BoundItem.Id;
            }
        }
        public bool IsCompleted
        {
            get
            {
                if (IsTodo)
                {
                    return BoundToDo.IsCompleted;
                }

                return false;
            }

            set
            {
                if (IsTodo)
                {
                    BoundToDo.IsCompleted = value;
                }
            }
        }

        public bool IsTodo
        {
            get
            {
                return BoundToDo != null;
            }
        }

        public ToDoDTO BoundToDo { get; set; }

        public AppointmentDTO BoundAppointment { get; set; }

        public ItemViewModel(ItemDTO item)
        {
            if (item is AppointmentDTO)
            {
                BoundAppointment = item as AppointmentDTO;
                IsCompleted = false;
                BoundToDo = null;
            }
            else if(item is ToDoDTO)
            {
                BoundToDo = item as ToDoDTO;
                BoundAppointment = null;
                IsCompleted = (item as ToDoDTO).IsCompleted;
            } else
            {
                BoundToDo = item as ToDoDTO;
                BoundAppointment = null;

            }
        }
    }
}
