// 2.Find an optimal solution to the code that converts a decimal to binary

public class Problem3
{
    static void Main(string[] args)
    {

        Console.Write("Please give a positive number: ");

        int number = int.Parse(Console.ReadLine());
        int temp;
        int[] numberArray = new int[10];

        for (temp = 0; number > 0; temp++)
        {
            numberArray[temp] = number % 2;
            number = number / 2;
        }

        Console.Write("Binary Represenation of the given Number is: ");
        for (temp = temp - 1; temp >= 0; temp--)
        {
            Console.Write(numberArray[temp]);

        }
        Console.ReadKey();
    }
}