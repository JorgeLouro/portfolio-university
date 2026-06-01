using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buraco
{
    public abstract class Buraco
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int Largura { get; set; }
        public int Profundidade { get; set; }

        public abstract string GetDados();
    }
}
