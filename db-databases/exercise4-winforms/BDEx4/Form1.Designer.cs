namespace BDEx4
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label numeroLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label moradaLabel;
            System.Windows.Forms.Label codPostalLabel;
            System.Windows.Forms.Label localidadeLabel;
            System.Windows.Forms.Label dataAdmissaoLabel;
            System.Windows.Forms.Label numContribuinteLabel;
            System.Windows.Forms.Label grauAcademicoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._13000375_Ex4DataSet = new BDEx4._13000375_Ex4DataSet();
            this.investigadorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.investigadorTableAdapter = new BDEx4._13000375_Ex4DataSetTableAdapters.InvestigadorTableAdapter();
            this.tableAdapterManager = new BDEx4._13000375_Ex4DataSetTableAdapters.TableAdapterManager();
            this.contactoTableAdapter = new BDEx4._13000375_Ex4DataSetTableAdapters.ContactoTableAdapter();
            this.grauTableAdapter = new BDEx4._13000375_Ex4DataSetTableAdapters.GrauTableAdapter();
            this.investigadorBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.investigadorBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.numeroTextBox = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.moradaTextBox = new System.Windows.Forms.TextBox();
            this.codPostalTextBox = new System.Windows.Forms.TextBox();
            this.localidadeTextBox = new System.Windows.Forms.TextBox();
            this.dataAdmissaoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.numContribuinteTextBox = new System.Windows.Forms.TextBox();
            this.grauAcademicoComboBox = new System.Windows.Forms.ComboBox();
            this.grauBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            numeroLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            moradaLabel = new System.Windows.Forms.Label();
            codPostalLabel = new System.Windows.Forms.Label();
            localidadeLabel = new System.Windows.Forms.Label();
            dataAdmissaoLabel = new System.Windows.Forms.Label();
            numContribuinteLabel = new System.Windows.Forms.Label();
            grauAcademicoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._13000375_Ex4DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investigadorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investigadorBindingNavigator)).BeginInit();
            this.investigadorBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grauBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Location = new System.Drawing.Point(33, 35);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new System.Drawing.Size(47, 13);
            numeroLabel.TabIndex = 1;
            numeroLabel.Text = "Numero:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(33, 61);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(38, 13);
            nomeLabel.TabIndex = 3;
            nomeLabel.Text = "Nome:";
            // 
            // moradaLabel
            // 
            moradaLabel.AutoSize = true;
            moradaLabel.Location = new System.Drawing.Point(33, 87);
            moradaLabel.Name = "moradaLabel";
            moradaLabel.Size = new System.Drawing.Size(46, 13);
            moradaLabel.TabIndex = 5;
            moradaLabel.Text = "Morada:";
            // 
            // codPostalLabel
            // 
            codPostalLabel.AutoSize = true;
            codPostalLabel.Location = new System.Drawing.Point(33, 113);
            codPostalLabel.Name = "codPostalLabel";
            codPostalLabel.Size = new System.Drawing.Size(61, 13);
            codPostalLabel.TabIndex = 7;
            codPostalLabel.Text = "Cod Postal:";
            // 
            // localidadeLabel
            // 
            localidadeLabel.AutoSize = true;
            localidadeLabel.Location = new System.Drawing.Point(33, 139);
            localidadeLabel.Name = "localidadeLabel";
            localidadeLabel.Size = new System.Drawing.Size(62, 13);
            localidadeLabel.TabIndex = 9;
            localidadeLabel.Text = "Localidade:";
            // 
            // dataAdmissaoLabel
            // 
            dataAdmissaoLabel.AutoSize = true;
            dataAdmissaoLabel.Location = new System.Drawing.Point(33, 166);
            dataAdmissaoLabel.Name = "dataAdmissaoLabel";
            dataAdmissaoLabel.Size = new System.Drawing.Size(81, 13);
            dataAdmissaoLabel.TabIndex = 11;
            dataAdmissaoLabel.Text = "Data Admissao:";
            // 
            // numContribuinteLabel
            // 
            numContribuinteLabel.AutoSize = true;
            numContribuinteLabel.Location = new System.Drawing.Point(33, 191);
            numContribuinteLabel.Name = "numContribuinteLabel";
            numContribuinteLabel.Size = new System.Drawing.Size(91, 13);
            numContribuinteLabel.TabIndex = 13;
            numContribuinteLabel.Text = "Num Contribuinte:";
            // 
            // grauAcademicoLabel
            // 
            grauAcademicoLabel.AutoSize = true;
            grauAcademicoLabel.Location = new System.Drawing.Point(33, 217);
            grauAcademicoLabel.Name = "grauAcademicoLabel";
            grauAcademicoLabel.Size = new System.Drawing.Size(89, 13);
            grauAcademicoLabel.TabIndex = 15;
            grauAcademicoLabel.Text = "Grau Academico:";
            // 
            // _13000375_Ex4DataSet
            // 
            this._13000375_Ex4DataSet.DataSetName = "_13000375_Ex4DataSet";
            this._13000375_Ex4DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // investigadorBindingSource
            // 
            this.investigadorBindingSource.DataMember = "Investigador";
            this.investigadorBindingSource.DataSource = this._13000375_Ex4DataSet;
            // 
            // investigadorTableAdapter
            // 
            this.investigadorTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ContactoTableAdapter = this.contactoTableAdapter;
            this.tableAdapterManager.GrauTableAdapter = this.grauTableAdapter;
            this.tableAdapterManager.InvestigadorTableAdapter = this.investigadorTableAdapter;
            this.tableAdapterManager.UpdateOrder = BDEx4._13000375_Ex4DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // contactoTableAdapter
            // 
            this.contactoTableAdapter.ClearBeforeFill = true;
            // 
            // grauTableAdapter
            // 
            this.grauTableAdapter.ClearBeforeFill = true;
            // 
            // investigadorBindingNavigator
            // 
            this.investigadorBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.investigadorBindingNavigator.BindingSource = this.investigadorBindingSource;
            this.investigadorBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.investigadorBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.investigadorBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.investigadorBindingNavigatorSaveItem});
            this.investigadorBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.investigadorBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.investigadorBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.investigadorBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.investigadorBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.investigadorBindingNavigator.Name = "investigadorBindingNavigator";
            this.investigadorBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.investigadorBindingNavigator.Size = new System.Drawing.Size(459, 25);
            this.investigadorBindingNavigator.TabIndex = 0;
            this.investigadorBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // investigadorBindingNavigatorSaveItem
            // 
            this.investigadorBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.investigadorBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("investigadorBindingNavigatorSaveItem.Image")));
            this.investigadorBindingNavigatorSaveItem.Name = "investigadorBindingNavigatorSaveItem";
            this.investigadorBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.investigadorBindingNavigatorSaveItem.Text = "Save Data";
            this.investigadorBindingNavigatorSaveItem.Click += new System.EventHandler(this.investigadorBindingNavigatorSaveItem_Click);
            // 
            // numeroTextBox
            // 
            this.numeroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigadorBindingSource, "Numero", true));
            this.numeroTextBox.Location = new System.Drawing.Point(130, 32);
            this.numeroTextBox.Name = "numeroTextBox";
            this.numeroTextBox.Size = new System.Drawing.Size(200, 20);
            this.numeroTextBox.TabIndex = 2;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigadorBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(130, 58);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(200, 20);
            this.nomeTextBox.TabIndex = 4;
            // 
            // moradaTextBox
            // 
            this.moradaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigadorBindingSource, "Morada", true));
            this.moradaTextBox.Location = new System.Drawing.Point(130, 84);
            this.moradaTextBox.Name = "moradaTextBox";
            this.moradaTextBox.Size = new System.Drawing.Size(200, 20);
            this.moradaTextBox.TabIndex = 6;
            // 
            // codPostalTextBox
            // 
            this.codPostalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigadorBindingSource, "CodPostal", true));
            this.codPostalTextBox.Location = new System.Drawing.Point(130, 110);
            this.codPostalTextBox.Name = "codPostalTextBox";
            this.codPostalTextBox.Size = new System.Drawing.Size(200, 20);
            this.codPostalTextBox.TabIndex = 8;
            // 
            // localidadeTextBox
            // 
            this.localidadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigadorBindingSource, "Localidade", true));
            this.localidadeTextBox.Location = new System.Drawing.Point(130, 136);
            this.localidadeTextBox.Name = "localidadeTextBox";
            this.localidadeTextBox.Size = new System.Drawing.Size(200, 20);
            this.localidadeTextBox.TabIndex = 10;
            // 
            // dataAdmissaoDateTimePicker
            // 
            this.dataAdmissaoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.investigadorBindingSource, "DataAdmissao", true));
            this.dataAdmissaoDateTimePicker.Location = new System.Drawing.Point(130, 162);
            this.dataAdmissaoDateTimePicker.Name = "dataAdmissaoDateTimePicker";
            this.dataAdmissaoDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dataAdmissaoDateTimePicker.TabIndex = 12;
            // 
            // numContribuinteTextBox
            // 
            this.numContribuinteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigadorBindingSource, "NumContribuinte", true));
            this.numContribuinteTextBox.Location = new System.Drawing.Point(130, 188);
            this.numContribuinteTextBox.Name = "numContribuinteTextBox";
            this.numContribuinteTextBox.Size = new System.Drawing.Size(200, 20);
            this.numContribuinteTextBox.TabIndex = 14;
            // 
            // grauAcademicoComboBox
            // 
            this.grauAcademicoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.investigadorBindingSource, "GrauAcademico", true));
            this.grauAcademicoComboBox.DataSource = this.grauBindingSource;
            this.grauAcademicoComboBox.DisplayMember = "DesignacaoGrau";
            this.grauAcademicoComboBox.FormattingEnabled = true;
            this.grauAcademicoComboBox.Location = new System.Drawing.Point(130, 214);
            this.grauAcademicoComboBox.Name = "grauAcademicoComboBox";
            this.grauAcademicoComboBox.Size = new System.Drawing.Size(200, 21);
            this.grauAcademicoComboBox.TabIndex = 16;
            this.grauAcademicoComboBox.ValueMember = "GrauAcademico";
            // 
            // grauBindingSource
            // 
            this.grauBindingSource.DataMember = "Grau";
            this.grauBindingSource.DataSource = this._13000375_Ex4DataSet;
            // 
            // contactoBindingSource
            // 
            this.contactoBindingSource.DataMember = "FK_Contacto_Investigador";
            this.contactoBindingSource.DataSource = this.investigadorBindingSource;
            // 
            // contactoDataGridView
            // 
            this.contactoDataGridView.AutoGenerateColumns = false;
            this.contactoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contactoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.contactoDataGridView.DataSource = this.contactoBindingSource;
            this.contactoDataGridView.Location = new System.Drawing.Point(12, 272);
            this.contactoDataGridView.Name = "contactoDataGridView";
            this.contactoDataGridView.Size = new System.Drawing.Size(435, 220);
            this.contactoDataGridView.TabIndex = 17;
            this.contactoDataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.contactoDataGridView_DefaultValuesNeeded);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Numero";
            this.dataGridViewTextBoxColumn1.HeaderText = "Numero";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Universidade";
            this.dataGridViewTextBoxColumn2.HeaderText = "Universidade";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DataInicio";
            this.dataGridViewTextBoxColumn3.HeaderText = "DataInicio";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DataFim";
            this.dataGridViewTextBoxColumn4.HeaderText = "DataFim";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Telefone";
            this.dataGridViewTextBoxColumn5.HeaderText = "Telefone";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 529);
            this.Controls.Add(this.contactoDataGridView);
            this.Controls.Add(numeroLabel);
            this.Controls.Add(this.numeroTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(moradaLabel);
            this.Controls.Add(this.moradaTextBox);
            this.Controls.Add(codPostalLabel);
            this.Controls.Add(this.codPostalTextBox);
            this.Controls.Add(localidadeLabel);
            this.Controls.Add(this.localidadeTextBox);
            this.Controls.Add(dataAdmissaoLabel);
            this.Controls.Add(this.dataAdmissaoDateTimePicker);
            this.Controls.Add(numContribuinteLabel);
            this.Controls.Add(this.numContribuinteTextBox);
            this.Controls.Add(grauAcademicoLabel);
            this.Controls.Add(this.grauAcademicoComboBox);
            this.Controls.Add(this.investigadorBindingNavigator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._13000375_Ex4DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investigadorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investigadorBindingNavigator)).EndInit();
            this.investigadorBindingNavigator.ResumeLayout(false);
            this.investigadorBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grauBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _13000375_Ex4DataSet _13000375_Ex4DataSet;
        private System.Windows.Forms.BindingSource investigadorBindingSource;
        private _13000375_Ex4DataSetTableAdapters.InvestigadorTableAdapter investigadorTableAdapter;
        private _13000375_Ex4DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator investigadorBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton investigadorBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox numeroTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox moradaTextBox;
        private System.Windows.Forms.TextBox codPostalTextBox;
        private System.Windows.Forms.TextBox localidadeTextBox;
        private System.Windows.Forms.DateTimePicker dataAdmissaoDateTimePicker;
        private System.Windows.Forms.TextBox numContribuinteTextBox;
        private System.Windows.Forms.ComboBox grauAcademicoComboBox;
        private _13000375_Ex4DataSetTableAdapters.ContactoTableAdapter contactoTableAdapter;
        private System.Windows.Forms.BindingSource contactoBindingSource;
        private _13000375_Ex4DataSetTableAdapters.GrauTableAdapter grauTableAdapter;
        private System.Windows.Forms.DataGridView contactoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource grauBindingSource;
    }
}

