using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entrance.Models;
using Entrance.OtherDataTypes;

namespace Entrance.Repositories
{
    public class EmployeeRepository
    {
        public List<Employee> employees { get; private set; }
        public EmployeeRepository()
        {
            employees = new List<Employee>();
            employees.Add(new Employee("manher", "Mantas Herkus", 4));
            employees.Add(new Employee("chadar", "Charles Darwin", 1));
            employees.Add(new Employee("karmar", "Karl Marx", 1));
            employees.Add(new Employee("marlut", "Martin Luther", 3));
            employees.Add(new Employee("martwa", "Mark Twain", 2));
            employees.Add(new Employee("isanew", "Isaac Newton", 2));
            employees.Add(new Employee("oscwil", "Oscar Wilde", 3));
            employees.Add(new Employee("thoedi", "Thomas Edison", 2));
            employees.Add(new Employee("sigfre", "Sigmund Freud", 1));
            employees.Add(new Employee("hartru", "Harry Truman", 1));
        }
        public List<LaborHoursItems> Retrieve()
        {
            List <LaborHoursItems> workingHoursList= new List<LaborHoursItems>();
            foreach(var employee in employees)
            {
                workingHoursList.Add(new LaborHoursItems(employee.Name, employee.Passes));
            }
            return workingHoursList;
        }
        public int Retrieve(string employeeID)
        {
            int security = employees.Where(l => l.ID == employeeID).
                First().ClearanceLevel;

            return security;
        }
    }
}
