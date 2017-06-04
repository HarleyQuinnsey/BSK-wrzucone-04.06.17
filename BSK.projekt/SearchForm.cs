using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static BSK.projekt.LogForm;
using System.Security.Cryptography;
using System.Collections;

namespace BSK.projekt
{
    public partial class SearchForm : System.Windows.Forms.Form
    {
        DatabaseConnector ourDB;
        DataGridView questionResult;
        DataTable queryResult;

        ArrayList textBoxList = new ArrayList();
        ArrayList comboBoxList = new ArrayList();
        ArrayList labelList = new ArrayList();
        ArrayList buttonList = new ArrayList();
        ArrayList conditionList = new ArrayList();

        Int32 oldRowCount;
        int conditionsLeft;
        string tableName;

        public SearchForm(DatabaseConnector ourDB, DataGridView questionResult, Int32 oldRowCount, string tableName)
        {
            InitializeComponent();
            this.ourDB = ourDB;
            this.oldRowCount = oldRowCount;
            this.tableName = tableName;
            this.questionResult = questionResult;

            string bla = "SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'";
            queryResult = ourDB.getData(bla);
            if (queryResult == null) this.Close();

            for (int i = 0; i < queryResult.Rows.Count; i++)
            {
                conditionList.Add(queryResult.Rows[i][0].ToString());
            }

            conditionsLeft = queryResult.Rows.Count -1;

            comboBoxList.Add(conditionBox);
            textBoxList.Add(conditionTextBox);
            labelList.Add(label1);
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter;
            var select = "SELECT * FROM " + tableName + " WHERE " + selectBuilder();
            var c = ourDB.connection; // Your Connection String here
            dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            try
            {
                dataAdapter.Fill(ds);
            }
            catch{ }
            
            //questionResult.ReadOnly = true;
            questionResult.DataSource = ds.Tables[0];
            oldRowCount = ds.Tables[0].Rows.Count;
            this.Close();
        }

        private string selectBuilder()
        {
            string str = "";
            int i = 0;
            foreach (ComboBox cb in comboBoxList)
            {
                if (!cb.Text.Equals("")) str += cb.Text + " = '" + ((TextBox)textBoxList[i]).Text + "' and ";
                i++;
            }
            if (str.Equals("")) return "";
            string output = str.Remove(str.Length - 4, 4);
            return output;
        }

        private void addNewConditionButton_Click(object sender, EventArgs e)
        {
            this.Height += 30;
            addNewConditionButton.Location = new Point(addNewConditionButton.Location.X, addNewConditionButton.Location.Y + 30);
            searchButton.Location = new Point(searchButton.Location.X, searchButton.Location.Y + 30);

            ComboBox newCombo = new ComboBox();
            newCombo.Width = 72;
            newCombo.Location = new Point(((ComboBox)comboBoxList[comboBoxList.Count - 1]).Location.X, ((ComboBox)comboBoxList[comboBoxList.Count - 1]).Location.Y + 30);
            comboBoxList.Add(newCombo);
            newCombo.Click += new EventHandler(setComboBoxValues);
            this.Controls.Add(newCombo);

            TextBox newTextBox = new TextBox();
            newTextBox.Width = 135;
            newTextBox.Location = new Point(((TextBox)textBoxList[textBoxList.Count - 1]).Location.X, ((TextBox)textBoxList[textBoxList.Count - 1]).Location.Y + 30);
            textBoxList.Add(newTextBox);
            this.Controls.Add(newTextBox);

            Label newLabel = new Label();
            newLabel.Text = "=";
            newLabel.ForeColor = label1.ForeColor;
            newLabel.Location = new Point(((Label)labelList[labelList.Count - 1]).Location.X, ((Label)labelList[labelList.Count - 1]).Location.Y + 30);
            labelList.Add(newLabel);
            this.Controls.Add(newLabel);

            Button newButton = new Button();
            newButton.Size = addNewConditionButton.Size;
            newButton.BackColor = Color.LightGray;
            newButton.Text = "-";
            newButton.Location = new Point(newLabel.Location.X + 157, newLabel.Location.Y - 5);
            buttonList.Add(newButton);
            newButton.Click += new EventHandler(deleteConditionButton_Click);
            this.Controls.Add(newButton);

            conditionsLeft--;
            if (conditionsLeft == 0) addNewConditionButton.Visible = false;
        }

        private void setComboBoxValues(object sender, EventArgs e)
        {
            ((ComboBox)sender).Items.Clear();

            ArrayList actualConditions = new ArrayList();
            foreach (Object o in conditionList)
                actualConditions.Add(o);

            foreach (ComboBox o in comboBoxList)
                if (!o.Text.Equals("")) actualConditions.Remove(o.Text);

            if (!((ComboBox)sender).Text.Equals("")) ((ComboBox)sender).Items.Add(((ComboBox)sender).Text);
            foreach (Object o in actualConditions)
                ((ComboBox)sender).Items.Add(o);
        }

        private void deleteConditionButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = buttonList.IndexOf(button) +1;

            ComboBox combo = (ComboBox) comboBoxList[index];
            TextBox text = (TextBox)textBoxList[index];
            Label label1 = (Label)labelList[index];

            comboBoxList.RemoveAt(index);
            textBoxList.RemoveAt(index);
            labelList.RemoveAt(index);
            buttonList.Remove(button);

            this.Controls.Remove(combo);
            this.Controls.Remove(text);
            this.Controls.Remove(label1);
            this.Controls.Remove(button);

            for (int i = index; i < comboBoxList.Count; i++)
            {
                combo = (ComboBox)comboBoxList[i];
                combo.Location = new Point(combo.Location.X, combo.Location.Y - 30);
                text = (TextBox)textBoxList[i];
                text.Location = new Point(text.Location.X, text.Location.Y - 30);
                label1 = (Label)labelList[i];
                label1.Location = new Point(label1.Location.X, label1.Location.Y - 30);
                button = (Button)buttonList[i - 1];
                button.Location = new Point(button.Location.X, button.Location.Y - 30);
            }

            this.Height -= 30;
            addNewConditionButton.Location = new Point(addNewConditionButton.Location.X, addNewConditionButton.Location.Y - 30);
            searchButton.Location = new Point(searchButton.Location.X, searchButton.Location.Y - 30);

            conditionsLeft++;
            if (conditionsLeft != 0) addNewConditionButton.Visible = true;
        }
    }
}

