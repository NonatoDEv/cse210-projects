using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        int attempts = 0;
        while (guess != magicNumber)
        {
            Console.WriteLine("What is your magic number?");
            guess = int.Parse(Console.ReadLine());
            attempts++;
            if (attempts <= 7)
                if(magicNumber > guess)
                {
                    Console.WriteLine("higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed the magic number! and it only took you {attempts} attempts!");
                }
            else
            {
                Console.WriteLine("Sorry, you have used all 7 attempts. Better luck next time!");
                Console.WriteLine($"The magic number was: {magicNumber}");
                break;
            }
        }
    }
}