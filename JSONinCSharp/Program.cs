using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JSONinCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Seriazlize JSON-------------------

            var dog = new Dog
            {
                Name = "Balkan",
                Age = 6
            };

            var person = new Person
            {
                Name = "Atanas",
                Age = 24,
                Dog = dog
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(person);
            Console.WriteLine(json);

            Console.WriteLine();
            //Deserialize JSON---------------------------

            string JSON = "{'Name': 'Strahil', 'Age': 22, 'Dog': null}";

            var objPerson = serializer.Deserialize<Person>(JSON);

            Console.WriteLine($"Name: {objPerson.Name}, Age: {objPerson.Age}");

            Console.WriteLine();
        }
    }

    public class Dog
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person Owner { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Dog Dog { get; set; }
    }
}
