using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entrance.OtherDataTypes;

namespace Entrance.Services
{
    public class AllPasses
    {
        EntranceController entranceController = 
            new EntranceController();
        public List<AllPassesItems> PassesReport()
        {
            List<AllPassesItems> passingData = 
                new List<AllPassesItems>();

            DirectoryInfo di = new DirectoryInfo("PassesCopy");
            FileInfo[] fileNames = di.GetFiles("*.txt");
            foreach (FileInfo file in fileNames)
            {

                char[] chars = file.Name.ToCharArray();
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < file.Name.ToString().Length - 4; i++)
                {
                    stringBuilder.Append(chars[i]);
                }
                var logArray = File.ReadAllLines("PassesCopy\\" + file.Name.ToString());
                var logList = new List<string>(logArray);

                if (logList.Count > 2)
                {
                    foreach (string time in logList)
                    {
                        (string gateID, int attempts) =
                            entranceController.allowedToPass(stringBuilder.ToString());
                        int timeHours = Convert.ToInt32(
                            Math.Truncate(Double.Parse(time) / 60));
                        int restMinutes = Convert.ToInt32(
                            Math.Truncate(Double.Parse(time) - timeHours * 60));
                        string timeString = 
                            timeHours.ToString() + ":" + restMinutes.ToString();
                        var result = Convert.ToDateTime(timeString);
                        string timeOutput = result.ToString("hh:mm tt", 
                            CultureInfo.CurrentCulture);

                        AllPassesItems passing = new AllPassesItems(
                            stringBuilder.ToString(), timeOutput, gateID, attempts);
                        passingData.Add(passing);
                    }
                }
                else if (logList[0] == "0" && logList[0] == "0")
                {
                    AllPassesItems passing = new AllPassesItems(
                            stringBuilder.ToString(), "N/A", "N/A", 0);
                    passingData.Add(passing);
                }

            }
            return passingData;
        }
        
    }
}
