using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxis
{
    public class ClsTaxi
    {
        bool ocupado = false;
        public string NºTaxi { get; set; }
        public int Capacidade { get; set; }
        public string Matricula { get; set; }
        public string Combustivel { get; set; }
        public bool Ocupado
        {
            get
            {
                return ocupado;
            }
        }

        public ClsTaxi()
        {
            this.NºTaxi = "";
            this.Capacidade = 0;
            this.Matricula = "";
            this.Combustivel = "";
        }

        public void Ocupar()
        {
            ocupado = true;
        }

        public void Desocupar()
        {
            ocupado = false;
        }
    }
}
