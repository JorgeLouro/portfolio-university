using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Terceiros;
using Sócios;
using Utilizadores;


namespace appTaxis
{
    public partial class frmMenu : Form
    {
        public Sócios.Sócios[] bvia = new Sócios.Sócios[] { };
        public Utilizadores.Utilizadores[] bagua = new Utilizadores.Utilizadores[] { };
        
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnBuracoVia_Click(object sender, EventArgs e)
        {
            foreach(Form f in this.OwnedForms)
                if (f.Name == "frmBuracoVia")
                {
                    f.Activate();
                    return;
                }
            frmBuracoVia frm = new frmBuracoVia();
            frm.Taxis = this.bvia;
            frm.Show(this);

        }

        private void btnBuracoAgua_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.OwnedForms)
                if (f.Name == "frmBuracoAgua")
                {
                    f.Activate();
                    return;
                }
            frmBuracoAgua frm = new frmBuracoAgua();
            frm.Taxis = this.bagua;
            frm.Show(this);
        }
    }
}
