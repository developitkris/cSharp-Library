using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Library.Models;
using Library;
using MySql.Data.MySqlClient;

namespace Library.Tests
{
  [TestClass]
  public class AuthorTests : IDisposable
  {
    public AuthorTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=library;";
    }

    public void Dispose()
    {
      City.DeleteAll();
      Flight.DeleteAll();
    }

    [TestMethod]
    public void Save_SavesAuthorToDatabase_AuthorList()
    {
      Author testAuthor = new Author("Nostromo", "Joseph Conrad");
      testAuthor.Save();

      List<Author> testResult = Author.GetAllAuthors();
      List<Author> allAuthors = new List<Authors>{testAuthor};

      CollectionAssert.AreEqual(allAuthors, testResult);
    }
  }
}
