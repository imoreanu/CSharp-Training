// 1.Convert Binary 10011010 to Decimal number system

class BinaryToDecimal
{
    static void Main(string[] args)
    {
        int binaryNumber = 10011010;
        int decimalValue = 0;
     
        int base1 = 1;

        while (binaryNumber > 0)
        {
            int reminder = binaryNumber % 10;
            binaryNumber = binaryNumber / 10;
            decimalValue += reminder * base1;
            base1 = base1 * 2;
        }
        Console.Write($"The Decimal Value of 10011010 is: {decimalValue} ");
        Console.ReadKey();
    }
}