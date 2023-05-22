using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Models
{
   public class Book
   {
      public int Id { get; set; }
      public string Title { get; set; }
      public string Authors { get; set; }
      public int Year { get; set; }

      public override string ToString()
      {
         return $"{Authors}. {Title}. - {Year}";
      }
   }
}
