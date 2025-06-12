using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// Represents a class specific for dishwashers attributes, which inherits from the Appliance class.
    /// Includes additional properties specific to dishwashers such as sound rating and feature.
    /// </summary>
    public class Dishwasher : Appliance
    {
        string soundRating;
        string feature;

        public string SoundRating { get => soundRating; set => soundRating = value; }
        public string Feature { get => feature; set => feature = value; }

        public Dishwasher() 
        { 
        }

        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price,string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.soundRating = soundRating;
            this.feature = feature;
        }

        public override string formatForFile()
        {
            return $"{base.formatForFile()};{Feature};{SoundRating};";
        }

        public override string ToString() 
        {
            string sound;
            switch (soundRating)
            {
                case "Qt":
                    sound = "Quietest";
                    break;
                case "Qr":
                    sound = "Quieter";
                    break;
                case "Qu":
                    sound = "Quiet";
                    break;
                case "M":
                    sound = "Moderate";
                    break;
                default:
                    sound = "Unknown";
                    break;
            }
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nFeature: {Feature}\nSound Rating: {sound}\n";
        }
    }
}
