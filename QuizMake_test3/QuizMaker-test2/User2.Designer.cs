namespace QuizMaker_test2
{
    partial class User2
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
            this.btnLogOUT = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnStartQuiz = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogOUT
            // 
            this.btnLogOUT.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnLogOUT.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLogOUT.Location = new System.Drawing.Point(995, 7);
            this.btnLogOUT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogOUT.Name = "btnLogOUT";
            this.btnLogOUT.Size = new System.Drawing.Size(121, 37);
            this.btnLogOUT.TabIndex = 1;
            this.btnLogOUT.Text = "log out";
            this.btnLogOUT.UseVisualStyleBackColor = false;
            this.btnLogOUT.Click += new System.EventHandler(this.btnLogOUT_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(755, 10);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(193, 29);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Name Surname";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.BtnStartQuiz);
            this.panel1.Location = new System.Drawing.Point(-3, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 714);
            this.panel1.TabIndex = 3;
            // 
            // BtnStartQuiz
            // 
            this.BtnStartQuiz.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BtnStartQuiz.Font = new System.Drawing.Font("Microsoft Uighur", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStartQuiz.ForeColor = System.Drawing.Color.Lime;
            this.BtnStartQuiz.Location = new System.Drawing.Point(77, 98);
            this.BtnStartQuiz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnStartQuiz.Name = "BtnStartQuiz";
            this.BtnStartQuiz.Size = new System.Drawing.Size(180, 37);
            this.BtnStartQuiz.TabIndex = 3;
            this.BtnStartQuiz.Text = "Start Quiz";
            this.BtnStartQuiz.UseVisualStyleBackColor = false;
            this.BtnStartQuiz.Click += new System.EventHandler(this.BtnStartQuiz_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.btnLogOUT);
            this.panel2.Controls.Add(this.lblUser);
            this.panel2.Location = new System.Drawing.Point(264, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 46);
            this.panel2.TabIndex = 4;
            // 
            // User2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 713);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "User2";
            this.Text = "User_Form";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogOUT;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnStartQuiz;
    }
}