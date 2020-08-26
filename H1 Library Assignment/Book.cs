using System;

namespace H1_Library_Assignment
{
    public class Book
    {
        #region Fields
        private string name;
        private string author;
        private DateTime releaseDate;
        private bool available;

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
        /// This shows if the book is availabe to borrow at the library
        /// </summary>
        public bool Available
        {
            get
            {
                return available;
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
