using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Taxis
{
    public class ClsListaTaxi
    {
        public ClsTaxi[] salas { get; set; }

        public void Import(string filename)
        {
            salas = new ClsTaxi[] { };
            List<ClsTaxi> sls = new List<ClsTaxi>();

            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                string linha = sr.ReadLine();
                string[] fld = linha.Split(';');
                ClsTaxi s = new ClsTaxi()
                {
                    NºTaxi = fld[0],
                    Matricula = fld[1],
                    Capacidade = int.Parse(fld[2]),
                    Combustivel = fld[3]
                    
                };
                bool oc = bool.Parse(fld[4]);
                if (oc)
                    s.Ocupar();
                sls.Add(s);
            }
            sr.Close();
            salas = sls.ToArray();
        }

        public void Export(string filename)
        {
            StreamWriter sr = new StreamWriter(filename);
            foreach (ClsTaxi s in salas)
                sr.WriteLine(s.NºTaxi + "; " + s.Capacidade.ToString() + "; " +
                    s.Matricula + "; " + s.Combustivel + "; " + s.Ocupado.ToString());
            sr.Close();
        }
    }
}
