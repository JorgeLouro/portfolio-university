using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuracoAgua;

namespace AppBuracos
{
    public partial class frmBuracoAgua : Form
    {
        public BuracoAgua.BuracoAgua[] bagua;
        int i = -1;
        public frmBuracoAgua()
        {
            InitializeComponent();
        }
        private void ShowDados()
        {
            if (i >= 0)
            {
                txtCoordX.Text = bagua[i].CoordX.ToString();
                txtCoordY.Text = bagua[i].CoordY.ToString();
                txtLargura.Text = bagua[i].Largura.ToString();
                txtProfundidade.Text = bagua[i].Profundidade.ToString();
                dtpDataRotura.Value = bagua[i].DataRotura;
                txtHorasReparacao.Text = bagua[i].HorasReparacao.ToString();
                lblDados.Text = bagua[i].GetDados();
            }
            else
            {
                txtCoordX.Text = "";
                txtCoordY.Text = "";
                txtLargura.Text = "";
                txtProfundidade.Text = "";
                dtpDataRotura.Value = DateTime.MinValue;
                txtHorasReparacao.Text = "";
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
                MessageBox.Show("Ainda não existem buracos registados");

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
                MessageBox.Show("Ainda não existem buracos registados");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (i >= 0)
                if (i < bagua.Length - 1)
                {
                    i++;
                    ShowDados();
                }
                else
                    MessageBox.Show("Não pode passar para lá do último");
            else
                MessageBox.Show("Ainda não existem buracos registados");
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                i = bagua.Length - 1;
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem buracos registados");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BuracoAgua.BuracoAgua bv = new BuracoAgua.BuracoAgua()
            {
                CoordX = int.Parse(txtCoordX.Text),
                CoordY = int.Parse(txtCoordY.Text),
                Largura = int.Parse(txtLargura.Text),
                Profundidade = int.Parse(txtProfundidade.Text),
                DataRotura = dtpDataRotura.Value,
                HorasReparacao = int.Parse(txtHorasReparacao.Text)
            };
            Array.Resize<BuracoAgua.BuracoAgua>(ref bagua, bagua.Length + 1);
            i = bagua.Length - 1;
            bagua[i] = bv;
            ShowDados();
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                bagua[i].CoordX = int.Parse(txtCoordX.Text);
                bagua[i].CoordY = int.Parse(txtCoordY.Text);
                bagua[i].Largura = int.Parse(txtLargura.Text);
                bagua[i].Profundidade = int.Parse(txtProfundidade.Text);
                bagua[i].DataRotura = dtpDataRotura.Value;
                bagua[i].HorasReparacao = int.Parse(txtHorasReparacao.Text);
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem buracos registados");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                for (int j = i; j < bagua.Length - 2; j++)
                    bagua[j] = bagua[j + 1];
                Array.Resize<BuracoAgua.BuracoAgua>(ref bagua, bagua.Length - 1);
                if (i >= bagua.Length)
                    i = bagua.Length - 1;
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem buracos registados");
        }

        private void frmBuracoAgua_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMenu f = (frmMenu)this.Owner;
            f.bagua = this.bagua;
        }

        private void frmBuracoAgua_Shown(object sender, EventArgs e)
        {
            if (bagua.Length > 0)
            {
                i = 0;
                ShowDados();
            }
        }
    }
}
