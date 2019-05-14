using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    var array = new int[] { 1, 2, 3, 4, 5 };

                    Console.WriteLine("Enter array's element index: ");
                    var userInput = Console.ReadLine();

                    var arrayElementIndex = int.Parse(userInput);

                    var arrayElement = array[arrayElementIndex];

                    Console.WriteLine($"array[{arrayElementIndex}]: {arrayElement}");
                }
                catch (IndexOutOfRangeException exception)
                {
                    Console.WriteLine("User entered non-existing array index!");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("User entered not number!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("I'm a finally block!");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
        }
    }
}