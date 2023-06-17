namespace _03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = " ";
            while ((input = Console.ReadLine()) != "End")
            {
                List<string> commands = input
                    .Split()
                    .ToList();

                int index = int.Parse(commands[1]);
                switch (commands[0])
                {
                    case "Shoot":
                        int power = int.Parse(commands[2]);
                        if (IndexIsValid(targets, index))
                        {
                            targets[index] -= power;
                            if (targets[index] <= 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        break;
                    case "Add":
                        int value = int.Parse(commands[2]);
                        if (IndexIsValid(targets, index))
                        {
                            targets.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    case "Strike":
                        int radius = int.Parse(commands[2]);
                        if (IndexIsValid(targets, index))
                        {
                            
                            if (index - radius < 0 || index + radius > targets.Count)
                            {
                                Console.WriteLine("Strike missed!");
                            }
                            else
                            {
                                targets.RemoveRange(index-radius, radius*2+1);
                                
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join("|", targets));
        }
        static bool IndexIsValid(List<int> targets, int index)
        {

            bool IndexIsValid = true;

            if (index < 0 || index > targets.Count - 1)
            {
                IndexIsValid = false;
                return IndexIsValid;
            }
            else if (index < 0 || index > targets.Count - 1)
            {
                IndexIsValid = false;
                return IndexIsValid;
            }
            return IndexIsValid;



        }
    }
}