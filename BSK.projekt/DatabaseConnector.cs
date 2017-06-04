using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;

namespace BSK.projekt
{
    public class DatabaseConnector
    {
        public SqlConnection connection;
        public SqlCommand commandSQL;
        String connectionString;
        String user;
        String password;
        String instance;
        String dataBaseName;

        public DatabaseConnector()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("settings.conf");

            XmlNodeList nodelist = doc.SelectNodes("/Items"); // get all <testcase> nodes

            foreach (XmlNode node in nodelist) // for each <testcase> node
            {
                try
                {
                    user = node.SelectSingleNode("user").InnerText;
                    password = node.SelectSingleNode("password").InnerText;
                    instance = node.SelectSingleNode("instance").InnerText;
                    var sub1 = node.SelectSingleNode("ipAddress").InnerText;
                    dataBaseName = node.SelectSingleNode("dataBaseName").InnerText;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Nie odnaleziono pliku konfiguracyjnego", "xmlError", MessageBoxButtons.OK);
                }
            }
        }

        public void Connect()
        {
            this.connectionString = "user id=" + user + ";Data Source=" + instance + ";password="+ password+ ";Trusted_Connection=yes;" + "database=" + dataBaseName + "; " + "connection timeout=3; Integrated Security=false";

            int chances = 100000000;
            while (chances != 0)
            {
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    return;
                }
                catch { chances--; }
            }
            MessageBox.Show("Nie można połączyć się z bazą danych");

            /*
            connection = new SqlConnection(); //(@"Data Source=tcp:10.0.1.8\TOMASZPALUCE56A,1433;Network Library=DBMSSOCN;Initial Catalog=dbase;User ID=test"));//(@"Data Source=10.0.1.8\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=dbase;User ID=test");
            //(@"Data Source=(IP Address)\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=dbase;User ID=sa;Password=password");
            connection.ConnectionString = "user id=" + user + ";" + ";Data Source=" + instance + ";" + "Trusted_Connection=yes;" + "database=" + DatabaseName + "; " + "connection timeout=3";
            connection.Open();*/
        }


        public DataTable getData(string q)
        {
            DataTable dataTable = new DataTable();

            int chances = 100;
            while (chances != 0)
            {
                try
                {
                    SqlDataReader dataReader;
                    commandSQL = new SqlCommand(q); // utworzenie instancji SQLCommand ktora ma wykonac zapytanie podane jako parametr
                                                    // w zmiennej q

                    commandSQL.Connection = this.connection; //wskazanie połączenia do bazy danych
                    dataReader = commandSQL.ExecuteReader(); //utworzenie wskaźnika dataReader
                    dataTable.Load(dataReader);
                    return dataTable;
                }
                catch
                {
                    chances--;
                    connection.Close();
                    connection = new SqlConnection(connectionString);
                    try
                    {
                        connection.Open();
                    }
                    catch { }
                }
            }

            MessageBox.Show("Nie można połączyć się z bazą danych");
            return null;
        }

        public Boolean executeSettingData(SqlCommand command, int chances = 1000)
        {
            while(chances != 0)
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    if (e.Source.Equals(".Net SqlClient Data Provider"))
                    {   MessageBox.Show(e.Message);
                        return false;
                    }
                    chances--;
                    connection.Close();
                    connection = new SqlConnection(connectionString);
                    try
                    {
                        connection.Open();
                    }
                    catch { }
                }
            MessageBox.Show("Nie można połączyć się z bazą danych");
            return false;
        }

        public void connectionClose()
        {
            connection.Close();
        }
    }
}
