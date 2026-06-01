using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taxis
{
    public partial class frmTaxi : Form
    {
        ClsTaxi[] taxis = new ClsTaxi[] { };
        int i = -1;
        
        public frmTaxi()
        {
            InitializeComponent();
        }

        private void MostraDados()
        {
            if (i>=0)
            {
                txtNºTaxi.Text = taxis[i].NºTaxi;
                txtCapacidade.Text = taxis[i].Capacidade.ToString();
                txtMatricula.Text = taxis[i].Matricula;
                txtCombustivel.Text = taxis[i].Combustivel;
                rbOcupada.Checked = taxis[i].Ocupado;
                rbDesocupado.Checked = !taxis[i].Ocupado;
            }
            else
            {
                txtNºTaxi.Text = "";
                txtCapacidade.Text = "";
                txtMatricula.Text = "";
                txtCombustivel.Text = "";
                rbOcupada.Checked = false;
                rbDesocupado.Checked = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNºTaxi.Text == "" || txtCapacidade.Text == "" || txtMatricula.Text == "" || txtCombustivel.Text == "")
            {
                MessageBox.Show("Tem de preencher os campos todos");
            }
            else
            {
                int cap = 0;
                if (int.TryParse(txtCapacidade.Text, out cap))
                {
                    ClsTaxi s = new ClsTaxi();
                    s.NºTaxi = txtNºTaxi.Text;
                    s.Capacidade = cap;
                    s.Matricula = txtMatricula.Text;
                    s.Combustivel = txtCombustivel.Text;
                    if (rbOcupada.Checked)
                        s.Ocupar();
                    Array.Resize<ClsTaxi>(ref taxis, taxis.Length + 1);
                    i = taxis.Length - 1;
                    taxis[i] = s;
                }
                else
                    MessageBox.Show("A capacidade do taxi tem de ser um número inteiro");
            }
        }


        private void btnAlt_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                if (txtNºTaxi.Text == "" || txtCapacidade.Text == "" || txtMatricula.Text == "" || txtCombustivel.Text == "")
                    MessageBox.Show("Tem de preencher os campos todos");
                {
                    int cap = 0;
                    if (int.TryParse(txtCapacidade.Text, out cap))
                    {
                        taxis[i].NºTaxi = txtNºTaxi.Text;
                        taxis[i].Matricula = txtMatricula.Text;
                        taxis[i].Capacidade = cap;
                        taxis[i].Combustivel = txtCombustivel.Text;
                        if (rbOcupada.Checked)
                            taxis[i].Ocupar();
                        else
                            taxis[i].Desocupar();
                    }
                    else
                        MessageBox.Show("A capacidade do taxi tem de ser um número inteiro");
                }
                
            }
            else
                MessageBox.Show("Ainda não existem taxis registados");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (i>=0)
            {
                for (int j = i; j < taxis.Length - 1; j++)
                    taxis[j] = taxis[j + 1];
                Array.Resize<ClsTaxi>(ref taxis, taxis.Length - 1);
                if (i > taxis.Length - 1)
                    i = taxis.Length - 1;
                MostraDados();
            }
            else
                MessageBox.Show("Ainda não existem taxis registados");
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (i>=0)
            {
                i = 0;
                MostraDados();
            }
            else
                MessageBox.Show("Ainda não existem taxis registados");
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (i>=0)
            {
                if (i > 0)
                {
                    i--;
                    MostraDados();
                }
                else
                    MessageBox.Show("Não pode passar para trás do primeiro");
            }
            else
                MessageBox.Show("Ainda não existem taxis registados");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (i>=0)
            {
                if (i < taxis.Length - 1)
                {
                    i++;
                    MostraDados();
                }
                else
                    MessageBox.Show("Não pode passar para lá do último");
            }
            else
                MessageBox.Show("Ainda não existem taxis registados registados");

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                i = taxis.Length - 1;
                MostraDados();
            }
            else
                MessageBox.Show("Ainda não existem taxis registados registados");
        }

        private void rbChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                bool ocupada = (rb.Name == "rbOcupada");
                rbOcupada.Checked = ocupada;
                rbDesocupado.Checked = !ocupada;
            }
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                frmGrid f = new frmGrid();
                f.dgvSalas.DataSource = taxis;
                f.ShowDialog(this);
            }
            else
                MessageBox.Show("Ainda não existem taxis registados");
        }
        
    }
}
