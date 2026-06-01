
namespace AppBuracos
{
    partial class frmMenu
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
            this.btnBuracoVia = new System.Windows.Forms.Button();
            this.btnBuracoAgua = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuracoVia
            // 
            this.btnBuracoVia.Location = new System.Drawing.Point(24, 12);
            this.btnBuracoVia.Name = "btnBuracoVia";
            this.btnBuracoVia.Size = new System.Drawing.Size(135, 35);
            this.btnBuracoVia.TabIndex = 0;
            this.btnBuracoVia.Text = "Buracos da via pública";
            this.btnBuracoVia.UseVisualStyleBackColor = true;
            this.btnBuracoVia.Click += new System.EventHandler(this.btnBuracoVia_Click);
            // 
            // btnBuracoAgua
            // 
            this.btnBuracoAgua.Location = new System.Drawing.Point(24, 55);
            this.btnBuracoAgua.Name = "btnBuracoAgua";
            this.btnBuracoAgua.Size = new System.Drawing.Size(135, 35);
            this.btnBuracoAgua.TabIndex = 1;
            this.btnBuracoAgua.Text = "Buracos de Água";
            this.btnBuracoAgua.UseVisualStyleBackColor = true;
            this.btnBuracoAgua.Click += new System.EventHandler(this.btnBuracoAgua_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 131);
            this.Controls.Add(this.btnBuracoAgua);
            this.Controls.Add(this.btnBuracoVia);
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuracoVia;
        private System.Windows.Forms.Button btnBuracoAgua;
    }
}

