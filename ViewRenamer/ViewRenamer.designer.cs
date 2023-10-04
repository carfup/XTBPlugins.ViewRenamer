namespace Carfup.XTBPlugins.ViewRenamer
{
    partial class ViewRenamer
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveViews = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPublish = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSavePublish = new System.Windows.Forms.ToolStripButton();
            this.dgvViewsToRename = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadEntities = new System.Windows.Forms.Button();
            this.lvEntities = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadViews = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRevertReplace = new System.Windows.Forms.Button();
            this.rbSelectedLines = new System.Windows.Forms.RadioButton();
            this.rbAllLines = new System.Windows.Forms.RadioButton();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLanguageReplace = new System.Windows.Forms.ComboBox();
            this.btnReplaceText = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbReplaceTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbReplaceFrom = new System.Windows.Forms.TextBox();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewsToRename)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbSaveViews,
            this.toolStripSeparator2,
            this.tsPublish,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tsbSavePublish});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1250, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = global::Carfup.XTBPlugins.Properties.Resources.close;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(28, 28);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSaveViews
            // 
            this.tsbSaveViews.Enabled = false;
            this.tsbSaveViews.Image = global::Carfup.XTBPlugins.Properties.Resources.save;
            this.tsbSaveViews.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveViews.Name = "tsbSaveViews";
            this.tsbSaveViews.Size = new System.Drawing.Size(59, 28);
            this.tsbSaveViews.Text = "Save";
            this.tsbSaveViews.Click += new System.EventHandler(this.tsbSaveViews_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsPublish
            // 
            this.tsPublish.Enabled = false;
            this.tsPublish.Image = global::Carfup.XTBPlugins.Properties.Resources.paper_plane;
            this.tsPublish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPublish.Name = "tsPublish";
            this.tsPublish.Size = new System.Drawing.Size(121, 28);
            this.tsPublish.Text = "Publish changes";
            this.tsPublish.Click += new System.EventHandler(this.tsPublish_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(671, 28);
            this.toolStripLabel1.Text = "<< In order to apply your changes, you need to Save and then Publish to make it v" +
    "isible to your users ! Or Save and Publish >>";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSavePublish
            // 
            this.tsbSavePublish.Enabled = false;
            this.tsbSavePublish.Image = global::Carfup.XTBPlugins.Properties.Resources.rocket;
            this.tsbSavePublish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSavePublish.Name = "tsbSavePublish";
            this.tsbSavePublish.Size = new System.Drawing.Size(124, 28);
            this.tsbSavePublish.Text = "Save and Publish";
            this.tsbSavePublish.Click += new System.EventHandler(this.tsbSavePublish_Click);
            // 
            // dgvViewsToRename
            // 
            this.dgvViewsToRename.AllowUserToAddRows = false;
            this.dgvViewsToRename.AllowUserToDeleteRows = false;
            this.dgvViewsToRename.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvViewsToRename.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewsToRename.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewsToRename.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvViewsToRename.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvViewsToRename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvViewsToRename.Location = new System.Drawing.Point(255, 87);
            this.dgvViewsToRename.Name = "dgvViewsToRename";
            this.dgvViewsToRename.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViewsToRename.Size = new System.Drawing.Size(989, 536);
            this.dgvViewsToRename.TabIndex = 7;
            this.dgvViewsToRename.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewsToRename_CellValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.84511F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.15489F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvViewsToRename, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1250, 629);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnLoadEntities, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lvEntities, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tbFilter, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 525F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(240, 617);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // btnLoadEntities
            // 
            this.btnLoadEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadEntities.Image = global::Carfup.XTBPlugins.Properties.Resources.load;
            this.btnLoadEntities.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadEntities.Location = new System.Drawing.Point(3, 3);
            this.btnLoadEntities.Name = "btnLoadEntities";
            this.btnLoadEntities.Size = new System.Drawing.Size(234, 44);
            this.btnLoadEntities.TabIndex = 13;
            this.btnLoadEntities.Text = "Load all Tables";
            this.btnLoadEntities.UseVisualStyleBackColor = true;
            this.btnLoadEntities.Click += new System.EventHandler(this.btnLoadEntities_Click);
            // 
            // lvEntities
            // 
            this.lvEntities.CheckBoxes = true;
            this.lvEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12});
            this.lvEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEntities.FullRowSelect = true;
            this.lvEntities.HideSelection = false;
            this.lvEntities.Location = new System.Drawing.Point(3, 80);
            this.lvEntities.MultiSelect = false;
            this.lvEntities.Name = "lvEntities";
            this.lvEntities.ShowGroups = false;
            this.lvEntities.Size = new System.Drawing.Size(234, 534);
            this.lvEntities.TabIndex = 11;
            this.lvEntities.UseCompatibleStateImageBehavior = false;
            this.lvEntities.View = System.Windows.Forms.View.Details;
            this.lvEntities.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvEntities_ColumnClick);
            this.lvEntities.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvEntities_ItemChecked);
            this.lvEntities.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvEntities_ItemSelectionChanged);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Tables";
            this.columnHeader12.Width = 300;
            // 
            // tbFilter
            // 
            this.tbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFilter.Location = new System.Drawing.Point(3, 53);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(234, 20);
            this.tbFilter.TabIndex = 9;
            this.tbFilter.Text = "Search in tables ...";
            this.tbFilter.Click += new System.EventHandler(this.tbFilter_Click);
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 795F));
            this.tableLayoutPanel2.Controls.Add(this.btnLoadViews, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(252, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(995, 78);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // btnLoadViews
            // 
            this.btnLoadViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadViews.Enabled = false;
            this.btnLoadViews.Image = global::Carfup.XTBPlugins.Properties.Resources.load;
            this.btnLoadViews.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadViews.Location = new System.Drawing.Point(3, 3);
            this.btnLoadViews.Name = "btnLoadViews";
            this.btnLoadViews.Size = new System.Drawing.Size(194, 72);
            this.btnLoadViews.TabIndex = 0;
            this.btnLoadViews.Text = "Load tables views";
            this.btnLoadViews.UseVisualStyleBackColor = true;
            this.btnLoadViews.Click += new System.EventHandler(this.btnLoadViews_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRevertReplace);
            this.groupBox1.Controls.Add(this.rbSelectedLines);
            this.groupBox1.Controls.Add(this.rbAllLines);
            this.groupBox1.Controls.Add(this.chkCaseSensitive);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbLanguageReplace);
            this.groupBox1.Controls.Add(this.btnReplaceText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbReplaceTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbReplaceFrom);
            this.groupBox1.Location = new System.Drawing.Point(203, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(789, 70);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replace";
            // 
            // btnRevertReplace
            // 
            this.btnRevertReplace.Image = global::Carfup.XTBPlugins.Properties.Resources.revert;
            this.btnRevertReplace.Location = new System.Drawing.Point(330, 21);
            this.btnRevertReplace.Name = "btnRevertReplace";
            this.btnRevertReplace.Size = new System.Drawing.Size(24, 45);
            this.btnRevertReplace.TabIndex = 15;
            this.btnRevertReplace.UseVisualStyleBackColor = true;
            this.btnRevertReplace.Click += new System.EventHandler(this.btnRevertReplace_Click);
            // 
            // rbSelectedLines
            // 
            this.rbSelectedLines.AutoSize = true;
            this.rbSelectedLines.Location = new System.Drawing.Point(524, 45);
            this.rbSelectedLines.Name = "rbSelectedLines";
            this.rbSelectedLines.Size = new System.Drawing.Size(91, 17);
            this.rbSelectedLines.TabIndex = 14;
            this.rbSelectedLines.Text = "Selected lines";
            this.rbSelectedLines.UseVisualStyleBackColor = true;
            this.rbSelectedLines.CheckedChanged += new System.EventHandler(this.rbSelectedLines_CheckedChanged);
            // 
            // rbAllLines
            // 
            this.rbAllLines.AutoSize = true;
            this.rbAllLines.Checked = true;
            this.rbAllLines.Location = new System.Drawing.Point(524, 22);
            this.rbAllLines.Name = "rbAllLines";
            this.rbAllLines.Size = new System.Drawing.Size(60, 17);
            this.rbAllLines.TabIndex = 13;
            this.rbAllLines.TabStop = true;
            this.rbAllLines.Text = "All lines";
            this.rbAllLines.UseVisualStyleBackColor = true;
            this.rbAllLines.CheckedChanged += new System.EventHandler(this.rbAllLines_CheckedChanged);
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Checked = true;
            this.chkCaseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaseSensitive.Location = new System.Drawing.Point(368, 23);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(96, 17);
            this.chkCaseSensitive.TabIndex = 12;
            this.chkCaseSensitive.Text = "Case Sensitive";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Language :";
            // 
            // cbLanguageReplace
            // 
            this.cbLanguageReplace.FormattingEnabled = true;
            this.cbLanguageReplace.Items.AddRange(new object[] {
            "All"});
            this.cbLanguageReplace.Location = new System.Drawing.Point(428, 43);
            this.cbLanguageReplace.Name = "cbLanguageReplace";
            this.cbLanguageReplace.Size = new System.Drawing.Size(83, 21);
            this.cbLanguageReplace.TabIndex = 8;
            // 
            // btnReplaceText
            // 
            this.btnReplaceText.Enabled = false;
            this.btnReplaceText.Image = global::Carfup.XTBPlugins.Properties.Resources.find;
            this.btnReplaceText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReplaceText.Location = new System.Drawing.Point(622, 13);
            this.btnReplaceText.Name = "btnReplaceText";
            this.btnReplaceText.Size = new System.Drawing.Size(162, 51);
            this.btnReplaceText.TabIndex = 7;
            this.btnReplaceText.Text = "Replace";
            this.btnReplaceText.UseVisualStyleBackColor = true;
            this.btnReplaceText.Click += new System.EventHandler(this.btnReplaceText_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "To :";
            // 
            // tbReplaceTo
            // 
            this.tbReplaceTo.Location = new System.Drawing.Point(49, 46);
            this.tbReplaceTo.Name = "tbReplaceTo";
            this.tbReplaceTo.Size = new System.Drawing.Size(272, 20);
            this.tbReplaceTo.TabIndex = 5;
            this.tbReplaceTo.TextChanged += new System.EventHandler(this.tbReplaceTo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "From :";
            // 
            // tbReplaceFrom
            // 
            this.tbReplaceFrom.Location = new System.Drawing.Point(49, 20);
            this.tbReplaceFrom.Name = "tbReplaceFrom";
            this.tbReplaceFrom.Size = new System.Drawing.Size(272, 20);
            this.tbReplaceFrom.TabIndex = 3;
            this.tbReplaceFrom.TextChanged += new System.EventHandler(this.tbReplaceFrom_TextChanged);
            // 
            // ViewRenamer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "ViewRenamer";
            this.Size = new System.Drawing.Size(1250, 660);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewsToRename)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.DataGridView dgvViewsToRename;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripButton tsbSaveViews;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsPublish;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnLoadViews;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReplaceText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbReplaceTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbReplaceFrom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListView lvEntities;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLanguageReplace;
        private System.Windows.Forms.Button btnLoadEntities;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private System.Windows.Forms.RadioButton rbSelectedLines;
        private System.Windows.Forms.RadioButton rbAllLines;
        private System.Windows.Forms.Button btnRevertReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbSavePublish;
    }
}
