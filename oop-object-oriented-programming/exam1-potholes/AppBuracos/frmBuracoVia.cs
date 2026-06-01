using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuracoVia;

namespace AppBuracos
{
    public partial class frmBuracoVia : Form
    {
        public BuracoVia.BuracoVia[] bvia;
        int i = -1;
        public frmBuracoVia()
        {
            InitializeComponent();
        }

        private void ShowDados()
        {
            if (i>=0)
            {
                txtCoordX.Text = bvia[i].CoordX.ToString();
                txtCoordY.Text = bvia[i].CoordY.ToString();
                txtLargura.Text = bvia[i].Largura.ToString();
                txtProfundidade.Text = bvia[i].Profundidade.ToString();
                dtpDataParticipacao.Value = bvia[i].DataParticipacao;
                dtpDataReparacao.Value = bvia[i].DataReparacao;
                lblDados.Text = bvia[i].GetDados();
            }
            else
            {
                txtCoordX.Text = "";
                txtCoordY.Text = "";
                txtLargura.Text = "";
                txtProfundidade.Text = "";
                dtpDataParticipacao.Value = DateTime.MinValue;
                dtpDataReparacao.Value = DateTime.MinValue;
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
                if (i < bvia.Length - 1)
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
                i = bvia.Length - 1;
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem buracos registados");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BuracoVia.BuracoVia bv = new BuracoVia.BuracoVia()
            {
                CoordX = int.Parse(txtCoordX.Text),
                CoordY = int.Parse(txtCoordY.Text),
                Largura = int.Parse(txtLargura.Text),
                Profundidade = int.Parse(txtProfundidade.Text),
                DataParticipacao = dtpDataParticipacao.Value,
                DataReparacao = dtpDataReparacao.Value
            };
            Array.Resize<BuracoVia.BuracoVia>(ref bvia, bvia.Length + 1);
            i = bvia.Length - 1;
            bvia[i] = bv;
            ShowDados();
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                bvia[i].CoordX = int.Parse(txtCoordX.Text);
                bvia[i].CoordY = int.Parse(txtCoordY.Text);
                bvia[i].Largura = int.Parse(txtLargura.Text);
                bvia[i].Profundidade = int.Parse(txtProfundidade.Text);
                bvia[i].DataParticipacao = dtpDataParticipacao.Value;
                bvia[i].DataReparacao = dtpDataReparacao.Value;
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem buracos registados");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (i >= 0)
            {
                for (int j = i; j < bvia.Length - 2; j++)
                    bvia[j] = bvia[j + 1];
                Array.Resize<BuracoVia.BuracoVia>(ref bvia, bvia.Length - 1);
                if (i >= bvia.Length)
                    i = bvia.Length - 1;
                ShowDados();
            }
            else
                MessageBox.Show("Ainda não existem buracos registados");
        }

        private void frmBuracoVia_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMenu f = (frmMenu)this.Owner;
            f.bvia = this.bvia;
        }

        private void frmBuracoVia_Shown(object sender, EventArgs e)
        {
            if (bvia.Length > 0)
            {
                i = 0;
                ShowDados();
            }
        }
    }
}
