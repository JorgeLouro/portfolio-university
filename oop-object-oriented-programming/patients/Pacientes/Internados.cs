using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacientes
{
    public class Internados:Paciente
    {
        public int NumEntrada { get; set; }
        public DateTime Admissao { get; set; }
        public string TipoExame { get; set; }
        public decimal Valor { get; set; }

        public override float GetValor(float vlr, decimal per)
        {
            return vlr * (float)(1 + per);
        }
    }
}
