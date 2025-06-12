using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// Represents a class specific for microwave attributes, which inherits from the Appliance class.
    /// Includes additional properties specific to microwaves such as capacity and room type.
    /// </summary>
    public class Microwave : Appliance
    {
        double capacity;
        string roomType;


        public double Capacity { get => capacity; set => capacity = value; }
        public string RoomType { get => roomType; set => roomType = value; }

        public Microwave()
        {
        }

        public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, double price, double capacity, string roomType) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.capacity = capacity;
            this.roomType = roomType;
        }

        public override string formatForFile()
        {
            return $"{base.formatForFile()};{Capacity};{RoomType};";
        }

        public override string ToString()
        {
            string room;
            switch (RoomType)
            {
                case "K":
                    room = "Kitchen";
                    break;
                case "W":
                    room = "Work Site";
                    break;
                default:
                    room = "Unknown";
                    break;
            }

            return $"Item Number: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Capacity: {Capacity}\n" +
                   $"Room Type: {room}\n";
        }
    }

}
