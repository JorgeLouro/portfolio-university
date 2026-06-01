using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilizadores;

namespace appTaxis
{
    public partial class frmBuracoAgua : Form
    {
        public Utilizadores.Utilizadores[] Taxis;
        int i = -1;
        public frmBuracoAgua()
        {
            InitializeComponent();
        }
        private void ShowDados()
        {
            if (i >= 0)
            {
                txtNumSeq.Text = Taxis[i].NumSeq.ToString();
                txtNIF.Text = Taxis[i].NIF.ToString();
                txtNome.Text = Taxis[i].Nome.ToString();
                txtMorada.Text = Taxis[i].Morada.ToString();
                txtNVeiculos.Text = Taxis[i].NumVeiculos.ToString();
                dtpAtivação.Value = Taxis[i].DataAtivação;
                dtpInicio.Value = Taxis[i].DataInicio;
                dtpDataFim.Value = Taxis[i].DataFim;
             
                lblDados.Text = Taxis[i].GetDados();
            }
            else
            {
                txtNumSeq.Text = "";
                txtNIF.Text = "";
                txtNome.Text = "";
                txtMorada.Text = "";
                txtNVeiculos.Text = "";
                dtpAtivação.Value = DateTime.MinValue;
                dtpInicio.Value = DateTime.MinValue;
                dtpDataFim.Value = DateTime.MinValue;
                
   
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
                MessageBox.Show("Ainda não existem utilizadores registados");

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
                MessageBox.Show("Ainda não existem utilizadores registados");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (i >= 0)
                if (i < Taxis.Length - 1)
                {
                    i++;
                    ShowDados();
                }
                else
                    MessageBox.Show("Não pode passar para lá do último");
            else
                MessageBox.Show("Ainda não existem utilizadores registados");
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                i = Taxis.Length - 1;
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem utilizadores registados");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Utilizadores.Utilizadores bv = new Utilizadores.Utilizadores()
            {
                NumSeq = int.Parse(txtNumSeq.Text),
                NIF = int.Parse(txtNIF.Text),
                Nome = txtNome.Text,
                Morada = txtMorada.Text,
                DataInicio = dtpAtivação.Value,
    
            };
            Array.Resize<Utilizadores.Utilizadores>(ref Taxis, Taxis.Length + 1);
            i = Taxis.Length - 1;
            Taxis[i] = bv;
            ShowDados();
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                Taxis[i].NumSeq = int.Parse(txtNumSeq.Text);
                Taxis[i].NIF = int.Parse(txtNIF.Text);
                Taxis[i].Nome = txtNome.Text;
                Taxis[i].Morada = txtMorada.Text;
                Taxis[i].NumVeiculos = int.Parse(txtNVeiculos.Text);
                Taxis[i].DataInicio = dtpInicio.Value;
                Taxis[i].DataFim = dtpDataFim.Value;
                Taxis[i].DataAtivação = dtpAtivação.Value;


                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem utilizadores registados");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                for (int j = i; j < Taxis.Length - 2; j++)
                    Taxis[j] = Taxis[j + 1];
                Array.Resize<Utilizadores.Utilizadores>(ref Taxis, Taxis.Length - 1);
                if (i >= Taxis.Length)
                    i = Taxis.Length - 1;
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem utilizadores registados");
        }

        private void frmBuracoAgua_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMenu f = (frmMenu)this.Owner;
            f.bagua = this.Taxis;
        }

        private void frmBuracoAgua_Shown(object sender, EventArgs e)
        {
            if (Taxis.Length > 0)
            {
                i = 0;
                ShowDados();
            }
        }
    }
}
