// 3. By listing the first six prime numbers: 2, 3, 5, 7, 11 and 13, we can see that the 6th prime is 13. What is the 47th prime number?

using System.Collections;

class FirstSixPrimeNumbers
{
    static void Main()
    {  
        bool isPrime = true;
        int i, j;
        //Calculate and display the first six Prime numbers  
        Console.WriteLine("First six Prime Numbers are : ");
        for (i = 2; i <= 16; i++)
        {
            for (j = 2; j <= 16; j++)
            {
                if (i != j && i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine(i);
            }
            isPrime = true;
        }

        DisplayNthPrimeNumber();

        Console.WriteLine("47th Prime Number is " + primes[46]);

        Console.ReadKey();
    }

    static int k = 300;

    // To store all prime numbers
    static ArrayList primes = new ArrayList();

    // Function to generate N'th Prime Number using "Sieve of Eratosthenes"
    static void DisplayNthPrimeNumber()
    {
        bool[] isPrime = new bool[k];

        for (int i = 0; i < k; i++)
            isPrime[i] = true;

        for (int p = 2; p * p < k; p++)
        {
            if (isPrime[p] == true)
            {
                for (int i = p * p; i < k; i += p)
                    isPrime[i] = false;
            }
        }

        for (int p = 2; p < k; p++)
            if (isPrime[p] == true)
                primes.Add(p);
    }

}

