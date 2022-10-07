using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entrance.Models;

namespace Entrance.Repositories
{
    public class GateRepository
    {
        public List<Gate> gates { get; private set; }
        public GateRepository()
        {
            gates = new List<Gate>();
            gates.Add(new Gate("G1", "Confidential", 1));
            gates.Add(new Gate("G2", "Secret", 2));
            gates.Add(new Gate("G3", "TopSecret", 3));
            gates.Add(new Gate("G4", "CodeAcademy", 4));
        }
        public List<Gate> Retrieve()
        {
            return gates;
        }
        public int Retrieve(string gateID)
        {
            int clearance = gates.Where(c => c.ID == gateID).
                First().ClearanceRequired;
            return clearance;
        }
    }
}
