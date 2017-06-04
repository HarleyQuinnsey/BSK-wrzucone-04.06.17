using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;

namespace BSK.projekt
{
    public partial class FlagForm : System.Windows.Forms.Form
    {
        String currentUser, usersParents, currentPrivilages;
        DatabaseConnector ourDB = null;
        int tableNumber, id = -1;

        ArrayList flagList;
        private System.Timers.Timer _timer = new System.Timers.Timer();

        int timer = 10;

        public FlagForm(String currentUser, DatabaseConnector ourDB)// Form1 form, String table_name, User current_user, User chosen_user)
        {
            InitializeComponent();

            selectComboBox.Items.Add("Faktura");
            selectComboBox.Items.Add("Historia");
            selectComboBox.Items.Add("Potrawa");
            selectComboBox.Items.Add("Pracownik");
            selectComboBox.Items.Add("Restauracja");

            DataTable queryResult = ourDB.getData("SELECT * FROM Historia WHERE Biorca = '" + currentUser + "' and CzyAktualne = '1'");
            if (queryResult == null) this.Close();
            try
            {
                id = Int32.Parse(queryResult.Rows[0][0].ToString());
                currentPrivilages = queryResult.Rows[0][5].ToString();
                usersParents = queryResult.Rows[0][6].ToString();
                flagList = queryQuasiParser(queryResult.Rows[0][7].ToString());
            }
            catch { }

            this.currentUser = currentUser;
            this.ourDB = ourDB;

            _timer.Elapsed += OnTimerElapsed;
            _timer.Interval = 1000;
            _timer.AutoReset = false;
        }

        private void selectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ArrayListToString(flagList).Contains("" + selectComboBox.SelectedIndex))
            {
                String query = "UPDATE Historia SET Blokada = 1 WHERE ID = " + id;
                ourDB.executeSettingData(new SqlCommand(query, ourDB.connection));

                TimerRestart();
                timerLabel.Visible = true;
            }
            else
            {
                _timer.Stop();
                timerLabel.Visible = false;

                String query = "UPDATE Historia SET Blokada = 0 WHERE ID = " + id;
                ourDB.executeSettingData(new SqlCommand(query, ourDB.connection));
            }
        
            actualiseFlagList(currentPrivilages, tableNumber, tableNumber = selectComboBox.SelectedIndex);
        }

        private ArrayList queryQuasiParser(string input)
        {
            ArrayList output = new ArrayList();
            string temp = "";
            for (int i = 0; i < input.Length; i++)
            {
                temp += input[i];
                if (i % 2 != 0 && i > 0)
                {
                    output.Add(temp);
                    temp = "";
                }
            }
            return output;
        }

        private void actualiseFlagList(string currentPrivilages, int oldTableNumber, int newTableNumber)
        {
            if (selectWithTransfer.Checked == true) flagList.Add("S" + oldTableNumber);
            else if (select.Checked == true) flagList.Add("s" + oldTableNumber);
            if (deleteWithTransfer.Checked == true) flagList.Add("D" + oldTableNumber);
            else if (delete.Checked == true) flagList.Add("d" + oldTableNumber);
            if (insertWithTransfer.Checked == true) flagList.Add("I" + oldTableNumber);
            else if (insert.Checked == true) flagList.Add("i" + oldTableNumber);
            if (updateWithTransfer.Checked == true) flagList.Add("U" + oldTableNumber);
            else if (update.Checked == true) flagList.Add("u" + oldTableNumber);
            if (takeOver.Checked == true) flagList.Add("P" + oldTableNumber);

            if (newTableNumber == -1) return;

            if (currentPrivilages.Contains("s" + newTableNumber) || (currentPrivilages.Contains("S" + newTableNumber))) select.Visible = true;
            else select.Visible = false;
            if (currentPrivilages.Contains("d" + newTableNumber) || (currentPrivilages.Contains("D" + newTableNumber))) delete.Visible = true;
            else delete.Visible = false;
            if (currentPrivilages.Contains("i" + newTableNumber) || (currentPrivilages.Contains("I" + newTableNumber))) insert.Visible = true;
            else insert.Visible = false;
            if (currentPrivilages.Contains("u" + newTableNumber) || (currentPrivilages.Contains("U" + newTableNumber))) update.Visible = true;
            else update.Visible = false;
            if (currentPrivilages.Contains("S" + newTableNumber)) selectWithTransfer.Visible = true;
            else selectWithTransfer.Visible = false;
            if (currentPrivilages.Contains("D" + newTableNumber)) deleteWithTransfer.Visible = true;
            else deleteWithTransfer.Visible = false;
            if (currentPrivilages.Contains("I" + newTableNumber)) insertWithTransfer.Visible = true;
            else insertWithTransfer.Visible = false;
            if (currentPrivilages.Contains("U" + newTableNumber)) updateWithTransfer.Visible = true;
            else updateWithTransfer.Visible = false;
            if (currentPrivilages.Contains("P" + newTableNumber)) takeOver.Visible = true;
            else takeOver.Visible = false;

            if (flagList.Contains("s" + newTableNumber) || (flagList.Contains("S" + newTableNumber))) select.Checked = true;
            else select.Checked = false;
            if (flagList.Contains("d" + newTableNumber) || (flagList.Contains("D" + newTableNumber))) delete.Checked = true;
            else delete.Checked = false;
            if (flagList.Contains("i" + newTableNumber) || (flagList.Contains("I" + newTableNumber))) insert.Checked = true;
            else insert.Checked = false;
            if (flagList.Contains("u" + newTableNumber) || (flagList.Contains("U" + newTableNumber))) update.Checked = true;
            else update.Checked = false;
            if (flagList.Contains("S" + newTableNumber)) selectWithTransfer.Checked = true;
            else selectWithTransfer.Checked = false;
            if (flagList.Contains("D" + newTableNumber)) deleteWithTransfer.Checked = true;
            else deleteWithTransfer.Checked = false;
            if (flagList.Contains("I" + newTableNumber)) insertWithTransfer.Checked = true;
            else insertWithTransfer.Checked = false;
            if (flagList.Contains("U" + newTableNumber)) updateWithTransfer.Checked = true;
            else updateWithTransfer.Checked = false;
            if (flagList.Contains("P" + newTableNumber)) takeOver.Checked = true;
            else takeOver.Checked = false;

            flagList.Remove("S" + newTableNumber);
            flagList.Remove("s" + newTableNumber);
            flagList.Remove("D" + newTableNumber);
            flagList.Remove("d" + newTableNumber);
            flagList.Remove("U" + newTableNumber);
            flagList.Remove("u" + newTableNumber);
            flagList.Remove("I" + newTableNumber);
            flagList.Remove("i" + newTableNumber);
            flagList.Remove("P" + newTableNumber);
        }

        private void SetFlagsOK_Click(object sender, EventArgs e)
        {
            String query;

            actualiseFlagList(null, tableNumber, -1);

            String flags = ArrayListToString(flagList);

            query = "UPDATE Historia SET CzyAktualne = 0 WHERE ID = " + id +";";
            query += "Insert into Historia values (null,'" + currentUser + "', 'flagi', '-', '" + currentPrivilages + "', '" + usersParents + "', '"+ flags +"', 1, 0);";
            query += "UPDATE Historia SET Blokada = 0 WHERE ID = " + id;
            ourDB.executeSettingData(new SqlCommand(query, ourDB.connection));

            _timer.Stop();
            _timer.Dispose();

            this.Close();
        }

        private void FlagForm_MouseHover(object sender, EventArgs e)
        {
            TimerRestart();
        }

        private void FlagForm_MouseMove(object sender, MouseEventArgs e)
        {
            TimerRestart();
        }

        private String ArrayListToString(ArrayList input)
        {
            string output = "";
            foreach(string str in input)
            {
                output += str;
            }
            return output;
        }

        delegate void SetTextCallback();

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer--;
            _timer.Interval = 1000;

            SetText();

            if (timer == 0) { _timer.Stop(); ForceClose(); }
            _timer.Start();
        }

        private void selectWithTransfer_CheckedChanged(object sender, EventArgs e)
        {
            select.Checked = selectWithTransfer.Checked;
        }

        private void updateWithTransfer_CheckedChanged(object sender, EventArgs e)
        {
            update.Checked = updateWithTransfer.Checked;
        }

        private void deleteWithTransfer_CheckedChanged(object sender, EventArgs e)
        {
            delete.Checked = deleteWithTransfer.Checked;
        }

        private void insertWithTransfer_CheckedChanged(object sender, EventArgs e)
        {
            insert.Checked = insertWithTransfer.Checked;
        }

        private void TimerRestart()
        {
            timer = 10;
            _timer.Interval = 1000;
            _timer.Start();
        }

        private void SetText()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.timerLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                this.timerLabel.Text = "..." + timer;
            }
        }

        private void ForceClose()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.timerLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ForceClose);
                this.Invoke(d, new object[] { });
            }
            else
            {
                String query = "UPDATE Historia SET Blokada = 0 WHERE ID = " + id;
                ourDB.executeSettingData(new SqlCommand(query, ourDB.connection));
                this.Close(); ;
            }
        }

    }
}
