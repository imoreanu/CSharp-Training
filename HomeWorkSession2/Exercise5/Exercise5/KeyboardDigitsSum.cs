// 5. Find the sum of digits of a number read from the keyboard.

class KeyboardDigits
{
    public static void Main()
    {
        int number, result;

        Console.WriteLine("Please type a two digits Number or above: ");
        number = int.Parse(Console.ReadLine());
        result = SumOfDigit(number);

        Console.WriteLine("The Sum of the typed Digits is {0}", result);
        Console.ReadLine();
    }
    static int SumOfDigit(int n)
    {
        if (n == 0)
            return 0;

        return (n % 10 + SumOfDigit(n / 10));
    }
}