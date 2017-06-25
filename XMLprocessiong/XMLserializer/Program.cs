using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLserializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new ProductDTO
            {
                Name = "Transmission",
                Cost = 800m
            };

            var serializer = new XmlSerializer(product.GetType());
            var writer = new StreamWriter("../../product.xml");
            using (writer)
            {
                serializer.Serialize(writer, product);
            }

            var reader = new StreamReader("../../product.xml");
            var prd = (ProductDTO)serializer.Deserialize(reader);

            Console.WriteLine(prd.Name);
            Console.WriteLine(prd.Cost);
        }
    }

    public class ProductDTO
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }
    }
}
