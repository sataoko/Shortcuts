namespace Shortcuts.WorkHours
{
    partial class frmWorkHours
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkHours));
            this.dgvWorkHours = new System.Windows.Forms.DataGridView();
            this.BlockStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlockEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlockNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlockGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlockNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExportToCSV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDeleteAll = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkHours)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvWorkHours
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvWorkHours.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkHours.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvWorkHours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWorkHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkHours.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BlockStartTime,
            this.BlockEndTime,
            this.BlockNo,
            this.BlockGroup,
            this.BlockNote});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkHours.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorkHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkHours.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvWorkHours.Location = new System.Drawing.Point(0, 25);
            this.dgvWorkHours.Name = "dgvWorkHours";
            this.dgvWorkHours.Size = new System.Drawing.Size(971, 503);
            this.dgvWorkHours.TabIndex = 0;
            // 
            // BlockStartTime
            // 
            this.BlockStartTime.HeaderText = "StartTime";
            this.BlockStartTime.Name = "BlockStartTime";
            this.BlockStartTime.Width = 150;
            // 
            // BlockEndTime
            // 
            this.BlockEndTime.HeaderText = "EndTime";
            this.BlockEndTime.Name = "BlockEndTime";
            this.BlockEndTime.Width = 150;
            // 
            // BlockNo
            // 
            this.BlockNo.HeaderText = "BlockNo";
            this.BlockNo.Name = "BlockNo";
            // 
            // BlockGroup
            // 
            this.BlockGroup.HeaderText = "BlockGroup";
            this.BlockGroup.Name = "BlockGroup";
            this.BlockGroup.Width = 200;
            // 
            // BlockNote
            // 
            this.BlockNote.HeaderText = "BlockNote";
            this.BlockNote.Name = "BlockNote";
            this.BlockNote.Width = 300;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExportToCSV,
            this.toolStripSeparator1,
            this.tsbDeleteAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(971, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbExportToCSV
            // 
            this.tsbExportToCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExportToCSV.Image = ((System.Drawing.Image)(resources.GetObject("tsbExportToCSV.Image")));
            this.tsbExportToCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportToCSV.Name = "tsbExportToCSV";
            this.tsbExportToCSV.Size = new System.Drawing.Size(84, 22);
            this.tsbExportToCSV.Text = "Export To CSV";
            this.tsbExportToCSV.Click += new System.EventHandler(this.tsbExportToCSV_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDeleteAll
            // 
            this.tsbDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteAll.Image")));
            this.tsbDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteAll.Name = "tsbDeleteAll";
            this.tsbDeleteAll.Size = new System.Drawing.Size(61, 22);
            this.tsbDeleteAll.Text = "Delete All";
            this.tsbDeleteAll.Click += new System.EventHandler(this.tsbDeleteAll_Click);
            // 
            // frmWorkHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 528);
            this.Controls.Add(this.dgvWorkHours);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWorkHours";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Work Hours";
            this.Load += new System.EventHandler(this.frmWorkHours_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkHours)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkHours;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbDeleteAll;
        private System.Windows.Forms.ToolStripButton tsbExportToCSV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockNote;
    }
}