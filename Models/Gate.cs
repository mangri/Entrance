using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrance.Models
{
    public class Gate
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int ClearanceRequired { get; set; }
        public Gate(string id, string name, int clearanceLevel)
        {
            ID = id;
            Name = name;
            ClearanceRequired = clearanceLevel;
        }
    }
}
