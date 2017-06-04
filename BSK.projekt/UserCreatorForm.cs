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
    public partial class UserCreatorForm : System.Windows.Forms.Form
    {
        string addedLogin, addedPassword, addedPasswordAgain, addedPESEL;
        DatabaseConnector ourDB;
        ComboBox userComboBox;
        Label mainInfoLabel;

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            infoLabel.Visible = false;
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            infoLabel.Visible = false;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            infoLabel.Visible = false;
        }

        private void textBoxPasswordRepeat_TextChanged(object sender, EventArgs e)
        {
            infoLabel.Visible = false;
        }

        public UserCreatorForm(DatabaseConnector ourDB, ComboBox _userComboBox, Label mainInfoLabel)
        {
            InitializeComponent();
            this.ourDB = ourDB;
            this.userComboBox = _userComboBox;
            this.mainInfoLabel = mainInfoLabel;
        }

        long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            long pesel = LongRandom(50000000000, 45000000000,rnd);
            addedPESEL = "" + pesel;
            addedLogin = textBoxLogin.Text;
            addedPassword = textBoxPassword.Text;
            addedPasswordAgain = textBoxPasswordRepeat.Text;


            //DataTable doesUserExists = ourDB.getData("SELECT * FROM Uzytkownik WHERE PESELpracownika = '" + addedPESEL + "'");
            DataTable doesThisLoginExists = ourDB.getData("SELECT * FROM Uzytkownik WHERE LoginUsera = '" + addedLogin + "'");
            //DataTable isAnyEmployeePESEL = ourDB.getData("SELECT * FROM Pracownik WHERE PESEL = '" + addedPESEL + "'");

           // if (isAnyEmployeePESEL.Rows.Count == 0)
           //     MessageBox.Show("Brak pracownika o podanym PESELu, bledny PESEL!");
           // else if (doesUserExists.Rows.Count != 0)
           //     MessageBox.Show("Pracownik o danym PESELu ma juz konto uzytkownika!");
           // else 
            if (doesThisLoginExists.Rows.Count != 0)
                MessageBox.Show("Taki login jest juz w uzyciu, wybierz inny!");
            else if (addedPassword != addedPasswordAgain)
                MessageBox.Show("Hasla sa niezgodne!");
            else 
            {
                string query = pracownikGenerator();
                if (ourDB.executeSettingData(new SqlCommand(query, ourDB.connection)) == false) return;
                addedPassword = LogForm.Szyfruj(addedPassword);

                string adminPesel = ourDB.getData("SELECT PESEL FROM Pracownik WHERE Stanowisko = 'admin'").Rows[0][0].ToString();

                query = "INSERT INTO Uzytkownik values ('" + addedLogin +"','"+ addedPassword + "','" + addedPESEL + "',1);";//(@LoginUsera, @HasloUsera, @PESELpracownika, 1)";
                query += "INSERT INTO Historia  values ('admin', '"+ addedLogin + "', 'stworzenie konta', '', '', '', '', 1,0)"; //"+ adminPesel + ",', '', 1,0)";
                ourDB.executeSettingData(new SqlCommand(query, ourDB.connection));

                userComboBox.Items.Add(addedLogin);
                mainInfoLabel.Text = "Utworzono nowego \n użytkownika";
                MessageBox.Show("Utworzono nowego użytkownika");
            }


            infoLabel.Visible = true;
            //textBoxID.Text = "";
            textBoxLogin.Text = "";
            textBoxPassword.Text = ""; 
            textBoxPasswordRepeat.Text = "";
        }
            

        private string pracownikGenerator()
        {
            ArrayList imiona = new ArrayList();
            ArrayList nazwiska = new ArrayList();
            ArrayList stanowiska = new ArrayList();
            ArrayList lokale = new ArrayList();
            imiona.Add("Tomek");
            imiona.Add("Weronika");
            imiona.Add("Wojtek");
            imiona.Add("Kasia");
            imiona.Add("Maciek");
            nazwiska.Add("Plewka");
            nazwiska.Add("Czajka");
            nazwiska.Add("Paluch");
            nazwiska.Add("Berger");
            stanowiska.Add("sprzątacz/ka");
            stanowiska.Add("kelner/ka");
            stanowiska.Add("kucharz/ka");
            lokale.Add("Surfburger");
            lokale.Add("Surfburger2");
            lokale.Add("Surfburger3");
            lokale.Add("Surfburger4");
            lokale.Add("Surfburger5");
            int pensja = rnd.Next(2100, 5001);
            return "INSERT INTO PRACOWNIK VALUES (" + addedPESEL + ", '" + imiona[rnd.Next(0, imiona.Count)] + ""+nazwiska[rnd.Next(0, nazwiska.Count)] + "','"+stanowiska[rnd.Next(0, stanowiska.Count)] + "',"+pensja+",'" + lokale[rnd.Next(0, lokale.Count)] + "')";
        }

        Random rnd = new Random();
    }
}

