using System;

namespace Assignment_1_Part1
{
    public static class InputHandler
    {
        public static void GetUserName(out string userName)
        {
            userName = "";
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter your name: ");
                    Console.ResetColor();

                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("Name cannot be empty.");
                    }

                    if (!input.All(char.IsLetter))
                    {
                        throw new ArgumentException("Name must contain only letters.");
                    }

                    userName = FormatName(input);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Welcome " + userName);
                    Console.ResetColor();

                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input: " + ex.Message);
                    Console.ResetColor();
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unexpected error. Try again.");
                    Console.ResetColor();
                }
            }
        }

        private static string FormatName(string name)
        {
            try
            {
                return char.ToUpper(name[0]) + name.Substring(1).ToLower();
            }
            catch
            {
                return "User";
            }
        }
    }
}