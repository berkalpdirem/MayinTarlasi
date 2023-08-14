namespace MayinTarlasi
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
            this.pnl_buttonPanel = new System.Windows.Forms.Panel();
            this.btn_Start = new System.Windows.Forms.Button();
            this.tb_MineCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSecond = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTimeWarning = new System.Windows.Forms.Label();
            this.lbl_Min = new System.Windows.Forms.Label();
            this.lbl_Sec = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbTimeWarning = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMineCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecond)).BeginInit();
            this.gbTimeWarning.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_buttonPanel
            // 
            this.pnl_buttonPanel.Location = new System.Drawing.Point(34, 33);
            this.pnl_buttonPanel.Name = "pnl_buttonPanel";
            this.pnl_buttonPanel.Size = new System.Drawing.Size(500, 500);
            this.pnl_buttonPanel.TabIndex = 0;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(713, 91);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Başla";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // tb_MineCount
            // 
            this.tb_MineCount.Location = new System.Drawing.Point(713, 32);
            this.tb_MineCount.Name = "tb_MineCount";
            this.tb_MineCount.Size = new System.Drawing.Size(75, 20);
            this.tb_MineCount.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(639, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mayın Sayısı:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(573, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Oyun Süresi:";
            // 
            // numericUpDownMin
            // 
            this.numericUpDownMin.Location = new System.Drawing.Point(642, 62);
            this.numericUpDownMin.Maximum = new decimal(new int[] {
            -469762049,
            -590869294,
            5421010,
            0});
            this.numericUpDownMin.Minimum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            -2147483648});
            this.numericUpDownMin.Name = "numericUpDownMin";
            this.numericUpDownMin.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownMin.TabIndex = 6;
            // 
            // numericUpDownSecond
            // 
            this.numericUpDownSecond.Location = new System.Drawing.Point(713, 62);
            this.numericUpDownSecond.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.numericUpDownSecond.Minimum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            -2147483648});
            this.numericUpDownSecond.Name = "numericUpDownSecond";
            this.numericUpDownSecond.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownSecond.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(685, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "DK";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(756, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "SN";
            // 
            // lblTimeWarning
            // 
            this.lblTimeWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeWarning.Location = new System.Drawing.Point(6, 102);
            this.lblTimeWarning.Name = "lblTimeWarning";
            this.lblTimeWarning.Size = new System.Drawing.Size(167, 46);
            this.lblTimeWarning.TabIndex = 7;
            this.lblTimeWarning.Text = "KalanSüre:";
            // 
            // lbl_Min
            // 
            this.lbl_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Min.Location = new System.Drawing.Point(69, 148);
            this.lbl_Min.Name = "lbl_Min";
            this.lbl_Min.Size = new System.Drawing.Size(149, 46);
            this.lbl_Min.TabIndex = 7;
            this.lbl_Min.Text = "00";
            // 
            // lbl_Sec
            // 
            this.lbl_Sec.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sec.Location = new System.Drawing.Point(69, 184);
            this.lbl_Sec.Name = "lbl_Sec";
            this.lbl_Sec.Size = new System.Drawing.Size(153, 46);
            this.lbl_Sec.TabIndex = 7;
            this.lbl_Sec.Text = "00";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 46);
            this.label8.TabIndex = 7;
            this.label8.Text = "Dk:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 46);
            this.label9.TabIndex = 7;
            this.label9.Text = "Sn:";
            // 
            // gbTimeWarning
            // 
            this.gbTimeWarning.Controls.Add(this.label6);
            this.gbTimeWarning.Controls.Add(this.label2);
            this.gbTimeWarning.Controls.Add(this.lblTimeWarning);
            this.gbTimeWarning.Controls.Add(this.lbl_Sec);
            this.gbTimeWarning.Controls.Add(this.lblMineCount);
            this.gbTimeWarning.Controls.Add(this.lbl_Min);
            this.gbTimeWarning.Controls.Add(this.label9);
            this.gbTimeWarning.Controls.Add(this.label8);
            this.gbTimeWarning.Location = new System.Drawing.Point(549, 120);
            this.gbTimeWarning.Name = "gbTimeWarning";
            this.gbTimeWarning.Size = new System.Drawing.Size(239, 237);
            this.gbTimeWarning.TabIndex = 8;
            this.gbTimeWarning.TabStop = false;
            this.gbTimeWarning.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 46);
            this.label6.TabIndex = 7;
            this.label6.Text = "KalanMayın:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 46);
            this.label2.TabIndex = 7;
            this.label2.Text = "KalanSüre:";
            // 
            // lblMineCount
            // 
            this.lblMineCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMineCount.Location = new System.Drawing.Point(170, 39);
            this.lblMineCount.Name = "lblMineCount";
            this.lblMineCount.Size = new System.Drawing.Size(63, 46);
            this.lblMineCount.TabIndex = 7;
            this.lblMineCount.Text = "000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 539);
            this.Controls.Add(this.gbTimeWarning);
            this.Controls.Add(this.numericUpDownSecond);
            this.Controls.Add(this.numericUpDownMin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_MineCount);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.pnl_buttonPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSecond)).EndInit();
            this.gbTimeWarning.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_buttonPanel;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox tb_MineCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMin;
        private System.Windows.Forms.NumericUpDown numericUpDownSecond;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTimeWarning;
        private System.Windows.Forms.Label lbl_Min;
        private System.Windows.Forms.Label lbl_Sec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbTimeWarning;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMineCount;
    }
}

