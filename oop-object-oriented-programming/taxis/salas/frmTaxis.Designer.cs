
using System.Windows.Forms;

namespace Taxis
{
    partial class frmTaxi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNºTaxi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCapacidade = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbOcupada = new System.Windows.Forms.RadioButton();
            this.rbDesocupado = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAlt = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnLista = new System.Windows.Forms.Button();
            this.ofdImport = new System.Windows.Forms.OpenFileDialog();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.txtCombustivel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº do taxi";
            // 
            // txtCodTaxi
            // 
            this.txtNºTaxi.Location = new System.Drawing.Point(103, 26);
            this.txtNºTaxi.Name = "txtCodTaxi";
            this.txtNºTaxi.Size = new System.Drawing.Size(69, 20);
            this.txtNºTaxi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Capacidade";
            // 
            // txtCapacidade
            // 
            this.txtCapacidade.Location = new System.Drawing.Point(103, 86);
            this.txtCapacidade.Name = "txtCapacidade";
            this.txtCapacidade.Size = new System.Drawing.Size(150, 20);
            this.txtCapacidade.TabIndex = 5;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(103, 56);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(150, 20);
            this.txtMatricula.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Matrícula";
            // 
            // rbOcupada
            // 
            this.rbOcupada.AutoSize = true;
            this.rbOcupada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbOcupada.Location = new System.Drawing.Point(36, 168);
            this.rbOcupada.Name = "rbOcupada";
            this.rbOcupada.Size = new System.Drawing.Size(69, 17);
            this.rbOcupada.TabIndex = 8;
            this.rbOcupada.TabStop = true;
            this.rbOcupada.Text = "Ocupado";
            this.rbOcupada.UseVisualStyleBackColor = true;
            this.rbOcupada.CheckedChanged += new System.EventHandler(this.rbChanged);
            // 
            // rbDesocupado
            // 
            this.rbDesocupado.AutoSize = true;
            this.rbDesocupado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbDesocupado.Location = new System.Drawing.Point(167, 168);
            this.rbDesocupado.Name = "rbDesocupado";
            this.rbDesocupado.Size = new System.Drawing.Size(86, 17);
            this.rbDesocupado.TabIndex = 9;
            this.rbDesocupado.TabStop = true;
            this.rbDesocupado.Text = "Desocupado";
            this.rbDesocupado.UseVisualStyleBackColor = true;
            this.rbDesocupado.CheckedChanged += new System.EventHandler(this.rbChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(24, 222);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Novo Taxi";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAlt
            // 
            this.btnAlt.Location = new System.Drawing.Point(106, 222);
            this.btnAlt.Name = "btnAlt";
            this.btnAlt.Size = new System.Drawing.Size(75, 23);
            this.btnAlt.TabIndex = 11;
            this.btnAlt.Text = "Alterar Taxi";
            this.btnAlt.UseVisualStyleBackColor = true;
            this.btnAlt.Click += new System.EventHandler(this.btnAlt_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(188, 221);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 12;
            this.btnDel.Text = "Apagar Taxi";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(24, 263);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(39, 23);
            this.btnFirst.TabIndex = 13;
            this.btnFirst.Text = "|<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(90, 263);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(39, 23);
            this.btnPrev.TabIndex = 14;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(156, 263);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(39, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(222, 263);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(39, 23);
            this.btnLast.TabIndex = 16;
            this.btnLast.Text = ">|";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnLista
            // 
            this.btnLista.Location = new System.Drawing.Point(90, 305);
            this.btnLista.Name = "btnLista";
            this.btnLista.Size = new System.Drawing.Size(105, 23);
            this.btnLista.TabIndex = 17;
            this.btnLista.Text = "Lista";
            this.btnLista.UseVisualStyleBackColor = true;
            this.btnLista.Click += new System.EventHandler(this.btnLista_Click);
            // 
            // ofdImport
            // 
            this.ofdImport.FileName = "salas.txt";
            this.ofdImport.Filter = "Todos os ficheiros (*.*)|*.*|Ficheiros de Texto (*.txt)|*.txt";
            this.ofdImport.FilterIndex = 2;
            // 
            // sfdExport
            // 
            this.sfdExport.FileName = "salas.txt";
            this.sfdExport.Filter = "Todos os ficheiros (*.*)|*.*|Ficheiros de Texto (*.txt)|*.txt";
            this.sfdExport.FilterIndex = 2;
            // 
            // txtCombustivel
            // 
            this.txtCombustivel.Location = new System.Drawing.Point(103, 121);
            this.txtCombustivel.Name = "txtCombustivel";
            this.txtCombustivel.Size = new System.Drawing.Size(150, 20);
            this.txtCombustivel.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Combustível";
            // 
            // frmTaxi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 354);
            this.Controls.Add(this.txtCombustivel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLista);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAlt);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rbDesocupado);
            this.Controls.Add(this.rbOcupada);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCapacidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNºTaxi);
            this.Controls.Add(this.label1);
            this.Name = "frmTaxi";
            this.Text = "Salas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNºTaxi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCapacidade;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbOcupada;
        private System.Windows.Forms.RadioButton rbDesocupado;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAlt;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnLista;
        private System.Windows.Forms.OpenFileDialog ofdImport;
        private System.Windows.Forms.SaveFileDialog sfdExport;
        private System.Windows.Forms.TextBox txtCombustivel;
        private System.Windows.Forms.Label label4;
    }
}

