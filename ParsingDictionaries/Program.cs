using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ParsingDictionaries
{
    class Program
    {
        public static object JavaScriptSerializer { get; private set; }

        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());

            using (var context = new SFTDbContext())
            {
                var empl = context.Employees.ProjectTo<EmployeeDTO>().ToList();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var jsonEmployee = serializer.Serialize(empl);

                Console.WriteLine(jsonEmployee);
            }

            //Usin Dictionaries for serializeing JSON------------------

            using (var context = new SFTDbContext())
            {
                var emplDtos = context.Employees.ProjectTo<EmployeeDTO>().ToList();
                var employees = new Dictionary<string, EmployeeDTO>();
              
                foreach (var empl in emplDtos)
                {
                    employees[empl.FirstName] = empl;
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var jsonEmployee = serializer.Serialize(employees);

                Console.WriteLine(jsonEmployee);
            }

            var jsonFormat = "{'kiril':{'Id':0,'Name':'Oil Pump','Descriptiomn':'coool', 'Cost':25}}";

            JavaScriptSerializer ser = new JavaScriptSerializer();
            var em = ser.Deserialize<Dictionary<string, EmployeeDTO>>(jsonFormat);

            foreach (KeyValuePair<string, EmployeeDTO> e in em)
            {
                Console.WriteLine(e.Key);
            }
        }
    }

    public class EmployeeDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string JobTitle { get; set; }
    }
}
