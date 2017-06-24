using AutoMapper;
using Newtonsoft.Json;
using ParsingDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());

            using (var context = new SFTDbContext())
            {
                var empl = Mapper.Map<EmployeeDTO>(context.Employees.First());

                string jsonEmployee = JsonConvert.SerializeObject(empl);

                Console.WriteLine(jsonEmployee);
            }
        }
    }
}
