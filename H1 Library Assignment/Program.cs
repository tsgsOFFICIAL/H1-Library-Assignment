using System;
using System.Collections.Generic;
using System.Globalization;

namespace H1_Library_Assignment
{
    class Program
    {
        static List<Book> books = new List<Book>(); //Initialise a new list of Books
        static List<Book> booksBorrowed = new List<Book>();
        static void Main(string[] args)
        {
            #region Welcome message
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
            System.Threading.Thread.Sleep(1500);
            #endregion

            #region Books
            books.Add(new Book("Harry Potter", "J.K. Rowling", DateTime.ParseExact("2011-03-21", "yyyy-MM-dd", CultureInfo.InvariantCulture)));
            books.Add(new Book("Kvinde kend din plads", "Kent Pedersen", DateTime.ParseExact("2020-08-27", "yyyy-MM-dd", CultureInfo.InvariantCulture)));
            books.Add(new Book("Minecraft handbook", "Mojang", DateTime.ParseExact("2012-05-17", "yyyy-MM-dd", CultureInfo.InvariantCulture)));
            books.Add(new Book("Ida & morgenbrødet, del 1", "Ida Svendsen", DateTime.ParseExact("2020-05-20", "yyyy-MM-dd", CultureInfo.InvariantCulture)));
            books.Add(new Book("Ida & morgenbrødet, del 2", "Ida Svendsen", DateTime.ParseExact("2020-06-28", "yyyy-MM-dd", CultureInfo.InvariantCulture)));
            books.Add(new Book("Sådan klipper du agurken", "Kent Pedersen", DateTime.ParseExact("1824-04-01", "yyyy-MM-dd", CultureInfo.InvariantCulture)));
            #endregion

            bool run = true;
            while (run)
            {
                MainMenu();
                switch (Console.ReadKey(false).KeyChar)
                {
                    case '1'://See available books
                        ShowBooks(false, true);
                        break;
                    case '2': //See all books
                        ShowBooks(true, true);
                        break;
                    case '3': //Borrow a book
                        BorrowABook();
                        break;
                    case '4': //Return a book
                        ReturnABook();
                        break;
                    case '5': //Add a new book, requires login
                        if (Login())
                        {
                            AddABook();
                        }
                        else
                        {
                            Console.WriteLine("You don't have access to add new books, maybe suggest your book idea to a librarian");
                        }
                        break;
                    case '6': //Remove a book, requires login
                        if (Login())
                        {
                            RemoveABook();
                        }
                        else
                        {
                            Console.WriteLine("You don't have access to add new books, maybe suggest your book idea to a librarian");
                        }
                        break;
                    case '7': //Exit
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("                 H1 Library System                ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("(1) See available books");
            Console.WriteLine("(2) See all books");
            Console.WriteLine("(3) Borrow a book");
            Console.WriteLine("(4) Return a book");
            Console.WriteLine("(5) Add a new book");
            Console.WriteLine("(6) Remove a new book");
            Console.WriteLine("(7) Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: "); //Prompt Line
        }

        /// <summary>
        /// Show books
        /// </summary>
        /// <param name="showAllBooks">Show all, or just available books</param>
        static void ShowBooks(bool showAllBooks, bool wait)
        {
            Console.Clear();
            if (showAllBooks)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("                   All our books                  ");
                Console.WriteLine("==================================================");
                Console.WriteLine();
                foreach (Book book in books)
                {
                    if (book.Available)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine($"({book.ID}) {book.Name} by {book.Author}, written in {book.ReleaseDate}");
                }
            }
            else
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("             All our available books              ");
                Console.WriteLine("==================================================");
                Console.WriteLine();
                foreach (Book book in books)
                {
                    if (book.Available)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"({book.ID}) {book.Name} by {book.Author}, written in {book.ReleaseDate}");
                    }
                }
            }
            if (wait)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Press any key to return");
                Console.ReadKey(true);
            }
        }


        static void BorrowABook()
        {
            Stack<uint> booksIWant = new Stack<uint>();

            ShowBooks(false, false);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("               Pick a book to borrow              ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("Enter all the ID's you wish to borrow, one at a time, and finish by pressing enter");

            bool run = true;
            while (run)
            {
                Console.Write("Book ID: ");
                try
                {
                    booksIWant.Push(Convert.ToUInt32(Console.ReadLine()));
                }
                catch (Exception)
                {
                    run = false;
                }
            }

            for (int i = booksIWant.Count; i > 0; i--)
            {
                foreach (Book book in books)
                {
                    if (booksIWant.Peek() == book.ID && book.Available)
                    {
                        booksIWant.Pop();
                        booksBorrowed.Add(book);
                        book.Available = false;
                        Console.WriteLine($"Successfully borrowed {book.Name} by {book.Author}, written in {book.ReleaseDate}");
                        break;
                    }
                }
            }
            System.Threading.Thread.Sleep(2000);
        }


        static void ReturnABook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            if (booksBorrowed.Count > 0)
            {
                foreach (Book book in booksBorrowed)
                {
                    Console.WriteLine($"({book.ID}) {book.Name} by {book.Author}, written in {book.ReleaseDate}");
                }

                Console.WriteLine();
                Console.WriteLine("==================================================");
                Console.WriteLine("               Pick a book to return              ");
                Console.WriteLine("==================================================");
                Console.WriteLine();
                Console.Write("Book ID: ");
                try
                {
                    uint input = Convert.ToUInt32(Console.ReadLine());
                    foreach (Book book in booksBorrowed)
                    {
                        if (book.ID == input)
                        {
                            booksBorrowed.Remove(book);
                            book.Available = true;
                            Console.WriteLine($"Successfully returned {book.Name} by {book.Author}, written in {book.ReleaseDate}");
                            System.Threading.Thread.Sleep(2000);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Thats not a valid book id!");
                    System.Threading.Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("You don't have any books to return");
                System.Threading.Thread.Sleep(500);
            }
        }


        static bool Login()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("                       LOGIN                      ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.Write("Password: ");

            ConsoleKeyInfo key;
            string passwordInput = null;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                key = Console.ReadKey(true);

                //Backspace should not work here, as its used to delete the last character
                if (key.Key != ConsoleKey.Backspace)
                {
                    passwordInput += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    Console.Write("\b \b"); //\b\b is a backspace keypress
                }
            }
            //Stops recieving keys once enter has been pressed
            while (key.Key != ConsoleKey.Enter);

            if (passwordInput.Substring(0, passwordInput.Length - 1).Equals("adminPassword"))
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect password!");
                System.Threading.Thread.Sleep(1500);
            }
            return false;
        }


        static void AddABook()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("                    Add a book                    ");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            Console.Write("Book name: ");
            string name = Console.ReadLine();

            Console.Write("Book author: ");
            string author = Console.ReadLine();

            Console.Write("Correct format is yyyy-MM-dd, example: 2000-04-12\nBook release date: ");
            try
            {
                DateTime releaseDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                books.Add(new Book(name, author, releaseDate));
                Console.WriteLine($"Successfully added {name}, by {author} written in {releaseDate}");
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect format");
                System.Threading.Thread.Sleep(2000);
                return;
            }
            System.Threading.Thread.Sleep(1500);
        }


        static void RemoveABook()
        {
            ShowBooks(true, false);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("                  Remove a book                   ");
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.Write("Book id: ");
            try
            {
                uint input = Convert.ToUInt32(Console.ReadLine());
                foreach (Book book in books)
                {
                    if (book.ID == input)
                    {
                        books.Remove(book);
                        Console.WriteLine($"Successfully removed {book.Name} by {book.Author}, written in {book.ReleaseDate}");
                        System.Threading.Thread.Sleep(2000);
                        return;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect format");
                System.Threading.Thread.Sleep(2000);
                return;
            }
            Console.WriteLine("Incorrect ID");
            System.Threading.Thread.Sleep(2000);
        }
    }
}
