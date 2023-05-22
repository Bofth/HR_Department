using Biblio.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Biblio.Data
{
   internal static class DataAccess
   {
      const string DATA_PATH = "Data\\Library.json";

      public static void Save(Library library)
      {
         string jsonString = JsonSerializer.Serialize(library.Books);
         File.WriteAllText(DATA_PATH, jsonString);
         library.IsDirty = false;
      }

      public static void Load(Library library)
      {
         string jsonString = File.ReadAllText(DATA_PATH);
         var newBooks = JsonSerializer.Deserialize<List<Book>>(jsonString);
         library.Books.Clear();
         library.Books.AddRange(newBooks);
         library.IsDirty = false;
      }

   }
}
