namespace CPCalculation
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
            this.txtSharesSold = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPricePerShare = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSellDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSharesSold
            // 
            this.txtSharesSold.Location = new System.Drawing.Point(134, 30);
            this.txtSharesSold.Name = "txtSharesSold";
            this.txtSharesSold.Size = new System.Drawing.Size(124, 20);
            this.txtSharesSold.TabIndex = 0;
            this.txtSharesSold.Text = "120";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shares Sold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Price Per Share";
            // 
            // txtPricePerShare
            // 
            this.txtPricePerShare.Location = new System.Drawing.Point(134, 73);
            this.txtPricePerShare.Name = "txtPricePerShare";
            this.txtPricePerShare.Size = new System.Drawing.Size(124, 20);
            this.txtPricePerShare.TabIndex = 2;
            this.txtPricePerShare.Text = "10.5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sell Date";
            // 
            // txtSellDate
            // 
            this.txtSellDate.Location = new System.Drawing.Point(134, 110);
            this.txtSellDate.Name = "txtSellDate";
            this.txtSellDate.Size = new System.Drawing.Size(124, 20);
            this.txtSellDate.TabIndex = 4;
            this.txtSellDate.Text = "2/3/2005";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cost Method";
            // 
            // cbMethod
            // 
            this.cbMethod.DisplayMember = "0";
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "Fifo",
            "Lifo",
            "Max",
            "Min",
            "Avg"});
            this.cbMethod.Location = new System.Drawing.Point(134, 156);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(121, 21);
            this.cbMethod.TabIndex = 7;
            this.cbMethod.Text = "Fifo";
            this.cbMethod.ValueMember = "0";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(49, 221);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(49, 293);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(35, 13);
            this.lblResults.TabIndex = 9;
            this.lblResults.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 492);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.cbMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSellDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPricePerShare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSharesSold);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSharesSold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPricePerShare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSellDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblResults;
    }
}

