using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ClsDados;

namespace WSPessoa
{
    /// <summary>
    /// Summary description for WsPessoa
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WsPessoa : System.Web.Services.WebService
    {
        Livro[] livros = new Livro[]
        {
            new Livro() {ISBN=1,Nome="Autor 1",Titulo="Titulo 1", PrecoCompra=1, Data=1, PVP=1, NColecao=1, Disponibilidade= "Disponibilidade 1", Ramo= "Ramo 1", MargemVenda=1},
            new Livro() {ISBN=2,Nome="Autor 2",Titulo="Titulo 2", PrecoCompra=2, Data=2, PVP=2, NColecao=2, Disponibilidade= "Disponibilidade 2", Ramo= "Ramo 2", MargemVenda=2},
            new Livro() {ISBN=3,Nome="Autor 3",Titulo="Titulo 3", PrecoCompra=3, Data=3,PVP=3, NColecao=3, Disponibilidade= "Disponibilidade 3", Ramo= "Ramo 3", MargemVenda=3}
        };

        [WebMethod(Description ="Obtém a lista de livros")]
        public Livro[] GetLivros()
        {
            return livros;
        }

        [WebMethod(Description = "Obtém os dados de uma livros")]
        public Livro GetLivro(int i)
        {
            if (i >= livros.Length || i < 0)
                return new Livro() { ISBN = 0, Nome = "Desconhecido", Titulo = "Desconhecida", PrecoCompra = 0, Data = 0, Disponibilidade = "Desconhecida",PVP = 0, NColecao= 0, Ramo = "Desconhecida", MargemVenda = 0 };
            return livros[i];
        }
    }
}
