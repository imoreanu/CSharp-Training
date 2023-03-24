
// 2. Check whether a given year is leap year or not. Added validation for year format as well
class IsLeapYear
{
    static void Main()
    {
        int minValidYear = 1000;
        int maxValidYear = 3000;
        int inputValue;
        string prompt = $"Please enter an year ({minValidYear}-{maxValidYear}): ";
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out inputValue) || inputValue < minValidYear || maxValidYear < inputValue)
        {
            Console.WriteLine("Invalid year format. Please try again...");
            Console.Write(prompt);
        }
        Console.WriteLine($"You added the year: {inputValue}");

        if (inputValue % 4 == 0 && inputValue % 100 != 0 || inputValue % 400 == 0)
        {
            Console.WriteLine($"The year: {inputValue} is a leap year!");
        }
        else
        {
            Console.WriteLine($"The year: {inputValue} is not a leap year...");
        }

        Console.Write("Press [Enter] key to continue...");
        Console.ReadLine();
    }
}