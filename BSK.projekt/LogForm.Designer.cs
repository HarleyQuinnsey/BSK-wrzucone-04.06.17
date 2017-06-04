namespace BSK.projekt
{
    partial class LogForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.logInPassword = new System.Windows.Forms.TextBox();
            this.logInButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.logInUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 131);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podaj haslo:";
            // 
            // logInPassword
            // 
            this.logInPassword.Location = new System.Drawing.Point(18, 155);
            this.logInPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logInPassword.Name = "logInPassword";
            this.logInPassword.PasswordChar = '*';
            this.logInPassword.Size = new System.Drawing.Size(318, 26);
            this.logInPassword.TabIndex = 2;
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(212, 235);
            this.logInButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(126, 62);
            this.logInButton.TabIndex = 3;
            this.logInButton.Text = "Loguj";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wybierz użytkownika:";
            // 
            // logInUserName
            // 
            this.logInUserName.Location = new System.Drawing.Point(18, 57);
            this.logInUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logInUserName.Name = "logInUserName";
            this.logInUserName.Size = new System.Drawing.Size(318, 26);
            this.logInUserName.TabIndex = 1;
            // 
            // Logowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(362, 335);
            this.Controls.Add(this.logInUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logInButton);
            this.Controls.Add(this.logInPassword);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Logowanie";
            this.Text = "Logowanie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logInPassword;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox logInUserName;
    }
}