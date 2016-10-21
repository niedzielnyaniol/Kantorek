using ClassLibrary.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataProvider = new NBPDataProvider();
            var dataParser = new NbpXmlToCurrencyParser();
            string url = "http://www.nbp.pl/kursy/xml/lasta.xml";

            foreach (var item in dataParser.Parse(dataProvider.GetStringFromXML(url)))
            {
                Console.WriteLine(item.NameShortcut + " - " + item.Name);
                Console.WriteLine(item.Converter);
                Console.WriteLine(item.ExchangeRate);
                Console.WriteLine("100 PLN = " + item.ReplaceFromPln(100) + " " + item.NameShortcut);
                Console.WriteLine("100 " + item.NameShortcut + " = " + item.ReplaceToPln(100) + " PLN");
                Console.WriteLine();
            }
        }
    }
}
