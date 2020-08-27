using System;
using System.Collections.Generic;

namespace H1_Library_Assignment
{
    public class Book
    {
        #region Fields
        private static uint idCounter;
        private string name;
        private string author;
        private bool available;
        private uint id;
        private DateTime releaseDate;

        #endregion

        #region Properties
        /// <summary>
        /// This is the name of the book
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// This is the name of the author
        /// </summary>
        public string Author
        {
            get
            {
                return author;
            }
        }

        /// <summary>
        /// This shows if the book is availabe to borrow at the library
        /// </summary>
        public bool Available
        {
            get
            {
                return available;
            }
            set
            {
                available = value;
            }
        }

        /// <summary>
        /// This is the ID of the book, each book has their own individual id
        /// </summary>
        public uint ID
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// This is the release date of the book
        /// </summary>
        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }
        }

        /// <summary>
        /// This is the total amount of books
        /// </summary>
        public uint Count
        {
            get
            {
                return idCounter;
            }
        }
        #endregion

        #region Cnostructor
        /// <summary>
        /// Generate a new book with a specific set of properties by default
        /// </summary>
        /// <param name="name">This is the name of the book</param>
        /// <param name="author">This is the name of the author</param>
        /// <param name="releaseDate">This is the releasedate of the book</param>
        public Book(string name, string author, DateTime releaseDate)
        {
            idCounter++;
            id = idCounter;
            this.name = name;
            this.author = author;
            this.releaseDate = releaseDate;
            available = true;
        }
        #endregion

        #region Methods

        #endregion
    }
}
