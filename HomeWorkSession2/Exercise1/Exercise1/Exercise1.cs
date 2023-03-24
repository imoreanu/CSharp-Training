
// 1. Write a program that reads a number from the keyboard. Check whether that number is divisible by 7 and 11 or not.

class HomeWorkExercise1
{
    static void Main()
    {
        Console.Write("Please enter an integer: ");
        string input = Console.ReadLine();
        int inputValue;
        bool success = int.TryParse(input, out inputValue);
        
        while (!success)
        {
            Console.WriteLine("Invalid Input. Please try again...");
            Console.Write("Please enter a number: ");
            input = Console.ReadLine();
            success = int.TryParse(input, out inputValue);
        }
        
        Console.WriteLine($"Your input: {inputValue}");

        if (inputValue % 7 == 0)
        {
            Console.WriteLine("Congratz! " + inputValue + " is divisible by 7!");
        } 
        else if (inputValue % 11 == 0)
        {
            Console.WriteLine("Congratz! " + inputValue + " is divisible by 11!");
        }

        Console.Write("Press [enter] to close the program...");
        Console.ReadLine();
    }
}