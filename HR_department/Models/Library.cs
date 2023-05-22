using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Models
{
   public class Library
   {
      public bool IsDirty { set; get; }

      public Library() {
         
      }

      public List<Book> Books { get; set; }



      public void GenTestData(int n) 
      { 
         Books = new List<Book>();
         for (int i = 0; i < n; i++)
         {
            var book = new Book {
               Id = i,
               Title = "TestBook" + i,
               Authors = "Author" + i,
               Year = 1900 + i
            };
            Books.Add(book);  
         }
         IsDirty = true;
      }

      internal List<Book> SearchBooks(string line)
      {
         List<Book> result = new List<Book>();
         var t = line.ToLower();
         foreach (Book book in Books)
         {
            if (book.ToString().ToLower().IndexOf(t) > -1)
            {
               result.Add(book);
            }
         }
         return result;
      }
   }
}
