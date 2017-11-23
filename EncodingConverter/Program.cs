using System;
using System.Text;
using System.IO;

namespace EncodingConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\Jazmin\source\Codecool\.NET basics\SI projects\DataValidation\EncodingConverter\fruits.txt"))
                using (StreamWriter writer = new StreamWriter("happiest-utf7.txt", false, Encoding.UTF7))
                    writer.WriteLine(reader.ReadToEnd());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
