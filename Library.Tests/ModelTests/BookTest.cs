using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Library.Models;
using Library;
using MySql.Data.MySqlClient;

namespace Library.Tests
{
  [TestClass]
  public class BookTests : IDisposable
  {
    public BookTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=library;";
    }

    public void Dispose()
    {
      City.DeleteAll();
      Flight.DeleteAll();
    }

    [TestMethod]
    public void Save_SavesBookToDatabase_BookList()
    {
      Book testBook = new Book("Nostromo", "Joseph Conrad");
      testBook.Save();

      List<Book> testResult = Book.GetAllBooks();
      List<Book> allBooks = new List<Books>{testBook};

      CollectionAssert.AreEqual(allBooks, testResult);
    }
  }
}
