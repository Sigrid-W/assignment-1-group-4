using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// Represents a class specific for refrigerator attributes, which inherits from the Appliance class.
    /// Includes additional properties specific to refrigerators such as sound number of doors, height and width.
    /// </summary>
    public class Refrigerator : Appliance
    {
        int numberOfDoors; 
        double height;
        double width;



        public Refrigerator()
        {
        }

        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, int numberOfDoors, double height, double width ) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.numberOfDoors = numberOfDoors;
            this.height = height;
            this.width = width;
        }

        public int NumberOfDoors { get => numberOfDoors; set => numberOfDoors = value; }
        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }

        public override string formatForFile()
        {
            return $"{base.formatForFile()};{NumberOfDoors};{Height};{Width};";
        }
    

        public override string ToString()
        {
            string doorType;
            switch (numberOfDoors)
            {
                case 2:
                    doorType = "Double Door";
                    break;
                case 3:
                    doorType = "Three Doors";
                    break;
                case 4:
                    doorType = "Four Doors";
                    break;
                default:
                    doorType = "Unknown";
                    break;
            }

            return $"Item Number: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Number of Doors: {doorType}\n" +
                   $"Height: {Height}\n" +
                   $"Width: {Width}\n";
        }
        

    }
}
