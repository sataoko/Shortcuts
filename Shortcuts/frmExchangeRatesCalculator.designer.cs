namespace Shortcuts
{
    partial class frmExchangeRatesCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExchangeRatesCalculator));
            this.lvExchangeRates = new System.Windows.Forms.ListView();
            this.txtValueToConvert = new System.Windows.Forms.TextBox();
            this.txtConvertedValue = new System.Windows.Forms.TextBox();
            this.txtVATAddedValue2 = new System.Windows.Forms.TextBox();
            this.lblKDV = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSterlin1 = new System.Windows.Forms.RadioButton();
            this.rbDollar1 = new System.Windows.Forms.RadioButton();
            this.rbEuro1 = new System.Windows.Forms.RadioButton();
            this.rbYTL1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbDollar2 = new System.Windows.Forms.RadioButton();
            this.rbSterlin2 = new System.Windows.Forms.RadioButton();
            this.rbEuro2 = new System.Windows.Forms.RadioButton();
            this.rbYTL2 = new System.Windows.Forms.RadioButton();
            this.lblEquals = new System.Windows.Forms.Label();
            this.lblCurrency2 = new System.Windows.Forms.Label();
            this.lblCurrency1 = new System.Windows.Forms.Label();
            this.txtVAT1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVAT2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVATAddedValue1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvExchangeRates
            // 
            this.lvExchangeRates.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvExchangeRates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvExchangeRates.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvExchangeRates.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lvExchangeRates.FullRowSelect = true;
            this.lvExchangeRates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvExchangeRates.LabelWrap = false;
            this.lvExchangeRates.Location = new System.Drawing.Point(0, 0);
            this.lvExchangeRates.Name = "lvExchangeRates";
            this.lvExchangeRates.Size = new System.Drawing.Size(484, 145);
            this.lvExchangeRates.TabIndex = 7;
            this.lvExchangeRates.UseCompatibleStateImageBehavior = false;
            this.lvExchangeRates.View = System.Windows.Forms.View.Details;
            // 
            // txtValueToConvert
            // 
            this.txtValueToConvert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValueToConvert.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtValueToConvert.Location = new System.Drawing.Point(58, 203);
            this.txtValueToConvert.Name = "txtValueToConvert";
            this.txtValueToConvert.Size = new System.Drawing.Size(132, 30);
            this.txtValueToConvert.TabIndex = 8;
            this.txtValueToConvert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValueToConvert.TextChanged += new System.EventHandler(this.txtValueToConvert_TextChanged);
            // 
            // txtConvertedValue
            // 
            this.txtConvertedValue.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtConvertedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConvertedValue.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtConvertedValue.Location = new System.Drawing.Point(272, 205);
            this.txtConvertedValue.Name = "txtConvertedValue";
            this.txtConvertedValue.ReadOnly = true;
            this.txtConvertedValue.Size = new System.Drawing.Size(132, 30);
            this.txtConvertedValue.TabIndex = 8;
            this.txtConvertedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVATAddedValue2
            // 
            this.txtVATAddedValue2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtVATAddedValue2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVATAddedValue2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtVATAddedValue2.Location = new System.Drawing.Point(304, 282);
            this.txtVATAddedValue2.Name = "txtVATAddedValue2";
            this.txtVATAddedValue2.ReadOnly = true;
            this.txtVATAddedValue2.Size = new System.Drawing.Size(100, 30);
            this.txtVATAddedValue2.TabIndex = 8;
            this.txtVATAddedValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblKDV
            // 
            this.lblKDV.AutoSize = true;
            this.lblKDV.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKDV.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblKDV.Location = new System.Drawing.Point(226, 284);
            this.lblKDV.Name = "lblKDV";
            this.lblKDV.Size = new System.Drawing.Size(72, 23);
            this.lblKDV.TabIndex = 10;
            this.lblKDV.Text = "Toplam";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSterlin1);
            this.groupBox1.Controls.Add(this.rbDollar1);
            this.groupBox1.Controls.Add(this.rbEuro1);
            this.groupBox1.Controls.Add(this.rbYTL1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(9, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 46);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // rbSterlin1
            // 
            this.rbSterlin1.AutoSize = true;
            this.rbSterlin1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbSterlin1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbSterlin1.Location = new System.Drawing.Point(166, 16);
            this.rbSterlin1.Name = "rbSterlin1";
            this.rbSterlin1.Size = new System.Drawing.Size(62, 20);
            this.rbSterlin1.TabIndex = 12;
            this.rbSterlin1.Text = "Sterlin";
            this.rbSterlin1.UseVisualStyleBackColor = true;
            this.rbSterlin1.CheckedChanged += new System.EventHandler(this.rbSterlin1_CheckedChanged);
            // 
            // rbDollar1
            // 
            this.rbDollar1.AutoSize = true;
            this.rbDollar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbDollar1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbDollar1.Location = new System.Drawing.Point(111, 16);
            this.rbDollar1.Name = "rbDollar1";
            this.rbDollar1.Size = new System.Drawing.Size(55, 20);
            this.rbDollar1.TabIndex = 11;
            this.rbDollar1.Text = "Dolar";
            this.rbDollar1.UseVisualStyleBackColor = true;
            this.rbDollar1.CheckedChanged += new System.EventHandler(this.rbDollar1_CheckedChanged);
            // 
            // rbEuro1
            // 
            this.rbEuro1.AutoSize = true;
            this.rbEuro1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbEuro1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbEuro1.Location = new System.Drawing.Point(59, 16);
            this.rbEuro1.Name = "rbEuro1";
            this.rbEuro1.Size = new System.Drawing.Size(52, 20);
            this.rbEuro1.TabIndex = 11;
            this.rbEuro1.Text = "Euro";
            this.rbEuro1.UseVisualStyleBackColor = true;
            this.rbEuro1.CheckedChanged += new System.EventHandler(this.rbEURO1_CheckedChanged);
            // 
            // rbYTL1
            // 
            this.rbYTL1.AutoSize = true;
            this.rbYTL1.Checked = true;
            this.rbYTL1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbYTL1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbYTL1.Location = new System.Drawing.Point(11, 16);
            this.rbYTL1.Name = "rbYTL1";
            this.rbYTL1.Size = new System.Drawing.Size(39, 20);
            this.rbYTL1.TabIndex = 10;
            this.rbYTL1.TabStop = true;
            this.rbYTL1.Text = "TL";
            this.rbYTL1.UseVisualStyleBackColor = true;
            this.rbYTL1.CheckedChanged += new System.EventHandler(this.rbYTL1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbDollar2);
            this.groupBox2.Controls.Add(this.rbSterlin2);
            this.groupBox2.Controls.Add(this.rbEuro2);
            this.groupBox2.Controls.Add(this.rbYTL2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(245, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 46);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // rbDollar2
            // 
            this.rbDollar2.AutoSize = true;
            this.rbDollar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbDollar2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbDollar2.Location = new System.Drawing.Point(107, 16);
            this.rbDollar2.Name = "rbDollar2";
            this.rbDollar2.Size = new System.Drawing.Size(55, 20);
            this.rbDollar2.TabIndex = 15;
            this.rbDollar2.Text = "Dolar";
            this.rbDollar2.UseVisualStyleBackColor = true;
            this.rbDollar2.CheckedChanged += new System.EventHandler(this.rbDollar2_CheckedChanged);
            // 
            // rbSterlin2
            // 
            this.rbSterlin2.AutoSize = true;
            this.rbSterlin2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbSterlin2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbSterlin2.Location = new System.Drawing.Point(162, 16);
            this.rbSterlin2.Name = "rbSterlin2";
            this.rbSterlin2.Size = new System.Drawing.Size(62, 20);
            this.rbSterlin2.TabIndex = 14;
            this.rbSterlin2.Text = "Sterlin";
            this.rbSterlin2.UseVisualStyleBackColor = true;
            this.rbSterlin2.CheckedChanged += new System.EventHandler(this.rbSterlin2_CheckedChanged);
            // 
            // rbEuro2
            // 
            this.rbEuro2.AutoSize = true;
            this.rbEuro2.Checked = true;
            this.rbEuro2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbEuro2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbEuro2.Location = new System.Drawing.Point(55, 16);
            this.rbEuro2.Name = "rbEuro2";
            this.rbEuro2.Size = new System.Drawing.Size(52, 20);
            this.rbEuro2.TabIndex = 12;
            this.rbEuro2.TabStop = true;
            this.rbEuro2.Text = "Euro";
            this.rbEuro2.UseVisualStyleBackColor = true;
            this.rbEuro2.CheckedChanged += new System.EventHandler(this.rbEuro2_CheckedChanged);
            // 
            // rbYTL2
            // 
            this.rbYTL2.AutoSize = true;
            this.rbYTL2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbYTL2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbYTL2.Location = new System.Drawing.Point(7, 16);
            this.rbYTL2.Name = "rbYTL2";
            this.rbYTL2.Size = new System.Drawing.Size(39, 20);
            this.rbYTL2.TabIndex = 13;
            this.rbYTL2.Text = "TL";
            this.rbYTL2.UseVisualStyleBackColor = true;
            this.rbYTL2.CheckedChanged += new System.EventHandler(this.rbYTL2_CheckedChanged);
            // 
            // lblEquals
            // 
            this.lblEquals.AutoSize = true;
            this.lblEquals.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEquals.Location = new System.Drawing.Point(246, 207);
            this.lblEquals.Name = "lblEquals";
            this.lblEquals.Size = new System.Drawing.Size(24, 23);
            this.lblEquals.TabIndex = 10;
            this.lblEquals.Text = "=";
            // 
            // lblCurrency2
            // 
            this.lblCurrency2.AutoSize = true;
            this.lblCurrency2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCurrency2.Location = new System.Drawing.Point(405, 211);
            this.lblCurrency2.Name = "lblCurrency2";
            this.lblCurrency2.Size = new System.Drawing.Size(37, 18);
            this.lblCurrency2.TabIndex = 10;
            this.lblCurrency2.Text = "Euro";
            // 
            // lblCurrency1
            // 
            this.lblCurrency1.AutoSize = true;
            this.lblCurrency1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCurrency1.Location = new System.Drawing.Point(191, 209);
            this.lblCurrency1.Name = "lblCurrency1";
            this.lblCurrency1.Size = new System.Drawing.Size(25, 18);
            this.lblCurrency1.TabIndex = 10;
            this.lblCurrency1.Text = "TL";
            // 
            // txtVAT1
            // 
            this.txtVAT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVAT1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtVAT1.Location = new System.Drawing.Point(90, 246);
            this.txtVAT1.Name = "txtVAT1";
            this.txtVAT1.ReadOnly = true;
            this.txtVAT1.Size = new System.Drawing.Size(100, 30);
            this.txtVAT1.TabIndex = 8;
            this.txtVAT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.BlueViolet;
            this.label1.Location = new System.Drawing.Point(39, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "KDV";
            // 
            // txtVAT2
            // 
            this.txtVAT2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtVAT2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVAT2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtVAT2.Location = new System.Drawing.Point(304, 246);
            this.txtVAT2.Name = "txtVAT2";
            this.txtVAT2.ReadOnly = true;
            this.txtVAT2.Size = new System.Drawing.Size(100, 30);
            this.txtVAT2.TabIndex = 8;
            this.txtVAT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.BlueViolet;
            this.label2.Location = new System.Drawing.Point(253, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "KDV";
            // 
            // txtVATAddedValue1
            // 
            this.txtVATAddedValue1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVATAddedValue1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtVATAddedValue1.Location = new System.Drawing.Point(90, 282);
            this.txtVATAddedValue1.Name = "txtVATAddedValue1";
            this.txtVATAddedValue1.ReadOnly = true;
            this.txtVATAddedValue1.Size = new System.Drawing.Size(100, 30);
            this.txtVATAddedValue1.TabIndex = 8;
            this.txtVATAddedValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(12, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Toplam";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(6, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Dönüşümlerde satış fiyatı referans alınmıştır.";
            // 
            // frmExchangeRatesCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEquals);
            this.Controls.Add(this.lblCurrency1);
            this.Controls.Add(this.lblCurrency2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblKDV);
            this.Controls.Add(this.txtVATAddedValue1);
            this.Controls.Add(this.txtVAT1);
            this.Controls.Add(this.txtVAT2);
            this.Controls.Add(this.txtVATAddedValue2);
            this.Controls.Add(this.txtConvertedValue);
            this.Controls.Add(this.txtValueToConvert);
            this.Controls.Add(this.lvExchangeRates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExchangeRatesCalculator";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: TCMB Günün Döviz Kurları";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmExchangeRates_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvExchangeRates;
        private System.Windows.Forms.TextBox txtValueToConvert;
        private System.Windows.Forms.TextBox txtConvertedValue;
        private System.Windows.Forms.TextBox txtVATAddedValue2;
        private System.Windows.Forms.Label lblKDV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSterlin1;
        private System.Windows.Forms.RadioButton rbEuro1;
        private System.Windows.Forms.RadioButton rbYTL1;
        private System.Windows.Forms.RadioButton rbDollar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbDollar2;
        private System.Windows.Forms.RadioButton rbSterlin2;
        private System.Windows.Forms.RadioButton rbEuro2;
        private System.Windows.Forms.RadioButton rbYTL2;
        private System.Windows.Forms.Label lblEquals;
        private System.Windows.Forms.Label lblCurrency2;
        private System.Windows.Forms.Label lblCurrency1;
        private System.Windows.Forms.TextBox txtVAT1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVAT2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVATAddedValue1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}