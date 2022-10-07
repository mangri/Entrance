using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Entrance.Models;
using Entrance.Repositories;

namespace Entrance.Services
{
    public class EventGen
    {
        GateRepository gateRepo =
              new GateRepository();
        public int passesTotalGen()
        {

            Random rnd = new Random();
            int line = rnd.Next(0,70);
            var sr = new StreamReader("PossibleTotalPasses.txt");
            for (int i = 1; i < line; i++)
                sr.ReadLine();
            return Int32.Parse(sr.ReadLine());
        }
        public List<double> passesThroughGatesGen(
            string id, int passesTotal)
        {
            if (passesTotal != 0)
            {
                do
                {
                    Random rnd = new Random();
                    List<double> passesIN = new List<double>();
                    for (int i = 0; i < passesTotal / 2; i++)
                    {
                        int line = rnd.Next(0, 3884);
                        var sr1 = new StreamReader(
                            "PossiblePassesThroughGatesIN.txt");
                        for (int j = 1; j < line; j++)
                            sr1.ReadLine();
                        passesIN.Add(Double.Parse(sr1.ReadLine()));
                    }

                    List<double> passesOUT = new List<double>();
                    for (int i = 0; i < passesTotal / 2; i++)
                    {
                        int line = rnd.Next(0, 3673);
                        var sr2 = new StreamReader(
                            "PossiblePassesThroughGatesOUT.txt");
                        for (int j = 1; j < line; j++)
                            sr2.ReadLine();
                        passesOUT.Add(Double.Parse(sr2.ReadLine()));
                    }
                    passesIN.Sort(); passesOUT.Sort();
                    int check1 = 0; 
                    for(int i = 0; i < passesTotal/2; i++)
                    {
                        if (passesIN[i] < passesOUT[i])
                        {
                            check1++;
                        }
                    }
                    int check2 = 0;
                    for (int i = 0; i < passesTotal/2 - 1; i++)
                    {
                        if (passesIN[i + 1] > passesOUT[i])
                        {
                            check2++;
                        }
                    }
                    bool genSelectionConfirm = (check1 == passesTotal/2 && 
                        check2 == passesTotal / 2 - 1);
                    if (passesIN[0] <= passesOUT[0] &&
                        passesIN.Last() <= passesOUT.Last() &&
                        genSelectionConfirm)
                    {
                        List<double> passes = new List<double>();
                        for (int i = 0; i < passesTotal / 2; i++)
                        {
                            passes.Add(passesIN[i]);
                            passes.Add(passesOUT[i]);
                        }

                        List<string> passesStringList = 
                            passes.ConvertAll(item => item.ToString());
                        string path = "Passes\\";
                        File.WriteAllLines(path + id + ".txt", passesStringList);

                        return passes;
                    }
                } while (true);
            }
            else
            {
                List<double> passes = new List<double>();
                passes.Add((double)0);
                passes.Add((double)0);

                List<string> passesStringList =
                    passes.ConvertAll(item => item.ToString());
                string path = "Passes\\";
                File.WriteAllLines(path + id + ".txt", passesStringList);

                return passes;
            }

            
        }
        public string GateIDGen()
        {
            Random random = new Random();
            string gateID = gateRepo.gates[
                random.Next(0, gateRepo.gates.Count)].ID;
            return gateID;
        }

    }
}
