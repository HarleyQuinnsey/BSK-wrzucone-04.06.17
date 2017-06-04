namespace BSK.projekt
{
    partial class SearchForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.conditionTextBox = new System.Windows.Forms.TextBox();
            this.conditionBox = new System.Windows.Forms.ComboBox();
            this.addNewConditionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(197, 52);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 15;
            this.searchButton.Text = "Szukaj";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Warunek 1:";
            // 
            // conditionTextBox
            // 
            this.conditionTextBox.Location = new System.Drawing.Point(107, 26);
            this.conditionTextBox.Name = "conditionTextBox";
            this.conditionTextBox.Size = new System.Drawing.Size(165, 20);
            this.conditionTextBox.TabIndex = 1;
            // 
            // conditionBox
            // 
            this.conditionBox.FormattingEnabled = true;
            this.conditionBox.Location = new System.Drawing.Point(12, 25);
            this.conditionBox.Name = "conditionBox";
            this.conditionBox.Size = new System.Drawing.Size(72, 21);
            this.conditionBox.TabIndex = 23;
            this.conditionBox.Click += new System.EventHandler(this.setComboBoxValues);
            // 
            // addNewConditionButton
            // 
            this.addNewConditionButton.Location = new System.Drawing.Point(12, 52);
            this.addNewConditionButton.Name = "addNewConditionButton";
            this.addNewConditionButton.Size = new System.Drawing.Size(25, 23);
            this.addNewConditionButton.TabIndex = 24;
            this.addNewConditionButton.Text = "+";
            this.addNewConditionButton.UseVisualStyleBackColor = true;
            this.addNewConditionButton.Click += new System.EventHandler(this.addNewConditionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(90, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "=";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(284, 87);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addNewConditionButton);
            this.Controls.Add(this.conditionBox);
            this.Controls.Add(this.conditionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label2);
            this.Name = "SearchForm";
            this.Text = "Wyszukiwarka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox conditionTextBox;
        private System.Windows.Forms.ComboBox conditionBox;
        private System.Windows.Forms.Button addNewConditionButton;
        private System.Windows.Forms.Label label1;
    }
}