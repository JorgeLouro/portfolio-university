using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terceiros;

namespace Utilizadores
{
    public class Utilizadores : Terceiros.Terceiros
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public DateTime DataAtivação { get; set; }

        public override string GetDados()
        {
            return "Número Sequencial: " + NumSeq.ToString() + "\n" +
                "NIF: " + NIF.ToString() + "\n" +
                "Nome: " + Nome.ToString() + "\n" +
                "Morada: " + Morada.ToString() + "\n" +
                "Data da Ativação: " + DataAtivação.ToShortDateString() + "\n" +
                "Data da Inicio de serviço: " + DataInicio.ToShortDateString() + "\n" +
                "Data da Fim de serviço: " + DataFim.ToShortDateString() + "\n" +
                "Nº de Veiculos: " + NumVeiculos.ToString() + "\n";

        }
    }
}
