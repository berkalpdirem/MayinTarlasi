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
            this.pnl_buttonPanel = new System.Windows.Forms.Panel();
            this.btn_Start = new System.Windows.Forms.Button();
            this.tb_MineCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pnl_buttonPanel
            // 
            this.pnl_buttonPanel.Location = new System.Drawing.Point(34, 33);
            this.pnl_buttonPanel.Name = "pnl_buttonPanel";
            this.pnl_buttonPanel.Size = new System.Drawing.Size(410, 330);
            this.pnl_buttonPanel.TabIndex = 0;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(478, 59);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Başla";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // tb_MineCount
            // 
            this.tb_MineCount.Location = new System.Drawing.Point(478, 33);
            this.tb_MineCount.Name = "tb_MineCount";
            this.tb_MineCount.Size = new System.Drawing.Size(100, 20);
            this.tb_MineCount.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_MineCount);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.pnl_buttonPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_buttonPanel;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox tb_MineCount;
    }
}

