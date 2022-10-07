using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrance.Models
{
    public class FinalLaborHoursItems
    {
        public string EmployeeName { get; }
        public double WorkingHours { get; set; }
        public FinalLaborHoursItems(string employeeName, double workingHours)
        {
            EmployeeName = employeeName;
            WorkingHours = workingHours;
        }
    }
}
