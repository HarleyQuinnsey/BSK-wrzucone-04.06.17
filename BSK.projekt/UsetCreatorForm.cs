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
using System.Security.Cryptography;

namespace BSK.projekt
{
    public partial class UsetCreatorForm : System.Windows.Forms.Form
    {
        string addedLogin, addedPassword, addedPasswordAgain, nameSurname, addedPESEL, doesUserExists;
        DatabaseConnector ourDB;
        public UsetCreatorForm(DatabaseConnector _ourDB)
        {
            InitializeComponent();
            ourDB = _ourDB;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addedPESEL = textBoxID.Text;
            addedLogin = textBoxLogin.Text;
            addedPassword = textBoxPassword.Text;
            addedPasswordAgain = textBoxPasswordAgain.Text;

          
            DataTable  doesUserExists = ourDB.getData("SELECT * FROM Uzytkownik WHERE PESELpracownika = '" + addedPESEL + "'");
            DataTable doesThisLoginExists = ourDB.getData("SELECT * FROM Uzytkownik WHERE LoginUsera = '" + addedLogin + "'");
            DataTable isAnyEmployeePESEL = ourDB.getData("SELECT * FROM Pracownik WHERE PESEL = '" + addedPESEL + "'");

            if(isAnyEmployeePESEL.Rows.Count == 0)
                MessageBox.Show("Brak pracownika o podanym PESELu, bledny PESEL!");
            else if (doesUserExists.Rows.Count != 0)
                MessageBox.Show("Pracownik o danym PESELu ma juz konto uzytkownika!");
            else if(doesThisLoginExists.Rows.Count != 0)
                MessageBox.Show("Taki login jest juz w uzyciu, wybierz inny!");
            else  if (addedPassword != addedPasswordAgain)
                MessageBox.Show("Hasla sa niezgodne!");
            else
            {  
                addedPassword = this.szyfruj(addedPassword);
                string query = "INSERT INTO Uzytkownik (LoginUsera, HasloUsera, PESELpracownika) values (@LoginUsera, @HasloUsera, @PESELpracownika)";
                SqlCommand command = new SqlCommand(query, ourDB.connection);
                command.Parameters.Add("@LoginUsera", addedLogin);
                command.Parameters.Add("@HasloUsera", addedPassword);
                command.Parameters.Add("@PESELpracownika", addedPESEL);
                command.ExecuteNonQuery();

                query = "INSERT INTO Historia (Dawca, Biorca, RodzajOperacji, Uprawnienia, WszystkiePosiadaneUprawnienia, RodziceWDrzewie, CzyAktualne) values (@Dawca, @Biorca, @RodzajOperacji, @Uprawnienia, @WszystkiePosiadaneUprawnienia, @RodziceWDrzewie, 1)";
                command = new SqlCommand(query, ourDB.connection);
                command.Parameters.Add("@Dawca", "admin");
                command.Parameters.Add("@Biorca", addedLogin);
                command.Parameters.Add("@RodzajOperacji", "stworzenie konta");
                command.Parameters.Add("@Uprawnienia", "");
                command.Parameters.Add("@WszystkiePosiadaneUprawnienia", "");
                command.Parameters.Add("@RodziceWDrzewie", "95031211111, ");
                command.ExecuteNonQuery();
                this.Close();
            }


        }

        private String szyfruj(String pass)
        {
            byte[] data = Encoding.Unicode.GetBytes(pass);
            byte[] result;
            SHA512 shaM = new SHA512Managed();
            result = shaM.ComputeHash(data);
            return BitConverter.ToString(result); ;
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}
