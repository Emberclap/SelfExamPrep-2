using System.Data;

namespace Problem_2___Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = "";
            int counter = 0;
            while ((command = Console.ReadLine()) != "End")
            {
                int index = int.Parse(command);
                
                if (index >= 0 && index < targets.Count)
                {
                    int temp = targets[index];
                    targets[index] = -1;
                    counter++;
                    for (int i = 0; i < targets.Count; i++)
                {
                    if (targets[i] > temp && targets[i] > 0)
                    {
                        targets[i] -= temp;
                    }
                    else if (targets[i] <= temp && targets[i] > 0)
                    {
                        targets[i] += temp;
                    }
                }
                
                }
            }
            Console.WriteLine($"Shot targets: {counter} -> {string.Join(" ", targets)}");
        }
    }
}