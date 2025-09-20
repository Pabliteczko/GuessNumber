using System;

public class Program
{
    public static void Main()
    {

        Console.WriteLine("Welcome to the Number Guessing Game!");

        GameNumber();     
        

    }
    private static int SecretNumber(int scope)
    {
        Random random = new Random();
        int number = random.Next(1, scope + 1);
        return number;
    }
    private static void GameNumber()
    {
        do
        {
            int scope = Scope();
            int secretNumber = SecretNumber(scope);

            // Console.WriteLine($"(For testing purposes) The secret number is: {secretNumber} and scope is: {scope}");

            Console.WriteLine($"You must guess number between 1 to {scope}!");
            int attempts = 0;
            int guess;
            List<int> history = new List<int>();

            do
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out guess))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This is not a number!!");
                    Console.ResetColor();
                    continue;
                }
                history.Add(guess);
                attempts++;

                Console.ForegroundColor = ConsoleColor.Yellow;
                if (guess < secretNumber) Console.WriteLine("Too low! Try again.");
                else if (guess > secretNumber) Console.WriteLine("Too high! Try again.");
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Congratulations! You've guessed the number {secretNumber} in {attempts} attempts.");
                    Console.WriteLine("Your guesses: " + string.Join(", ", history));
                }
                Console.ResetColor();

            } while (guess != secretNumber);
            Console.WriteLine("Do you want to play again? (y/n)");
        } while (PlayAgain());
        
    }
    private static bool PlayAgain()
    {
        while (true)
        {
            string input = Console.ReadLine().ToLower();

            if (input == "y" || input == "yes")
            {
                Console.Clear();
                return true;
            }
            if (input == "n" || input == "no")
            {
                Console.WriteLine("Thank you for playing! Goodbye!");
                return false;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            Console.ResetColor();
        }

    }
    private static int Scope()
    {
        Console.WriteLine("What is the scope of the game?");
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int scope) || scope <= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input.");
                Console.ResetColor();
            }
            else
            {
                return scope;
            }
        }
    }
}