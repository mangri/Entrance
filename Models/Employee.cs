using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entrance.Services;

namespace Entrance.Models
{
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int ClearanceLevel { get; set; }
        public int PassesTotal { get; set; }
        public List<double> Passes { get; set; }
        public Employee(string id, string name, int clearanceLevel)
        {
            ID = id;
            Name = name;
            ClearanceLevel = clearanceLevel;
            PassesTotal = passesTotalGenInitializer();
            Passes = passesThroughGatesGenInitializer(ID, PassesTotal);
        }
        private int passesTotalGenInitializer()
        {
            EventGen eventGen = new EventGen();
            return eventGen.passesTotalGen();
        }
        private List<double> passesThroughGatesGenInitializer(string id, int passesTotal)
        {
            EventGen eventGen = new EventGen();
            return eventGen.passesThroughGatesGen(id, passesTotal);
        }

    }
}
