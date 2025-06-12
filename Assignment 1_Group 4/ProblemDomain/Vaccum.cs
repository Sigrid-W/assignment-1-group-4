using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// Represents a class specific for vaccum attributes, which inherits from the Appliance class.
    /// Includes additional properties specific to vaccums such as grade and battery voltage.
    /// </summary>
    public class Vacuum : Appliance
    {
        string grade;
        double batteryVoltage;

        public Vacuum()
        {
        }

        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, double batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.grade = grade;
            this.batteryVoltage = batteryVoltage;
        }

        public string Grade { get => grade; set => grade = value; }
        public double BatteryVoltage { get => batteryVoltage; set => batteryVoltage = value; }

        public override string formatForFile()
        {
            return $"{base.formatForFile()};{Grade};{BatteryVoltage};";
        }

        public override string ToString()
        {
            string voltage;
            switch (batteryVoltage)
            {
                case 18:
                    voltage = "Low";
                    break;
                case 24:
                    voltage = "High";
                    break;
                default:
                    voltage = "Unknown";
                    break;
            }

            return $"Item Number: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Grade: {Grade}\n" +
                   $"Battery voltage: {voltage}\n";
        }
    }

}
