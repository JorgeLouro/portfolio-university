using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDEx4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void investigadorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.investigadorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._13000375_Ex4DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_13000375_Ex4DataSet.Grau' table. You can move, or remove it, as needed.
            this.grauTableAdapter.Fill(this._13000375_Ex4DataSet.Grau);
            // TODO: This line of code loads data into the '_13000375_Ex4DataSet.Contacto' table. You can move, or remove it, as needed.
            this.contactoTableAdapter.Fill(this._13000375_Ex4DataSet.Contacto);
            // TODO: This line of code loads data into the '_13000375_Ex4DataSet.Investigador' table. You can move, or remove it, as needed.
            this.investigadorTableAdapter.Fill(this._13000375_Ex4DataSet.Investigador);

        }

        private void contactoDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (!string.IsNullOrEmpty(numeroTextBox.Text))
                e.Row.Cells[0].Value = numeroTextBox.Text;
        }
    }
}
