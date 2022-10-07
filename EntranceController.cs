using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entrance.Repositories;
using Entrance.Services;

namespace Entrance
{
    public class EntranceController
    {
        GateRepository gateRepo =
              new GateRepository();
        EmployeeRepository employeeRepo =
              new EmployeeRepository();
        EventGen eventGen = new EventGen();

        public (string, int) allowedToPass(string employeeID)
        {
            int clearanceLevel =
                    employeeRepo.Retrieve(employeeID);
            string gateID = "";
            int attempts = 0;
            bool allowed = false;
            while(!allowed)
            {
                gateID = eventGen.GateIDGen();
                int gateSecurityLevel =
                    gateRepo.Retrieve(gateID);
                allowed = (gateSecurityLevel <= clearanceLevel);
                attempts++;
            } 
            return (gateID, attempts);

        }

    }
}
