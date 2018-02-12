
using System;

namespace CarManufactureApp.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public DateTime SoldDate { get; set; }

        public bool IsSold { get; set; }
    }
}