using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrance.Models
{
    public class AllPassesItems
    {
        public string ID { get; set; }
        public string PassingTime { get; set; }
        public string PassedThrough { get; set; }
        public int TotalAttempts { get; set; }
        public AllPassesItems(string id, string passingTime, 
            string passedThrough, int totalAttempts)
        {
            ID = id;
            PassingTime = passingTime;
            PassedThrough = passedThrough;
            TotalAttempts = totalAttempts;
        }
    }
}
 
