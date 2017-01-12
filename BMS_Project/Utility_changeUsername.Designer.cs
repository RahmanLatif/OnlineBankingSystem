namespace BMS_Project
{
    partial class Utility_changeUsername
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Utility_changeUsername));
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtBoxCurrPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxNewUsername = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSbmt = new System.Windows.Forms.Button();
            this.pnlLogin.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.Silver;
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Controls.Add(this.panel5);
            this.pnlLogin.Location = new System.Drawing.Point(15, 14);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(299, 366);
            this.pnlLogin.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Change Username";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.txtBoxCurrPass);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtBoxNewUsername);
            this.panel5.Controls.Add(this.btnReset);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.btnSbmt);
            this.panel5.Location = new System.Drawing.Point(25, 59);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(249, 272);
            this.panel5.TabIndex = 12;
            // 
            // txtBoxCurrPass
            // 
            this.txtBoxCurrPass.BackColor = System.Drawing.Color.White;
            this.txtBoxCurrPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxCurrPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCurrPass.Location = new System.Drawing.Point(16, 78);
            this.txtBoxCurrPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxCurrPass.Name = "txtBoxCurrPass";
            this.txtBoxCurrPass.PasswordChar = '*';
            this.txtBoxCurrPass.Size = new System.Drawing.Size(221, 24);
            this.txtBoxCurrPass.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "New Username";
            // 
            // txtBoxNewUsername
            // 
            this.txtBoxNewUsername.BackColor = System.Drawing.Color.White;
            this.txtBoxNewUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxNewUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNewUsername.Location = new System.Drawing.Point(16, 164);
            this.txtBoxNewUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxNewUsername.Name = "txtBoxNewUsername";
            this.txtBoxNewUsername.Size = new System.Drawing.Size(221, 24);
            this.txtBoxNewUsername.TabIndex = 19;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(16, 214);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(105, 34);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "Your Password";
            // 
            // btnSbmt
            // 
            this.btnSbmt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSbmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSbmt.ForeColor = System.Drawing.Color.White;
            this.btnSbmt.Location = new System.Drawing.Point(132, 214);
            this.btnSbmt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSbmt.Name = "btnSbmt";
            this.btnSbmt.Size = new System.Drawing.Size(105, 34);
            this.btnSbmt.TabIndex = 4;
            this.btnSbmt.Text = "Submit";
            this.btnSbmt.UseVisualStyleBackColor = false;
            this.btnSbmt.Click += new System.EventHandler(this.btnSbmt_Click);
            // 
            // Utility_changeUsername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 404);
            this.Controls.Add(this.pnlLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Utility_changeUsername";
            this.Text = "Change Username";
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtBoxCurrPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxNewUsername;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSbmt;
    }
}