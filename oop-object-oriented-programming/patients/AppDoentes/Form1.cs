using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacientes;
using AppDoentes.WSPrecos;


namespace AppDoentes
{
    public partial class frmInternado : Form
    {
        public Internados[] vect = new Internados[] { };
        int i = -1;
        WebService1SoapClient ws = new WebService1SoapClient();

        public frmInternado()
        {
            InitializeComponent();
        }

        private void ShowDados()
        {
            if (i >= 0)
            {
                txtNUtente.Text = vect[i].NumUtente.ToString();
                txtNome.Text = vect[i].Nome;
                dtpData.Value = vect[i].DataNascimento;
                txtValor.Text = vect[i].Valor.ToString();
                txtTipoExame.Text = vect[i].TipoExame;
                txtNEntrada.Text = vect[i].NumEntrada.ToString();
                dtpDataAdmissao.Value = vect[i].Admissao;
                txtGetValor.Text = vect[i].GetValor((float)vect[i].Valor, (decimal)0.1).ToString();

            }
            else
            {
                txtNUtente.Text = "";
                txtNome.Text = "";
                dtpData.Value = DateTime.Today;
                txtValor.Text = "";
                txtTipoExame.Text = "";
                txtNEntrada.Text = "";
                dtpDataAdmissao.Value = DateTime.Today;
                txtGetValor.Text = "";
               

            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                i = 0;
                ShowDados();
            }
            else
                MessageBox.Show("Não existem registos na BD");
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (i >= 0)
                if (i > 0)
                {
                    i--;
                    ShowDados();
                }
                else
                    MessageBox.Show("Não pode passar para trás do primeiro");
            else
                MessageBox.Show("Não existem registos na BD");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (i >= 0)
                if (i < vect.Length - 1)
                {
                    i++;
                    ShowDados();
                }
                else
                    MessageBox.Show("Não pode passar para lá do último");
            else
                MessageBox.Show("Não existem registos na BD");
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                i = vect.Length - 1;
                ShowDados();
            }
            else
                MessageBox.Show("Não existem registos na BD");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Internados g = new Internados()
            {
                NumUtente = int.Parse(txtNUtente.Text),
                Nome = txtNome.Text,
                DataNascimento = dtpData.Value,
                TipoExame = txtTipoExame.Text,
                NumEntrada = int.Parse(txtNEntrada.Text),
                Admissao = dtpDataAdmissao.Value,
                Valor = decimal.Parse(txtValor.Text)
            };
            Array.Resize<Internados>(ref vect, vect.Length + 1);
            i = vect.Length - 1;
            vect[i] = g;
            ShowDados();
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                vect[i].NumUtente = int.Parse(txtNUtente.Text);
                vect[i].Nome = txtNome.Text;
                vect[i].DataNascimento = dtpData.Value;
                vect[i].TipoExame = txtTipoExame.Text;
                vect[i].NumEntrada = int.Parse(txtNEntrada.Text);
                vect[i].Admissao = dtpDataAdmissao.Value;
                vect[i].Valor = decimal.Parse(txtValor.Text);
                ShowDados();
            }
            else
                MessageBox.Show("Não existem registos na BD");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                Internados g = vect[i];
                for (int j = i; j < vect.Length - 1; j++)
                    vect[j] = vect[j + 1];
                Array.Resize<Internados>(ref vect, vect.Length - 1);
                if (i > vect.Length - 1)
                    i = vect.Length - 1;
                ShowDados();
            }
            else
                MessageBox.Show("Não existem registos na BD");
        }
    }
}