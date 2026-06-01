using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buraco;
using BuracoVia;
using BuracoAgua;


namespace AppBuracos
{
    public partial class frmMenu : Form
    {
        public BuracoVia.BuracoVia[] bvia = new BuracoVia.BuracoVia[] { };
        public BuracoAgua.BuracoAgua[] bagua = new BuracoAgua.BuracoAgua[] { };
        
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
            frm.bvia = this.bvia;
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
            frm.bagua = this.bagua;
            frm.Show(this);
        }
    }
}
