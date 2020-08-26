using System;
using System.Collections.Generic;
using System.Globalization;

namespace H1_Library_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] msg = new string[] 
            {
                @" /$$$$$$$   /$$$$$$   /$$$$$$  /$$   /$$  /$$$$$$  /$$          /$$$  ",
                @"| $$__  $$ /$$__  $$ /$$__  $$| $$  /$$/ /$$__  $$| $$         |_  $$ ",
                @"| $$  \ $$| $$  \ $$| $$  \ $$| $$ /$$/ | $$  \__/| $$       /$$ \  $$",
                @"| $$$$$$$ | $$  | $$| $$  | $$| $$$$$/  |  $$$$$$ | $$      |__/  | $$",
                @"| $$__  $$| $$  | $$| $$  | $$| $$  $$   \____  $$|__/            | $$",
                @"| $$  \ $$| $$  | $$| $$  | $$| $$\  $$  /$$  \ $$           /$$  /$$/",
                @"| $$$$$$$/|  $$$$$$/|  $$$$$$/| $$ \  $$|  $$$$$$/ /$$      |__//$$$/ ",
                @"|_______/  \______/  \______/ |__/  \__/ \______/ |__/         |___/  "
            };

            foreach (string line in msg)
            {
                Console.WriteLine(line);
            }

            List<Book> books = new List<Book>();
            books.Add(new Book("Harry Potter", "J.K. Rowling", DateTime.ParseExact("2011-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture)));

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
