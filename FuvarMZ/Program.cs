using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuvarMZ
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("fuvar.csv");
            List<Fuvar> fuvarok = new List<Fuvar>();

            foreach(string sor  in sorok.Skip(1))
            {
                fuvarok.Add(new Fuvar(sor));
            }
            int N = fuvarok.Count;
            Console.WriteLine($"3. feladat: {N} fuvar");

            //4
            int fuvarDb = 0;
            double bevetel = 0;
            foreach (Fuvar fuvar in fuvarok)
            {
                if(fuvar.Id ==6185)
                {
                    fuvarDb++;
                    bevetel += fuvar.Viteldíj;
                }
            }
            Console.WriteLine($"4. feladat {fuvarDb} fuvar alatt: {bevetel}");
            Console.WriteLine("5. feladat");
            Dictionary<string, int> fizModDb = new Dictionary<string, int>();
            foreach (Fuvar fuvar in fuvarok)
            {
                string kulcs = fuvar.FizetesiMod;
                if (fizModDb.ContainsKey(kulcs))
                {
                    fizModDb[kulcs]++;

                }
                else
                {
                    fizModDb.Add(kulcs, 1);
                }
                foreach  (KeyValuePair<string, int> item in fizModDb)
                {
                    fizModDb.Add(kulcs, 1);
                }
                
            }
            //6. feladat
            double osszMerfold = 0;
            foreach (Fuvar fuvar1 in fuvarok)
            {
                osszMerfold += fuvar.Tavolsag;

            }
            Console.WriteLine($"{osszMerfold * 1.6:F2} km");

            //7
            Console.WriteLine($"7. feladat: leghosszabb fuvar: ");
            int maxIdotartamInd = 0;
            for (int i = 1; i < N; i++)
            {
                if (fuvarok[i].Idotartam > fuvarok[maxIdotartamInd].Idotartam)
                {
                    maxIdotartamInd = i;

                }




            }
            Console.WriteLine($"\tfuvar hossza: {fuvarok[maxIdotartamInd].Idotartam} másodperc");
            Console.WriteLine($"\ttaxi id: {fuvarok[maxIdotartamInd].Id}");
            Console.WriteLine($"\tmegtett távolság: {fuvarok[maxIdotartamInd].Tavolsag:F1} km");
            Console.WriteLine($"\tviteldíj: {fuvarok[maxIdotartamInd].Viteldíj} $");

            //8
            Console.WriteLine("8. feladat: \"hibak.txt\"");
            List<string> hibasSorok = new List<string>();
            hibasSorok.Add(sorok[0]);
            foreach (Fuvar fuvar in fuvarok)
            {
                if (fuvar.Idotartam > 0 && fuvar.Viteldíj > 0 && fuvar.Tavolsag == 0)
                {
                    string sor = "" ;
                    sor += fuvar.Id + ";";
                    sor += fuvar.Indulas + ";";
                    sor += fuvar.Idotartam + ";";
                    sor += fuvar.Tavolsag + ";";
                    sor += fuvar.Viteldíj + ";";
                    sor += fuvar.Borravalo + ";";
                    sor += fuvar.FizetesiMod + ";";

                }
            }

            File.WriteAllText("hibak.txt", "", Encoding.UTF8);

            Console.ReadLine();

        }
    }
}
