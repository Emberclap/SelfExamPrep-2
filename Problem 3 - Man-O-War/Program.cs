using System.Runtime;

namespace Problem_3___Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShipStatus = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            List<int>warshipStatus = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();
            int maxHealth = int.Parse(Console.ReadLine());

            string input = " ";
            while ((input = Console.ReadLine()) != "Retire")
            {

                List<string> commands = input
                    .Split()
                    .ToList();
                
                
                
                switch (commands[0])
                {
                    case "Fire": 
                        int index = int.Parse(commands[1]);
                        if (IndexIsValid(warshipStatus,index))
                        {
                            warshipStatus[index] -= int.Parse(commands[2]);
                            if (warshipStatus[index] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;
                    case "Defend":
                        index = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        if (IndexIsValid(pirateShipStatus, index) && endIndex < pirateShipStatus.Count && endIndex >= 0)
                        {
                            for (int i = index; i <= endIndex; i++)
                            {
                                pirateShipStatus[i] -= int.Parse(commands[3]);
                                if (pirateShipStatus[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        index = int.Parse(commands[1]);
                        if (IndexIsValid(pirateShipStatus, index))
                        {
                            pirateShipStatus[index] += int.Parse(commands[2]);
                            if (pirateShipStatus[index] > maxHealth)
                            {
                                pirateShipStatus[index] = maxHealth;
                            }
                        }
                        break;
                    case "Status":
                        int needRepairCounter = 0;
                        for (int i = 0; i < pirateShipStatus.Count-1; i++)
                        {
                            if (pirateShipStatus[i] <= maxHealth * 0.20)
                            {
                                needRepairCounter++;
                            }
                        }
                        Console.WriteLine($"{needRepairCounter} sections need repair.");
                        break;
                }
            }
            if (pirateShipStatus.Count > 0 && warshipStatus.Count > 0)
            {
                Console.WriteLine($"Pirate ship status: {pirateShipStatus.Sum()}");
                Console.WriteLine($"Warship status: {warshipStatus.Sum()}");
            }
        }
        static bool IndexIsValid(List<int> shipStatus, int index)
        {
            
            bool IndexIsValid = true;

            if (index < 0 || index > shipStatus.Count-1)
            {
                IndexIsValid = false;
                return IndexIsValid;
            }
            else if (index < 0 || index > shipStatus.Count - 1)
            {
                IndexIsValid = false;
                return IndexIsValid;
            }
            return IndexIsValid;
            
            
            
        }
 
    }
}