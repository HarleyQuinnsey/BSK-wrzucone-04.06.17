namespace BSK.projekt
{
    partial class FlagForm
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
            this.select = new System.Windows.Forms.CheckBox();
            this.update = new System.Windows.Forms.CheckBox();
            this.delete = new System.Windows.Forms.CheckBox();
            this.insert = new System.Windows.Forms.CheckBox();
            this.SetFlagsOK = new System.Windows.Forms.Button();
            this.insertWithTransfer = new System.Windows.Forms.CheckBox();
            this.deleteWithTransfer = new System.Windows.Forms.CheckBox();
            this.updateWithTransfer = new System.Windows.Forms.CheckBox();
            this.selectWithTransfer = new System.Windows.Forms.CheckBox();
            this.takeOver = new System.Windows.Forms.CheckBox();
            this.selectComboBox = new System.Windows.Forms.ComboBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // select
            // 
            this.select.AutoSize = true;
            this.select.Location = new System.Drawing.Point(19, 81);
            this.select.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(233, 29);
            this.select.TabIndex = 0;
            this.select.Text = "select......................";
            this.select.UseVisualStyleBackColor = true;
            this.select.Visible = false;
            // 
            // update
            // 
            this.update.AutoSize = true;
            this.update.Location = new System.Drawing.Point(19, 128);
            this.update.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(230, 29);
            this.update.TabIndex = 1;
            this.update.Text = "update....................";
            this.update.UseVisualStyleBackColor = true;
            this.update.Visible = false;
            // 
            // delete
            // 
            this.delete.AutoSize = true;
            this.delete.Location = new System.Drawing.Point(19, 174);
            this.delete.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(223, 29);
            this.delete.TabIndex = 2;
            this.delete.Text = "delete....................";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Visible = false;
            // 
            // insert
            // 
            this.insert.AutoSize = true;
            this.insert.Location = new System.Drawing.Point(19, 220);
            this.insert.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(229, 29);
            this.insert.TabIndex = 3;
            this.insert.Text = "insert......................";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Visible = false;
            // 
            // SetFlagsOK
            // 
            this.SetFlagsOK.Location = new System.Drawing.Point(441, 206);
            this.SetFlagsOK.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.SetFlagsOK.Name = "SetFlagsOK";
            this.SetFlagsOK.Size = new System.Drawing.Size(149, 44);
            this.SetFlagsOK.TabIndex = 4;
            this.SetFlagsOK.Text = "OK";
            this.SetFlagsOK.UseVisualStyleBackColor = true;
            this.SetFlagsOK.Click += new System.EventHandler(this.SetFlagsOK_Click);
            // 
            // insertWithTransfer
            // 
            this.insertWithTransfer.AutoSize = true;
            this.insertWithTransfer.Location = new System.Drawing.Point(220, 220);
            this.insertWithTransfer.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.insertWithTransfer.Name = "insertWithTransfer";
            this.insertWithTransfer.Size = new System.Drawing.Size(120, 29);
            this.insertWithTransfer.TabIndex = 9;
            this.insertWithTransfer.Text = "przekaz";
            this.insertWithTransfer.UseVisualStyleBackColor = true;
            this.insertWithTransfer.Visible = false;
            this.insertWithTransfer.CheckedChanged += new System.EventHandler(this.insertWithTransfer_CheckedChanged);
            // 
            // deleteWithTransfer
            // 
            this.deleteWithTransfer.AutoSize = true;
            this.deleteWithTransfer.Location = new System.Drawing.Point(220, 174);
            this.deleteWithTransfer.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.deleteWithTransfer.Name = "deleteWithTransfer";
            this.deleteWithTransfer.Size = new System.Drawing.Size(120, 29);
            this.deleteWithTransfer.TabIndex = 8;
            this.deleteWithTransfer.Text = "przekaz";
            this.deleteWithTransfer.UseVisualStyleBackColor = true;
            this.deleteWithTransfer.Visible = false;
            this.deleteWithTransfer.CheckedChanged += new System.EventHandler(this.deleteWithTransfer_CheckedChanged);
            // 
            // updateWithTransfer
            // 
            this.updateWithTransfer.AutoSize = true;
            this.updateWithTransfer.Location = new System.Drawing.Point(220, 128);
            this.updateWithTransfer.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.updateWithTransfer.Name = "updateWithTransfer";
            this.updateWithTransfer.Size = new System.Drawing.Size(120, 29);
            this.updateWithTransfer.TabIndex = 7;
            this.updateWithTransfer.Text = "przekaz";
            this.updateWithTransfer.UseVisualStyleBackColor = true;
            this.updateWithTransfer.Visible = false;
            this.updateWithTransfer.CheckedChanged += new System.EventHandler(this.updateWithTransfer_CheckedChanged);
            // 
            // selectWithTransfer
            // 
            this.selectWithTransfer.AutoSize = true;
            this.selectWithTransfer.Location = new System.Drawing.Point(220, 81);
            this.selectWithTransfer.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.selectWithTransfer.Name = "selectWithTransfer";
            this.selectWithTransfer.Size = new System.Drawing.Size(120, 29);
            this.selectWithTransfer.TabIndex = 6;
            this.selectWithTransfer.Text = "przekaz";
            this.selectWithTransfer.UseVisualStyleBackColor = true;
            this.selectWithTransfer.Visible = false;
            this.selectWithTransfer.CheckedChanged += new System.EventHandler(this.selectWithTransfer_CheckedChanged);
            // 
            // takeOver
            // 
            this.takeOver.AutoSize = true;
            this.takeOver.Location = new System.Drawing.Point(220, 264);
            this.takeOver.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.takeOver.Name = "takeOver";
            this.takeOver.Size = new System.Drawing.Size(118, 29);
            this.takeOver.TabIndex = 10;
            this.takeOver.Text = "przejmij";
            this.takeOver.UseVisualStyleBackColor = true;
            this.takeOver.Visible = false;
            // 
            // selectComboBox
            // 
            this.selectComboBox.FormattingEnabled = true;
            this.selectComboBox.Location = new System.Drawing.Point(17, 18);
            this.selectComboBox.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.selectComboBox.Name = "selectComboBox";
            this.selectComboBox.Size = new System.Drawing.Size(319, 33);
            this.selectComboBox.TabIndex = 24;
            this.selectComboBox.Text = "Wybierz tabelę";
            this.selectComboBox.SelectedIndexChanged += new System.EventHandler(this.selectComboBox_SelectedIndexChanged);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(539, 174);
            this.timerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(54, 25);
            this.timerLabel.TabIndex = 25;
            this.timerLabel.Text = "...10";
            this.timerLabel.Visible = false;
            // 
            // FlagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 325);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.selectComboBox);
            this.Controls.Add(this.takeOver);
            this.Controls.Add(this.insertWithTransfer);
            this.Controls.Add(this.deleteWithTransfer);
            this.Controls.Add(this.updateWithTransfer);
            this.Controls.Add(this.selectWithTransfer);
            this.Controls.Add(this.SetFlagsOK);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.update);
            this.Controls.Add(this.select);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FlagForm";
            this.Text = "Uprawnienia";
            this.MouseHover += new System.EventHandler(this.FlagForm_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FlagForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox select;
        private System.Windows.Forms.CheckBox update;
        private System.Windows.Forms.CheckBox delete;
        private System.Windows.Forms.CheckBox insert;
        private System.Windows.Forms.Button SetFlagsOK;
        private System.Windows.Forms.CheckBox insertWithTransfer;
        private System.Windows.Forms.CheckBox deleteWithTransfer;
        private System.Windows.Forms.CheckBox updateWithTransfer;
        private System.Windows.Forms.CheckBox selectWithTransfer;
        private System.Windows.Forms.CheckBox takeOver;
        private System.Windows.Forms.ComboBox selectComboBox;
        private System.Windows.Forms.Label timerLabel;
    }
}