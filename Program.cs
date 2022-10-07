using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Entrance.Repositories;
using Entrance.Services;
using Entrance.Models;
using static System.Net.WebRequestMethods;
using System.Text;
using System.Globalization;
using System.Threading;

namespace Entrance
{
    public class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                //Report for labor hours
                Console.WriteLine("  Labor hours {0:dd/MM/yy}  ",
                    DateTime.Today.AddDays(-1));
                Console.WriteLine(" ----------------------");
                string titleName1 = String.Format(
                    "{0, -16}|{1, -6}", " Employee name", " Hours");
                Console.WriteLine(titleName1);
                Console.WriteLine(" ----------------------");
                InitializerHours();
                Console.WriteLine(" ----------------------");
                Console.WriteLine();

                //Entrance Log book summary
                Console.WriteLine("Hit Enter to get Log report");
                Console.ReadLine();

                Console.WriteLine("      Gate Log {0:dd/MM/yy}",
                    DateTime.Today.AddDays(-1));
                Console.WriteLine(" ------------------------------");
                string titleName2 = String.Format(
                    "{0, -5}|{1, -8}|{2, -5}|{3, -6}",
                    " Agent  ", "  Time", " Via", " Trials");
                Console.WriteLine(titleName2);
                Console.WriteLine(" ------------------------------");

                DirectoryInfo source = new DirectoryInfo("Passes");
                FileInfo[] fileNames = source.GetFiles("*.txt");
                Directory.CreateDirectory("PassesCopy");
                string target = "PassesCopy";

                if (Directory.Exists(target))
                {
                    foreach (FileInfo file in fileNames)
                    {
                        System.IO.File.Copy(file.FullName, "PassesCopy\\" + file.Name, true);
                    }
                }
                else
                {
                    Console.WriteLine("Source path does not exist!");
                }

                PassesReportInitializer();
                Console.WriteLine(" ------------------------------");
                Console.WriteLine();
                Console.WriteLine("Proceed with one more simulation? y/n");
                if (Console.ReadLine() == "y")
                {
                    continue;
                }
                else break;
            }
        }

        private static void InitializerHours()
        {
            EmployeeRepository employeeRepo =
               new EmployeeRepository();
            List<LaborHoursItems> laborHoursItems = 
                employeeRepo.Retrieve();
            LaborHours laborHours = new LaborHours();
            List<FinalLaborHoursItems> finalLaborHoursItems = 
                laborHours.CalculatingWorkingHours(laborHoursItems);

            foreach (var item in finalLaborHoursItems)
            {
                //Thread.Sleep(100);
                string employeeOutput = String.Format(" {0, -15}| {1:0.00} ", 
                    item.EmployeeName.ToString(), item.WorkingHours/60);
                Console.WriteLine(employeeOutput);
            }
        }
        private static void PassesReportInitializer()
        {
            AllPasses wholePassesReport = new AllPasses();
            List<AllPassesItems> returnedLogList = 
                wholePassesReport.PassesReport();

            foreach (var log in returnedLogList)
            {
                //Thread.Sleep(50);
                string gateOutput = String.Format(" {0, -5} |{1, -8}| {2, -4}|  {3, -4}", 
                    log.ID, log.PassingTime, log.PassedThrough, log.TotalAttempts);
                Console.WriteLine(gateOutput);

            }

        }
    }
}
