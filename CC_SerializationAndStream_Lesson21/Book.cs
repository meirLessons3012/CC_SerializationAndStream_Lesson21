using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CC_SerializationAndStream_Lesson21
{
    public class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class CoverBook
    {
        public Book Book { get; set; }

        public CoverBook()
        {
             
        }

        public CoverBook(Book book)
        {
            Book = book;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
