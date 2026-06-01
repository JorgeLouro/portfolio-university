using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terceiros;

namespace Sócios
{
    public class Sócios : Terceiros.Terceiros
    {
        public DateTime DataAtivação { get; set; }
        public DateTime DataSócio { get; set; }
        public override string GetDados()
        {
            return "Número Sequencial: " + NumSeq.ToString() + "\n" + 
                "NIF: " + NIF.ToString() + "\n" +
                "Nome: " + Nome.ToString() + "\n" +
                "Morada: " + Morada.ToString() + "\n" +
                "Tipo do Sócio: " + TipoSócio.ToString() + "\n" +
                "Data da Ativação: " + DataAtivação.ToShortDateString() + "\n" +
                "Data da admissão de Sócio: " + DataSócio.ToShortDateString();
        }
    }
}
