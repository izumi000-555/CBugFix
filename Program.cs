using System;

class Program
{
    static void Main(string[] args)
    {
        /*//problem1
        // Display FizzBuzz from 1 to 100.
        for(int i = 1; i <= 100; i++){
            if(i % 3 == 0 && i % 5 == 0){
                Console.WriteLine("FizzBuzz");
            }
            else if(i % 3 == 0){
                Console.WriteLine("Fizz");
            }
            else if(i % 5 == 0){
                Console.WriteLine("Buzz");
            }
            else{
                Console.WriteLine(i);
            }
        }
        */


        //problem2
        // Add the numbers from 1 to 10.
        int sum = 0;

        for(int i = 1; i <= 10; i++){
            sum += i;
        }

        Console.WriteLine($"The sum is {sum}");

        // Problem 4
        // =====================================================
        //  Bug hunt: Study tracker
        // =====================================================
        // This program prints a study report for one week.
        // It has 3 bugs:
        //   - one bug makes the program crash
        //   - one bug gives a wrong result
        //   - one bug makes the program never end
        //
        // Find each bug with the debugger, not by guessing:
        //   1. Click left of a line number to set a breakpoint (red dot).
        //   2. Press F5 to start debugging. The program stops at the breakpoint.
        //   3. Press F10 to run one line, F11 to go inside a method.
        //   4. Look at the variables in the VARIABLES panel on the left,
        //      or hover over a variable with the mouse.
        //   If the program never ends: press Shift+F5 to stop debugging.
        //
        // For each bug, write in your daily report:
        //   - What happened?
        //   - On which line was the problem?
        //   - What was wrong, and how did you fix it?
        //
        // When everything works, the output is:
        //   === Study report ===
        //   Mon: 30 min
        //   Tue: 45 min
        //   Wed: 0 min
        //   Thu: 60 min
        //   Fri: 25 min
        //   Total: 160 minutes
        //   Best day: Thu
        //   Weeks to reach 1000 minutes: 7

        string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri" };
        int[] minutes = { 30, 45, 0, 60, 25 };

        Console.WriteLine("=== Study report ===");
        PrintDays(days, minutes);

        int total = SumMinutes(minutes);
        Console.WriteLine($"Total: {total} minutes");

        int best = BestDayIndex(minutes);
        Console.WriteLine($"Best day: {days[best]}");

        int goal = 1000;
        int weeks = WeeksToGoal(goal, total);
        Console.WriteLine($"Weeks to reach {goal} minutes: {weeks}");


        // Prints one line per day, for example "Mon: 30 min".
        static void PrintDays(string[] days, int[] minutes)
        {
            for (int i = 0; i < days.Length; i++)
            {
                Console.WriteLine($"{days[i]}: {minutes[i]} min");
            }
        }

        // Adds up the minutes of all days.
        static int SumMinutes(int[] minutes)
        {
            int sum = 0;
            for (int i = 1; i < minutes.Length; i++)
            {
                sum += minutes[i];
            }
            return sum;
        }

        // Returns the position of the day with the most minutes.
        static int BestDayIndex(int[] minutes)
        {
            int bestIndex = 0;
            for (int i = 0; i < minutes.Length; i++)
            {
                if (minutes[i] > minutes[bestIndex])
                {
                    bestIndex = i;
                }
            }
            return bestIndex;
        }

        // How many weeks of studying like this week are needed to reach the goal?
        static int WeeksToGoal(int goal, int minutesPerWeek)
        {
            int weeks = 0;
            int studied = 0;
            while (studied < goal)
            {
                weeks++;
                studied += minutesPerWeek;
            }
            return weeks;
        }

        //problem4
        // Move each to-do menu option into its own method.
        List<string> tasks = new List<string>();
        List<bool> done = new List<bool>();
        string choice = string.Empty;

        do
        {
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. List tasks");
            Console.WriteLine("3. Mark task as done");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask(tasks, done);
                    break;

                case "2":
                    ListTasks(tasks, done);
                    break;

                case "3":
                    CompleteTask(tasks, done);
                    break;

                case "4":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Please enter 1, 2, 3, or 4.");
                    break;
            }

        } while (choice != "4");
    }

    static void AddTask(List<string> tasks, List<bool> done)
    {
        Console.Write("Please enter the task name: ");
        string task = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("Task name cannot be empty.");
        }
        else
        {
            tasks.Add(task.Trim());
            done.Add(false);
            Console.WriteLine("Task added.");
        }
    }

    static void ListTasks(List<string> tasks, List<bool> done)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks yet.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (done[i] == true)
                {
                    Console.WriteLine($"{i + 1}. [x] {tasks[i]}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. [ ] {tasks[i]}");
                }
            }
        }
    }

    static void CompleteTask(List<string> tasks, List<bool> done)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks yet.");
        }
        else
        {
            Console.Write("Please enter the task number: ");
            string input = Console.ReadLine();
            int number;

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Please enter a valid number.");
            }
            else if (number < 1 || number > tasks.Count)
            {
                Console.WriteLine("Task number does not exist.");
            }
            else
            {
                done[number - 1] = true;
                Console.WriteLine("Task marked as done.");
            }
        }

        
        //problem5
        // Randomize animals and assign them to school groups.
        string[] pettingZoo =
        {
            "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
            "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
            "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises"
        };

        PlanSchoolVisit("School A");
        PlanSchoolVisit("School B", 3);
        PlanSchoolVisit("School C", 2);

        void PlanSchoolVisit(string schoolName, int groups = 6)
        {
            RandomizeAnimals();
            string[,] group = AssignGroup(groups);
            Console.WriteLine(schoolName);
            PrintGroup(group);
        }

        void RandomizeAnimals()
        {
            Random random = new Random();

            for (int i = 0; i < pettingZoo.Length; i++)
            {
                int r = random.Next(i, pettingZoo.Length);

                string temp = pettingZoo[r];
                pettingZoo[r] = pettingZoo[i];
                pettingZoo[i] = temp;
            }
        }

        string[,] AssignGroup(int groups = 6)
        {
            string[,] result = new string[groups, pettingZoo.Length / groups];
            int start = 0;

            for (int i = 0; i < groups; i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = pettingZoo[start++];
                }
            }

            return result;
        }

        void PrintGroup(string[,] group)
        {
            for (int i = 0; i < group.GetLength(0); i++)
            {
                Console.Write($"Group {i + 1}: ");

                for (int j = 0; j < group.GetLength(1); j++)
                {
                    Console.Write($"{group[i, j]}  ");
                }

                Console.WriteLine();
            }
        }


        
    }
}


