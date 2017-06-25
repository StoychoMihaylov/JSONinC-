using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XMLprocessiong
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Parse(@"<?xml version=""1.0""?><Root><Child>Value</Child></Root>");

            XDocument xmlSecondDoc = XDocument.Load("../../XMLCars.xml");
            var cars = xmlSecondDoc.Root.Elements();
            //cars.Remove();
            foreach (var car in cars)
            {
                var make = car.Element("make").Value;
                var model = car.Element("model").Value;

                //car.Element("traveled-distance").Value = "100";
                //car.SetElementValue("travel-distance", "100");
                //car.Remove();
                //car.Attribute("model").Value;
                Console.WriteLine($"{make} - {model}");
            }

            var cars2 = xmlSecondDoc.Root.Elements()
                .Where(e => e.Element("make").Value == "Opel" &&
                (long)e.Element("travelled-distance") >= 300000)
                .Select(c => new
                {
                    Model = c.Element("model").Value,
                    Traveled = c.Element("travelled-distance").Value
                }).ToList();

            foreach (var car in cars2)
            {
                Console.WriteLine($"{car.Model} - {car.Traveled}");
            }

            //---------------------------

            XDocument xmlBookDoc = new XDocument();
            xmlBookDoc.Add(
                new XElement("books",
                new XElement("book",
                new XElement("author", "Don Box"),
                new XElement("title", "ASP.NET", new XElement("lang", "en")))));
            xmlBookDoc.Save("../../Books.xml", SaveOptions.DisableFormatting);

            //serialize to object
            var serializer = new XmlSerializer(typeof(object));
            var writer = new StreamWriter("myProduct.xml");
            using (writer)
            {
                serializer.Serialize(writer, product);
            }
        }
    }
}
