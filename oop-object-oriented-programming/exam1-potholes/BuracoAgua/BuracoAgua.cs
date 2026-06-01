using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buraco;

namespace BuracoAgua
{
    public class BuracoAgua : Buraco.Buraco
    {
        public DateTime DataRotura { get; set; }
        public int HorasReparacao { get; set; }

        public override string GetDados()
        {
            return "Coordenadas (X,Y): " + CoordX.ToString() + "," + CoordY.ToString() + "\\n" +
                "Largura: " + Largura.ToString() + "\\n" +
                "Profundidade" + Profundidade.ToString() + "\\n" +
                "Data da Rotura: " + DataRotura.ToShortDateString() + "\\n" +
                "Horas de Reparação: " + HorasReparacao.ToString();
        }
    }
}
