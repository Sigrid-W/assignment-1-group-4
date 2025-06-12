using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_1
{
    /// <summary>
    /// Provides functionality for managing appliance data,
    /// contains functions such as searching, filtering, purchasing and displaying required appliance data,
    /// saves appliance data to a file after operation.
    /// </summary>
    public class ApplianceManage
    {
        static List<Appliance> appliances = new List<Appliance>();
        static void Main(string[] args)
        {
            LoadApplianceListFromFile();
            int choice = 0;
            while (choice != 5) 
            { 
                Console.WriteLine("\nWelcome to Modern Appliances!");
                Console.WriteLine("How May We Assist You?");
                Console.WriteLine("1 – Check out appliance");
                Console.WriteLine("2 – Find appliances by brand");
                Console.WriteLine("3 – Display appliances by type");
                Console.WriteLine("4 – Produce random appliance list");
                Console.WriteLine("5 – Save & exit\n");
                Console.WriteLine("Enter option: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice) 
                {
                    case 1:
                        PurchaseAppliance();
                        break;
                    case 2:
                        FindByBrand();
                        break;
                    case 3:
                        DisplayByType();
                        break;
                    case 4:
                        ProduceRandomList();
                        break;
                    case 5:
                        SaveListToFile();
                        Console.WriteLine("Changes saved");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please enter number 1-5\n");
                        break;

                }
            }
            



            Console.ReadLine();
        }

        public static void LoadApplianceListFromFile()
        {
            string path = "..\\..\\Res\\appliances.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                string itemString = fields[0];
                long itemNumber = long.Parse(itemString);
                string brand = fields[1];
                int quantity = int.Parse(fields[2]);
                double wattage = double.Parse(fields[3]);
                string color = fields[4];
                double price = double.Parse(fields[5]);
                char firstChar = itemString[0];
                switch (firstChar)
                {
                    case '1':
                        {
                            int numberOfDoors = int.Parse(fields[6]);
                            double height = double.Parse(fields[7]);
                            double width = double.Parse(fields[8]);
                            appliances.Add(new Refrigerator(itemNumber, brand, quantity, wattage, color, price, numberOfDoors, height, width));
                            break;
                        }
                    case '2':
                        {
                            string grade = fields[6];
                            double batteryVoltage = double.Parse(fields[7]);
                            appliances.Add(new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, batteryVoltage));
                            break;
                        }
                    case '3':
                        {
                            double capacity = double.Parse(fields[6]);
                            string roomType = fields[7];
                            appliances.Add(new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomType));
                            break;
                        }
                    case '4':
                        {
                            string feature = fields[6];
                            string soundRating = fields[7];
                            appliances.Add(new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating));
                            break;
                        }
                    case '5':
                        {
                            string feature = fields[6];
                            string soundRating = fields[7];
                            appliances.Add(new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating));
                            break;
                        }
                }

            }



        }

        public static void PurchaseAppliance() 
        {
            Console.WriteLine("\nEnter item number of an appliance: ");
            long num = long.Parse(Console.ReadLine());
            foreach (Appliance temp in appliances)
            {
                if (num == temp.ItemNumber)
                {
                    temp.checkout();
                    return;
                }
                
            }
            Console.WriteLine("No appliances found with that item number.");
        }

        public static void FindByBrand() 
        { 
            Console.WriteLine("\nEnter brand to search for: ");
            string b1 = Console.ReadLine().ToLower();
            Console.WriteLine("\nMatching Appliances: \n");
            foreach (Appliance temp in appliances)
            {
                if (b1 == temp.Brand.ToLower())
                {
                    Console.WriteLine(temp);
                }
            }
        }

        public static void DisplayByType()
        {
            Console.WriteLine("\nAppliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers\n");
            Console.WriteLine("Enter type of appliance: ");
            int typeChoice = int.Parse(Console.ReadLine());
            switch (typeChoice)
            {
                case 1:
                    Console.WriteLine("\nEnter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                    int c1 = int.Parse(Console.ReadLine());
                    if (c1 > 4 || c1 < 2) 
                    {
                        Console.WriteLine("\nInvalid input, the input should be 2, 3, or 4.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nMatching refrigerators:\n");
                        foreach (Appliance temp in appliances)
                        {
                            if (temp is Refrigerator)
                            {
                                Refrigerator refrigerators = (Refrigerator)temp;
                                if (refrigerators.NumberOfDoors == c1)
                                {
                                    Console.WriteLine(temp);
                                }
                            }
                            
                        }

                    }  
                    break;
                case 2:
                    Console.WriteLine("\nEnter battery voltage value. 18 V (low) or 24 V (high)");
                    int c2 = int.Parse(Console.ReadLine());
                    if (c2 != 18 && c2 != 24)
                    {
                        Console.WriteLine("\nInvalid input, the input should be 18 or 24.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nMatching vaccums:\n");
                        foreach (Appliance temp in appliances)
                        {
                            if (temp is Vacuum)
                            {
                                Vacuum vaccums = (Vacuum)temp;
                                if (vaccums.BatteryVoltage == c2)
                                {
                                    Console.WriteLine(temp);
                                }
                            }
                            
                        }

                    }
                    break;
                case 3:
                    Console.WriteLine("\nRoom where the microwave will be installed: K (kitchen) or W (work site)");
                    string c3 = Console.ReadLine().ToUpper();
                    if (c3 != "W" && c3 != "K")
                    {
                        Console.WriteLine("\nInvalid input, the input should be W or K.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nMatching microwaves:\n");
                        foreach (Appliance temp in appliances)
                        {
                            if (temp is Microwave)
                            {
                                Microwave microwaves = (Microwave)temp;
                                if (microwaves.RoomType == c3)
                                {
                                    Console.WriteLine(temp);
                                }
                            }

                        }

                    }
                    break;
                case 4:
                    Console.WriteLine("\nEnter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                    string c4 = Console.ReadLine();
                    if (c4 != "Qt" && c4 != "Qr" && c4 != "Qu" && c4 != "M")
                    {
                        Console.WriteLine("\nInvalid input, the input should be Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate).\n");
                    }
                    else
                    {
                        Console.WriteLine("\nMatching dishwashers:\n");
                        foreach (Appliance temp in appliances)
                        {
                            if (temp is Dishwasher)
                            {
                                Dishwasher dishwashers = (Dishwasher)temp;
                                if (dishwashers.SoundRating == c4)
                                {
                                    Console.WriteLine(temp);
                                }
                            }

                        }

                    }
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, please enter number 1-4");
                    break;
            }
        }

        public static void ProduceRandomList() 
        { 
            Console.WriteLine("\nEnter number of appliances");
            int randomNum = int.Parse(Console.ReadLine());
            if (randomNum > appliances.Count) 
            {
                Console.WriteLine("\nThe input number is too large, please enter an smaller number\n");
            }
            else if (randomNum <= 0)
            {
                Console.WriteLine("\nInvalid input. The input should be more than 0\n");
            }
            else
            {
                var rand = new Random();
                int ranNum;
                List<int> randomAppliance = new List<int>();
                for (int i = 0; i < randomNum; i++) 
                {
                    ranNum = rand.Next(0, appliances.Count);
                    if (!randomAppliance.Contains(ranNum)) 
                    { 
                        randomAppliance.Add(ranNum); 
                    }
                    else 
                    {
                        i -= 1;
                    }
                    
                }
                foreach(int temp in randomAppliance) 
                {
                    Console.WriteLine(appliances[temp]);
                }


            }
        }

        public static void SaveListToFile() 
        {
            List<string> appliancesToBeAdd = new List<string>();
            string path = "..\\..\\Res\\appliances.txt";
            foreach (Appliance temp in appliances) 
            {
                if (temp is Refrigerator) 
                {
                    Refrigerator refrigerator = (Refrigerator)temp;
                    appliancesToBeAdd.Add(refrigerator.formatForFile());
                }
                else if (temp is Vacuum)
                {
                    Vacuum vacuum = (Vacuum)temp;
                    appliancesToBeAdd.Add(vacuum.formatForFile());
                }
                else if (temp is Microwave)
                {
                    Microwave microwave = (Microwave)temp;
                    appliancesToBeAdd.Add(microwave.formatForFile());
                }
                else
                {
                    Dishwasher dishwasher = (Dishwasher)temp;
                    appliancesToBeAdd.Add(dishwasher.formatForFile());
                }
            }
            File.AppendAllLines(path, appliancesToBeAdd);
        }
               
    }
        

    
}
 