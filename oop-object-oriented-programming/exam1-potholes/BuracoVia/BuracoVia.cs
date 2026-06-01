using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buraco;

namespace BuracoVia
{
    public class BuracoVia : Buraco.Buraco
    {
        public DateTime DataParticipacao { get; set; }
        public DateTime DataReparacao { get; set; }
        public override string GetDados()
        {
            return "Coordenadas (X,Y): " + CoordX.ToString() + "," + CoordY.ToString() + "\\n" +
                "Largura: " + Largura.ToString() + "\\n" +
                "Profundidade" + Profundidade.ToString() + "\\n" +
                "Data da Participação: " + DataParticipacao.ToShortDateString() + "\\n" +
                "Data da Reparação: " + DataReparacao.ToShortDateString();
        }
    }
}
