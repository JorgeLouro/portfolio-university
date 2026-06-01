using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppPessoas.wsPessoas;

namespace AppPessoas
{
    public partial class frmLivros : Form
    {
        WsPessoaSoapClient ws = new WsPessoaSoapClient();
        Livro[] livros;
        int i = 0;

        public frmLivros()
        {
            InitializeComponent();
            livros = ws.GetLivros();
        }

        private void MostraLivro()
        {
            if (i>=0)
            {
                txtISBN.Text = livros[i].ISBN.ToString();
                txtNome.Text = livros[i].Nome;
                txtTitulo.Text = livros[i].Titulo;
                txtPrecoCompra.Text = livros[i].PrecoCompra.ToString();
                txtData.Text = livros[i].Data.ToString();
                txtPVP.Text = livros[i].PVP.ToString();
                txtNcolecao.Text = livros[i].NColecao.ToString();
                txtRamo.Text = livros[i].Ramo;
                txtDisponibilidade.Text = livros[i].Disponibilidade;
                txtMargemVenda.Text = livros[i].MargemVenda.ToString();


            }
            else
            {
                txtISBN.Text = "";
                txtNome.Text = "";
                txtTitulo.Text = "";
                txtData.Text = "";
                txtPrecoCompra.Text= "";
                txtPVP.Text = "";
                txtNcolecao.Text = "";
                txtRamo.Text = "";
                txtDisponibilidade.Text = "";
                txtMargemVenda.Text = "";

            }

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                i = 0;
                MostraLivro();
            }
            else
                MessageBox.Show("Ainda não existem Pessoas registadas");
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                if (i > 0)
                {
                    i--;
                    MostraLivro();
                }
                else
                    MessageBox.Show("Não pode passar para trás do primeiro");
            }
            else
                MessageBox.Show("Ainda não existem Pessoas registadas");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                if (i < livros.Length - 1)
                {
                    i++;
                    MostraLivro();
                }
                else
                    MessageBox.Show("Não pode passar para a frente do último");
            }
            else
                MessageBox.Show("Ainda não existem Pessoas registadas");
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                i = livros.Length - 1;
                MostraLivro();
            }
            else
                MessageBox.Show("Ainda não existem Pessoas registadas");
        }

    }
}
