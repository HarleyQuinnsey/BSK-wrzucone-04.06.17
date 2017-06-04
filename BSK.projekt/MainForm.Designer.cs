using System.Windows.Forms;

namespace BSK.projekt
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.takeOverCheckBox = new System.Windows.Forms.CheckBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flagSetUP = new System.Windows.Forms.Button();
            this.selectComboBox = new System.Windows.Forms.ComboBox();
            this.passInsertCheckBox = new System.Windows.Forms.CheckBox();
            this.passDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.passUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.passSelectCheckBox = new System.Windows.Forms.CheckBox();
            this.insertCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteCheckBox = new System.Windows.Forms.CheckBox();
            this.updateCheckBox = new System.Windows.Forms.CheckBox();
            this.selectCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.przejmij = new System.Windows.Forms.Button();
            this.przekaz = new System.Windows.Forms.Button();
            this.usun = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.questionResult = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.takeOverButton = new System.Windows.Forms.Button();
            this.insertWithTransferButton = new System.Windows.Forms.Button();
            this.deleteWithTransferButton = new System.Windows.Forms.Button();
            this.updateWithTransferButton = new System.Windows.Forms.Button();
            this.selectWithTransferButton = new System.Windows.Forms.Button();
            this.tableNameActivitiesOnBase = new System.Windows.Forms.ComboBox();
            this.tableNameLabel = new System.Windows.Forms.Label();
            this.insertButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.addNewRowButton = new System.Windows.Forms.Button();
            this.yourPowersGroupBox = new System.Windows.Forms.GroupBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.privillagesPreviewButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionResult)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.yourPowersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSalmon;
            this.groupBox1.Controls.Add(this.privillagesPreviewButton);
            this.groupBox1.Controls.Add(this.takeOverCheckBox);
            this.groupBox1.Controls.Add(this.infoLabel);
            this.groupBox1.Controls.Add(this.ExecuteButton);
            this.groupBox1.Controls.Add(this.userComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.flagSetUP);
            this.groupBox1.Controls.Add(this.selectComboBox);
            this.groupBox1.Controls.Add(this.passInsertCheckBox);
            this.groupBox1.Controls.Add(this.passDeleteCheckBox);
            this.groupBox1.Controls.Add(this.passUpdateCheckBox);
            this.groupBox1.Controls.Add(this.passSelectCheckBox);
            this.groupBox1.Controls.Add(this.insertCheckBox);
            this.groupBox1.Controls.Add(this.deleteCheckBox);
            this.groupBox1.Controls.Add(this.updateCheckBox);
            this.groupBox1.Controls.Add(this.selectCheckBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.przejmij);
            this.groupBox1.Controls.Add(this.przekaz);
            this.groupBox1.Controls.Add(this.usun);
            this.groupBox1.Controls.Add(this.add);
            this.groupBox1.Location = new System.Drawing.Point(24, 121);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(670, 594);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DZIAŁANIA NA UŻYTKOWNIKACH";
            // 
            // takeOverCheckBox
            // 
            this.takeOverCheckBox.AutoSize = true;
            this.takeOverCheckBox.BackColor = System.Drawing.Color.DarkSalmon;
            this.takeOverCheckBox.Location = new System.Drawing.Point(454, 454);
            this.takeOverCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.takeOverCheckBox.Name = "takeOverCheckBox";
            this.takeOverCheckBox.Size = new System.Drawing.Size(118, 29);
            this.takeOverCheckBox.TabIndex = 43;
            this.takeOverCheckBox.Text = "przejmij";
            this.takeOverCheckBox.UseVisualStyleBackColor = false;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoLabel.Location = new System.Drawing.Point(190, 456);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(26, 25, 26, 25);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(56, 27);
            this.infoLabel.TabIndex = 42;
            this.infoLabel.Text = ".......";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.infoLabel.Visible = false;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(498, 500);
            this.ExecuteButton.Margin = new System.Windows.Forms.Padding(6);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(150, 83);
            this.ExecuteButton.TabIndex = 41;
            this.ExecuteButton.Text = "Wykonaj";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // userComboBox
            // 
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(172, 92);
            this.userComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(314, 33);
            this.userComboBox.TabIndex = 40;
            this.userComboBox.Text = "Wybierz użytkownika";
            this.userComboBox.SelectedIndexChanged += new System.EventHandler(this.userComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 39;
            this.label3.Text = "Nazwa tabeli:";
            // 
            // flagSetUP
            // 
            this.flagSetUP.Location = new System.Drawing.Point(18, 204);
            this.flagSetUP.Margin = new System.Windows.Forms.Padding(6);
            this.flagSetUP.Name = "flagSetUP";
            this.flagSetUP.Size = new System.Drawing.Size(146, 44);
            this.flagSetUP.TabIndex = 24;
            this.flagSetUP.Text = "Ustaw flagi";
            this.flagSetUP.UseVisualStyleBackColor = true;
            this.flagSetUP.Click += new System.EventHandler(this.flagSetUp_Click);
            // 
            // selectComboBox
            // 
            this.selectComboBox.FormattingEnabled = true;
            this.selectComboBox.Location = new System.Drawing.Point(264, 210);
            this.selectComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.selectComboBox.Name = "selectComboBox";
            this.selectComboBox.Size = new System.Drawing.Size(288, 33);
            this.selectComboBox.TabIndex = 23;
            this.selectComboBox.Text = "Wybierz tabelę";
            this.selectComboBox.SelectedIndexChanged += new System.EventHandler(this.selectComboBox_SelectedIndexChanged);
            // 
            // passInsertCheckBox
            // 
            this.passInsertCheckBox.AutoSize = true;
            this.passInsertCheckBox.BackColor = System.Drawing.Color.DarkSalmon;
            this.passInsertCheckBox.Location = new System.Drawing.Point(454, 408);
            this.passInsertCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.passInsertCheckBox.Name = "passInsertCheckBox";
            this.passInsertCheckBox.Size = new System.Drawing.Size(120, 29);
            this.passInsertCheckBox.TabIndex = 21;
            this.passInsertCheckBox.Text = "przekaz";
            this.passInsertCheckBox.UseVisualStyleBackColor = false;
            this.passInsertCheckBox.CheckedChanged += new System.EventHandler(this.passInsertCheckBox_CheckedChanged);
            // 
            // passDeleteCheckBox
            // 
            this.passDeleteCheckBox.AutoSize = true;
            this.passDeleteCheckBox.BackColor = System.Drawing.Color.DarkSalmon;
            this.passDeleteCheckBox.Location = new System.Drawing.Point(454, 362);
            this.passDeleteCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.passDeleteCheckBox.Name = "passDeleteCheckBox";
            this.passDeleteCheckBox.Size = new System.Drawing.Size(120, 29);
            this.passDeleteCheckBox.TabIndex = 20;
            this.passDeleteCheckBox.Text = "przekaz";
            this.passDeleteCheckBox.UseVisualStyleBackColor = false;
            this.passDeleteCheckBox.CheckedChanged += new System.EventHandler(this.passDeleteCheckBox_CheckedChanged);
            // 
            // passUpdateCheckBox
            // 
            this.passUpdateCheckBox.AutoSize = true;
            this.passUpdateCheckBox.BackColor = System.Drawing.Color.DarkSalmon;
            this.passUpdateCheckBox.Location = new System.Drawing.Point(454, 319);
            this.passUpdateCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.passUpdateCheckBox.Name = "passUpdateCheckBox";
            this.passUpdateCheckBox.Size = new System.Drawing.Size(120, 29);
            this.passUpdateCheckBox.TabIndex = 19;
            this.passUpdateCheckBox.Text = "przekaz";
            this.passUpdateCheckBox.UseVisualStyleBackColor = false;
            this.passUpdateCheckBox.CheckedChanged += new System.EventHandler(this.passUpdateCheckBox_CheckedChanged);
            // 
            // passSelectCheckBox
            // 
            this.passSelectCheckBox.AutoSize = true;
            this.passSelectCheckBox.BackColor = System.Drawing.Color.DarkSalmon;
            this.passSelectCheckBox.Location = new System.Drawing.Point(454, 275);
            this.passSelectCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.passSelectCheckBox.Name = "passSelectCheckBox";
            this.passSelectCheckBox.Size = new System.Drawing.Size(120, 29);
            this.passSelectCheckBox.TabIndex = 18;
            this.passSelectCheckBox.Text = "przekaz";
            this.passSelectCheckBox.UseVisualStyleBackColor = false;
            this.passSelectCheckBox.CheckedChanged += new System.EventHandler(this.passSelectCheckBox_CheckedChanged);
            // 
            // insertCheckBox
            // 
            this.insertCheckBox.AutoSize = true;
            this.insertCheckBox.Location = new System.Drawing.Point(264, 408);
            this.insertCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.insertCheckBox.Name = "insertCheckBox";
            this.insertCheckBox.Size = new System.Drawing.Size(187, 29);
            this.insertCheckBox.TabIndex = 13;
            this.insertCheckBox.Text = "insert...............";
            this.insertCheckBox.UseVisualStyleBackColor = true;
            // 
            // deleteCheckBox
            // 
            this.deleteCheckBox.AutoSize = true;
            this.deleteCheckBox.Location = new System.Drawing.Point(264, 362);
            this.deleteCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.deleteCheckBox.Name = "deleteCheckBox";
            this.deleteCheckBox.Size = new System.Drawing.Size(187, 29);
            this.deleteCheckBox.TabIndex = 12;
            this.deleteCheckBox.Text = "delete..............";
            this.deleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // updateCheckBox
            // 
            this.updateCheckBox.AutoSize = true;
            this.updateCheckBox.Location = new System.Drawing.Point(264, 319);
            this.updateCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.updateCheckBox.Name = "updateCheckBox";
            this.updateCheckBox.Size = new System.Drawing.Size(182, 29);
            this.updateCheckBox.TabIndex = 11;
            this.updateCheckBox.Text = "update............";
            this.updateCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectCheckBox
            // 
            this.selectCheckBox.AutoSize = true;
            this.selectCheckBox.Location = new System.Drawing.Point(264, 275);
            this.selectCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.selectCheckBox.Name = "selectCheckBox";
            this.selectCheckBox.Size = new System.Drawing.Size(185, 29);
            this.selectCheckBox.TabIndex = 9;
            this.selectCheckBox.Text = "select..............";
            this.selectCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tryby do wyboru";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Na jakim użytkowniku chcesz wykonać działanie?";
            // 
            // przejmij
            // 
            this.przejmij.Location = new System.Drawing.Point(18, 450);
            this.przejmij.Margin = new System.Windows.Forms.Padding(6);
            this.przejmij.Name = "przejmij";
            this.przejmij.Size = new System.Drawing.Size(146, 83);
            this.przejmij.TabIndex = 5;
            this.przejmij.Text = "Przejmij uprawnienia";
            this.przejmij.UseVisualStyleBackColor = true;
            this.przejmij.Visible = false;
            this.przejmij.Click += new System.EventHandler(this.przejmij_Click);
            // 
            // przekaz
            // 
            this.przekaz.AccessibleName = "";
            this.przekaz.Location = new System.Drawing.Point(18, 355);
            this.przekaz.Margin = new System.Windows.Forms.Padding(6);
            this.przekaz.Name = "przekaz";
            this.przekaz.Size = new System.Drawing.Size(146, 83);
            this.przekaz.TabIndex = 4;
            this.przekaz.Text = "Przekaz uprawnienia";
            this.przekaz.UseVisualStyleBackColor = true;
            this.przekaz.Click += new System.EventHandler(this.przekaz_Click);
            // 
            // usun
            // 
            this.usun.Location = new System.Drawing.Point(338, 500);
            this.usun.Margin = new System.Windows.Forms.Padding(6);
            this.usun.Name = "usun";
            this.usun.Size = new System.Drawing.Size(150, 83);
            this.usun.TabIndex = 3;
            this.usun.Text = "Usuń usera";
            this.usun.UseVisualStyleBackColor = true;
            this.usun.Visible = false;
            this.usun.Click += new System.EventHandler(this.usun_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(178, 500);
            this.add.Margin = new System.Windows.Forms.Padding(6);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(150, 83);
            this.add.TabIndex = 2;
            this.add.Text = "Dodaj nowego";
            this.add.UseVisualStyleBackColor = true;
            this.add.Visible = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // questionResult
            // 
            this.questionResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionResult.Location = new System.Drawing.Point(722, 121);
            this.questionResult.Margin = new System.Windows.Forms.Padding(6);
            this.questionResult.Name = "questionResult";
            this.questionResult.Size = new System.Drawing.Size(996, 710);
            this.questionResult.TabIndex = 1;
            this.questionResult.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.questionResult_CellEndEdit);
            this.questionResult.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.questionResult_RowsAdded);
            this.questionResult.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.questionResult_UserAddedRow);
            this.questionResult.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.questionResultDeleteEvent);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkKhaki;
            this.groupBox3.Controls.Add(this.takeOverButton);
            this.groupBox3.Controls.Add(this.insertWithTransferButton);
            this.groupBox3.Controls.Add(this.deleteWithTransferButton);
            this.groupBox3.Controls.Add(this.updateWithTransferButton);
            this.groupBox3.Controls.Add(this.selectWithTransferButton);
            this.groupBox3.Controls.Add(this.tableNameActivitiesOnBase);
            this.groupBox3.Controls.Add(this.tableNameLabel);
            this.groupBox3.Controls.Add(this.insertButton);
            this.groupBox3.Controls.Add(this.deleteButton);
            this.groupBox3.Controls.Add(this.updateButton);
            this.groupBox3.Controls.Add(this.selectButton);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(24, 746);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(670, 246);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TWOJE UPRAWNIENIA";
            // 
            // takeOverButton
            // 
            this.takeOverButton.Enabled = false;
            this.takeOverButton.Location = new System.Drawing.Point(498, 71);
            this.takeOverButton.Margin = new System.Windows.Forms.Padding(6);
            this.takeOverButton.Name = "takeOverButton";
            this.takeOverButton.Size = new System.Drawing.Size(150, 44);
            this.takeOverButton.TabIndex = 39;
            this.takeOverButton.Text = "przejmij";
            this.takeOverButton.UseVisualStyleBackColor = true;
            // 
            // insertWithTransferButton
            // 
            this.insertWithTransferButton.Enabled = false;
            this.insertWithTransferButton.Location = new System.Drawing.Point(498, 188);
            this.insertWithTransferButton.Margin = new System.Windows.Forms.Padding(6);
            this.insertWithTransferButton.Name = "insertWithTransferButton";
            this.insertWithTransferButton.Size = new System.Drawing.Size(150, 38);
            this.insertWithTransferButton.TabIndex = 38;
            this.insertWithTransferButton.Text = "przekaż";
            this.insertWithTransferButton.UseVisualStyleBackColor = true;
            // 
            // deleteWithTransferButton
            // 
            this.deleteWithTransferButton.Enabled = false;
            this.deleteWithTransferButton.Location = new System.Drawing.Point(338, 188);
            this.deleteWithTransferButton.Margin = new System.Windows.Forms.Padding(6);
            this.deleteWithTransferButton.Name = "deleteWithTransferButton";
            this.deleteWithTransferButton.Size = new System.Drawing.Size(150, 38);
            this.deleteWithTransferButton.TabIndex = 37;
            this.deleteWithTransferButton.Text = "przekaż";
            this.deleteWithTransferButton.UseVisualStyleBackColor = true;
            // 
            // updateWithTransferButton
            // 
            this.updateWithTransferButton.Enabled = false;
            this.updateWithTransferButton.Location = new System.Drawing.Point(178, 188);
            this.updateWithTransferButton.Margin = new System.Windows.Forms.Padding(6);
            this.updateWithTransferButton.Name = "updateWithTransferButton";
            this.updateWithTransferButton.Size = new System.Drawing.Size(150, 38);
            this.updateWithTransferButton.TabIndex = 36;
            this.updateWithTransferButton.Text = "przekaż";
            this.updateWithTransferButton.UseVisualStyleBackColor = true;
            // 
            // selectWithTransferButton
            // 
            this.selectWithTransferButton.Enabled = false;
            this.selectWithTransferButton.Location = new System.Drawing.Point(18, 188);
            this.selectWithTransferButton.Margin = new System.Windows.Forms.Padding(6);
            this.selectWithTransferButton.Name = "selectWithTransferButton";
            this.selectWithTransferButton.Size = new System.Drawing.Size(150, 38);
            this.selectWithTransferButton.TabIndex = 35;
            this.selectWithTransferButton.Text = "przekaż";
            this.selectWithTransferButton.UseVisualStyleBackColor = true;
            // 
            // tableNameActivitiesOnBase
            // 
            this.tableNameActivitiesOnBase.FormattingEnabled = true;
            this.tableNameActivitiesOnBase.Location = new System.Drawing.Point(18, 71);
            this.tableNameActivitiesOnBase.Margin = new System.Windows.Forms.Padding(6);
            this.tableNameActivitiesOnBase.Name = "tableNameActivitiesOnBase";
            this.tableNameActivitiesOnBase.Size = new System.Drawing.Size(234, 33);
            this.tableNameActivitiesOnBase.TabIndex = 24;
            this.tableNameActivitiesOnBase.Text = "Wybierz ";
            this.tableNameActivitiesOnBase.SelectedIndexChanged += new System.EventHandler(this.tableNameActivitiesOnBase_SelectedIndexChanged);
            // 
            // tableNameLabel
            // 
            this.tableNameLabel.AutoSize = true;
            this.tableNameLabel.Location = new System.Drawing.Point(14, 37);
            this.tableNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tableNameLabel.Name = "tableNameLabel";
            this.tableNameLabel.Size = new System.Drawing.Size(141, 25);
            this.tableNameLabel.TabIndex = 9;
            this.tableNameLabel.Text = "Nazwa tabeli:";
            // 
            // insertButton
            // 
            this.insertButton.Enabled = false;
            this.insertButton.Location = new System.Drawing.Point(498, 129);
            this.insertButton.Margin = new System.Windows.Forms.Padding(6);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(150, 65);
            this.insertButton.TabIndex = 4;
            this.insertButton.Text = "insert";
            this.insertButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(338, 129);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(6);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(150, 65);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Enabled = false;
            this.updateButton.Location = new System.Drawing.Point(178, 129);
            this.updateButton.Margin = new System.Windows.Forms.Padding(6);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(150, 65);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "update";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // selectButton
            // 
            this.selectButton.Enabled = false;
            this.selectButton.Location = new System.Drawing.Point(18, 129);
            this.selectButton.Margin = new System.Windows.Forms.Padding(6);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(150, 65);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "select";
            this.selectButton.UseVisualStyleBackColor = true;
            // 
            // addNewRowButton
            // 
            this.addNewRowButton.Location = new System.Drawing.Point(236, 40);
            this.addNewRowButton.Margin = new System.Windows.Forms.Padding(6);
            this.addNewRowButton.Name = "addNewRowButton";
            this.addNewRowButton.Size = new System.Drawing.Size(212, 65);
            this.addNewRowButton.TabIndex = 30;
            this.addNewRowButton.Text = "Dodaj nowy wpis";
            this.addNewRowButton.UseVisualStyleBackColor = true;
            this.addNewRowButton.Visible = false;
            this.addNewRowButton.Click += new System.EventHandler(this.addNewRowButton_Click);
            // 
            // yourPowersGroupBox
            // 
            this.yourPowersGroupBox.BackColor = System.Drawing.Color.IndianRed;
            this.yourPowersGroupBox.Controls.Add(this.searchButton);
            this.yourPowersGroupBox.Controls.Add(this.logOut);
            this.yourPowersGroupBox.Controls.Add(this.addNewRowButton);
            this.yourPowersGroupBox.Location = new System.Drawing.Point(722, 858);
            this.yourPowersGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this.yourPowersGroupBox.Name = "yourPowersGroupBox";
            this.yourPowersGroupBox.Padding = new System.Windows.Forms.Padding(6);
            this.yourPowersGroupBox.Size = new System.Drawing.Size(996, 135);
            this.yourPowersGroupBox.TabIndex = 2;
            this.yourPowersGroupBox.TabStop = false;
            this.yourPowersGroupBox.Text = "DZIAŁANIE";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(12, 40);
            this.searchButton.Margin = new System.Windows.Forms.Padding(6);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(212, 65);
            this.searchButton.TabIndex = 31;
            this.searchButton.Text = "Wyszukaj";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Visible = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // logOut
            // 
            this.logOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOut.Location = new System.Drawing.Point(718, 23);
            this.logOut.Margin = new System.Windows.Forms.Padding(6);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(268, 98);
            this.logOut.TabIndex = 29;
            this.logOut.Text = "WYLOGUJ";
            this.logOut.UseVisualStyleBackColor = true;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.headerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.headerLabel.Location = new System.Drawing.Point(24, 17);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(240, 97);
            this.headerLabel.TabIndex = 3;
            this.headerLabel.Text = "Witaj ";
            // 
            // privillagesPreviewButton
            // 
            this.privillagesPreviewButton.AccessibleName = "";
            this.privillagesPreviewButton.Location = new System.Drawing.Point(18, 260);
            this.privillagesPreviewButton.Margin = new System.Windows.Forms.Padding(6);
            this.privillagesPreviewButton.Name = "privillagesPreviewButton";
            this.privillagesPreviewButton.Size = new System.Drawing.Size(146, 83);
            this.privillagesPreviewButton.TabIndex = 44;
            this.privillagesPreviewButton.Text = "Podgląd uprawnień";
            this.privillagesPreviewButton.UseVisualStyleBackColor = true;
            this.privillagesPreviewButton.Click += new System.EventHandler(this.privillagesPreviewButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1740, 1015);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.yourPowersGroupBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.questionResult);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Magic MsSQL Super DAC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionResult)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.yourPowersGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button przejmij;
        private System.Windows.Forms.Button przekaz;
        private System.Windows.Forms.Button usun;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.DataGridView questionResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox selectCheckBox;
        private System.Windows.Forms.CheckBox insertCheckBox;
        private System.Windows.Forms.CheckBox deleteCheckBox;
        private System.Windows.Forms.CheckBox updateCheckBox;
        private CheckBox passInsertCheckBox;
        private CheckBox passDeleteCheckBox;
        private CheckBox passUpdateCheckBox;
        private CheckBox passSelectCheckBox;
        private GroupBox groupBox3;
        private Button insertButton;
        private Button deleteButton;
        private Button updateButton;
        private Button selectButton;
        private GroupBox yourPowersGroupBox;
        private ComboBox selectComboBox;
        private Label tableNameLabel;
        private Button addNewRowButton;
        private ComboBox tableNameActivitiesOnBase;
        private Button logOut;
        private Button insertWithTransferButton;
        private Button deleteWithTransferButton;
        private Button updateWithTransferButton;
        private Button selectWithTransferButton;
        private Button flagSetUP;
        private Label label3;
        private Label infoLabel;
        private ComboBox userComboBox;
        private Button ExecuteButton;
        private CheckBox takeOverCheckBox;
        private Button takeOverButton;
        private Button searchButton;
        private Label headerLabel;
        private Button privillagesPreviewButton;
    }
}

