using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsDados
{
    public class Livro : ClsDados
    {

        public override string GetDados()
        {
            return this.ISBN.ToString() + "\n" +
                this.Nome + "\n" +
                this.Titulo + "\n" +
                this.PrecoCompra.ToString() + "\n" +
                this.Data.ToString() + "\n" +
                this.Disponibilidade + "\n" +
                this.Ramo + "\n" +
                this.NColecao.ToString() + "\n" +
                this.MargemVenda.ToString() + "\n" +
                this.PVP.ToString();
        }
    }
}
