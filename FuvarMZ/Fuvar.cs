using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuvarMZ
{
    class Fuvar
    {
        public int Id { get; set; }
        public string Indulas{ get; set; }
        public int Idotartam { get; set; }

        public double Tavolsag { get; set; }
        public double Viteldíj { get; set; }
        public double Borravalo { get; set; }
        public string FizetesiMod { get; set; }

        public Fuvar(string sor)
        {
            string[] s = sor.Split(';');
            Id = int.Parse(s[0]);
            Indulas = s[1];
            Idotartam = int.Parse(s[2]);
            Tavolsag = double.Parse(s[3]);
            Viteldíj = double.Parse(s[4]);
            Borravalo = double.Parse(s[5]);
            FizetesiMod = s[6];
        }


        /*private int id;
        public int getId()
        {
            return id;
        }*/
    }
}
