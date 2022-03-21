using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace CC_SerializationAndStream_Lesson21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Stream fileStream = new FileStream(@"E:\myFiles\myFile.txt", FileMode.Append))
            {
                byte[] myBytes = Encoding.ASCII.GetBytes("hello world ");
                fileStream.Write(myBytes, 0, myBytes.Length);
            }

            Book b1 = new Book();
            b1.Title = "Test";
            b1.Pages = 13;

            //same result
            string b1AsJson = b1.ToString();
            string ss = JsonSerializer.Serialize(b1);

            CoverBook cb = new CoverBook(b1);
            string cbAsJson = cb.ToString();


            #region Xml Serilizer

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CoverBook));
            //using(Stream fileStreamForBook = new FileStream(@"E:\myFiles\myBook.txt",FileMode.Append))
            {
                //xmlSerializer.Serialize(fileStreamForBook, cb);
            }
            using (Stream fileStreamForBook = new FileStream(@"E:\myFiles\myBook.txt", FileMode.Open))
            {
                CoverBook cbFromDe = (CoverBook)xmlSerializer.Deserialize(fileStreamForBook);
            }//fileStreamForBook.Close();

            using (Stream fsForArray = new FileStream(@"E:\myFiles\myBooks.txt", FileMode.Append))
            {
                XmlSerializer arrayXmlSerializer = new XmlSerializer(typeof(CoverBook[]));
                CoverBook[] cbArray = new CoverBook[3];
                cbArray[0] = new CoverBook(new Book { Title = "1", Pages = 23 });
                cbArray[1] = new CoverBook(new Book { Title = "2", Pages = 550 });
                cbArray[2] = new CoverBook(new Book { Title = "3", Pages = 10 });

                arrayXmlSerializer.Serialize(fsForArray, cbArray);
            }

            #endregion
        }
    }

}
