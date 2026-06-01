using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes
{
    public abstract class Paciente
    {
        public int NumUtente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public abstract float GetValor(float vlr, decimal per);
    }
}
