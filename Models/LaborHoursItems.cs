using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrance.Models
{
    public class LaborHoursItems
    {
        public string EmployeeName { get; }
        public List<double> WorkingHours { get; set; }
        public LaborHoursItems(string employeeName, List<double> workingHours)
        {
            EmployeeName = employeeName;
            WorkingHours = workingHours;
        }
    }

}
