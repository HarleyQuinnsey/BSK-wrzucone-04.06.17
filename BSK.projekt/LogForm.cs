using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSK.projekt
{
    public partial class LogForm : System.Windows.Forms.Form
    {
        public string typedLogin = "", typedPassword = "";
        DatabaseConnector ourDB;
        MainForm app;

        public LogForm()
        {
            InitializeComponent();
            SqlDataAdapter adapter = new SqlDataAdapter();
            ourDB = new DatabaseConnector();
            ourDB.Connect();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            typedLogin = logInUserName.Text;
            typedPassword = Szyfruj(logInPassword.Text);

            DataTable row = ourDB.getData("SELECT * FROM Uzytkownik WHERE LoginUsera = '" + typedLogin + "' AND HasloUsera = '" + typedPassword + "'");
            if (row == null) return;

            if (row.Rows.Count.Equals(1))
            {
                app = new MainForm(this, typedLogin, ourDB);
                app.Show();
                this.Hide();
                logInUserName.Text = "";
                logInPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Niepoprawny login lub haslo.");
                logInUserName.Text = "";
                logInPassword.Text = "";
            }
        }

        public void ByeBye()
        {
            this.Close();
        }

        public void Logout()
        {
            this.Show();
            app.Hide();
        }

        static public String Szyfruj(String pass)
        {
            byte[] data = Encoding.Unicode.GetBytes(pass);
            byte[] result;
            SHA512 shaM = new SHA512Managed();
            result = shaM.ComputeHash(data);
            return BitConverter.ToString(result); ;
        }
    }
}
