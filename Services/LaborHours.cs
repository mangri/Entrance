using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entrance.Models;
using Entrance.Repositories;

namespace Entrance.Services
{
    public class LaborHours
    {
        public List<FinalLaborHoursItems> CalculatingWorkingHours(
            List<LaborHoursItems> fromEmployeeRepository)
        {
            List <FinalLaborHoursItems> finalHoursList = 
                new List<FinalLaborHoursItems>();
            foreach (var employee in fromEmployeeRepository)
            {
                int numberOfPases = employee.WorkingHours.Count;
                double[] passesIN = new double[numberOfPases/2];
                double[] passesOUT = new double[numberOfPases / 2];
                int m = 0; int n = 0;
                for (int i = 1; i <= numberOfPases; i++)
                {
                    if(i % 2 == 1)
                    {
                        passesIN[m] = employee.WorkingHours[i - 1];
                        m++;
                    }
                    else
                    {
                        passesOUT[n] = employee.WorkingHours[i - 1];
                        n++;
                    }
                }
                double hours = 0.0;
                for(int i = 0; i < numberOfPases / 2; i++)
                {
                    hours = hours + (passesOUT[i] - passesIN[i]);
                }
                FinalLaborHoursItems employeeHours = 
                    new FinalLaborHoursItems(employee.EmployeeName, hours);
                finalHoursList.Add(employeeHours);
            }
            return finalHoursList;
        }
    }
}
