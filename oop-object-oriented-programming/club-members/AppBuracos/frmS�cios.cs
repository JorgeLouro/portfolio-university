using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sócios;

namespace appTaxis
{
    public partial class frmBuracoVia : Form
    {
        public Sócios.Sócios[] Taxis;
        int i = -1;
        public frmBuracoVia()
        {
            InitializeComponent();
        }

        private void ShowDados()
        {
            if (i>=0)
            {
                txtNumSeq.Text = Taxis[i].NumSeq.ToString();
                txtNIF.Text = Taxis[i].NIF.ToString();
                txtNome.Text = Taxis[i].Nome.ToString();
                txtMorada.Text = Taxis[i].Morada.ToString();
                txtTipoSócio.Text = Taxis[i].TipoSócio.ToString();
                dtpAtivação.Value = Taxis[i].DataAtivação;
                dtpSócio.Value = Taxis[i].DataSócio;
                lblDados.Text = Taxis[i].GetDados();
            }
            else
            {
                txtNumSeq.Text = "";
                txtNIF.Text = "";
                txtNome.Text = "";
                txtMorada.Text = "";
                txtTipoSócio.Text = "";
                dtpAtivação.Value = DateTime.MinValue;
                dtpSócio.Value = DateTime.MinValue;
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
                MessageBox.Show("Ainda não existem sócios registados");

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
                MessageBox.Show("Ainda não existem sócios registados");
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
                MessageBox.Show("Ainda não existem sócios registados");
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                i = Taxis.Length - 1;
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem sócios registados");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Sócios.Sócios bv = new Sócios.Sócios()
            {
                NumSeq = int.Parse(txtNumSeq.Text),
                NIF = int.Parse(txtNIF.Text),
                Nome = txtNome.Text,
                Morada = txtMorada.Text,
                TipoSócio = txtTipoSócio.Text,
                DataAtivação = dtpAtivação.Value,
                DataSócio = dtpSócio.Value
            };
            Array.Resize<Sócios.Sócios>(ref Taxis, Taxis.Length + 1);
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
                Taxis[i].TipoSócio = txtTipoSócio.Text;
                Taxis[i].DataAtivação = dtpAtivação.Value;
                Taxis[i].DataSócio = dtpSócio.Value;
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem sócios registados");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                for (int j = i; j < Taxis.Length - 2; j++)
                    Taxis[j] = Taxis[j + 1];
                Array.Resize<Sócios.Sócios>(ref Taxis, Taxis.Length - 1);
                if (i >= Taxis.Length)
                    i = Taxis.Length - 1;
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem sócios registados");
        }

        private void frmBuracoVia_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMenu f = (frmMenu)this.Owner;
            f.bvia = this.Taxis;
        }

        private void frmBuracoVia_Shown(object sender, EventArgs e)
        {
            if (Taxis.Length > 0)
            {
                i = 0;
                ShowDados();
            }
        }
    }
}
