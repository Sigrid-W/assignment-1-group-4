using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// Represents a base class with general attributes for appliances such as item number, brand, quantity, wattage, color, and price.
    /// This class provides methods for checking appliances availability, performing checkout operations, and formatting data for file storage.
    /// </summary>
    public class Appliance
    {
        long itemNumber;
        string brand;
        int quantity;
        double wattage;
        string color;
        double price;


        public long ItemNumber { get => itemNumber; set => itemNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Wattage { get => wattage; set => wattage = value; }
        public string Color { get => color; set => color = value; }
        public double Price { get => price; set => price = value; }

        public Appliance()
        {
        }

        public Appliance(long itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            this.itemNumber = itemNumber;
            this.brand = brand;
            this.quantity = quantity;
            this.wattage = wattage;
            this.color = color;
            this.price = price;
        }

        public bool isAvailable() 
        {
            bool available;
            if (quantity > 0)
            {
                available = true;
            }
            else
            {
                available = false;
            }
            return available;
        }

        public void checkout() 
        {
            if (isAvailable())
            {
                quantity -= 1;
                Console.WriteLine($"Appliance {itemNumber} has been checked out\n");
            }
            else 
            {
                Console.WriteLine($"The appliance is not available to be checked out\n");
            }
        }

        public virtual string formatForFile()
        {
            return $"{ItemNumber};{Brand};{Quantity};{Wattage};{Color};{Price}";
        }


        public override string ToString()
        {
            //return base.ToString();
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\n";  
        }
    }
}
