using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terceiros
{
    public abstract class Terceiros
    {
        public int NumSeq { get; set; }
        public int NIF { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string TipoSócio { get; set; }
        public int NumVeiculos { get; set; }

        public abstract string GetDados();
    }
}
