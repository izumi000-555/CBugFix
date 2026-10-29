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
    }
}
