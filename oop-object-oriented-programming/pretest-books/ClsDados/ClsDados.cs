using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsDados
{
    public abstract class ClsDados
    {
        public int ISBN { get; set; }
        public string Nome { get; set; }

        public string Titulo { get; set; }

        public int PrecoCompra { get; set; }
        public int Data { get; set; }
        public int PVP { get; set; }
        public int NColecao { get; set; }
        public string Ramo { get; set; }
        public string Disponibilidade { get; set; }
        public int MargemVenda { get; set; }




        public abstract string GetDados();
    }
}
