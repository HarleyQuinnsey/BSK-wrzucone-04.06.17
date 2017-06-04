using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSK.projekt
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        string recipient, typedLogin, mode = "preview", query;//recipient to biorca
        bool goOn = false; //goOn jest po to, że jak użytkownik zaznaczy uprawnienie, którego nie ma i kliknie "przekaż" to nie powstanie wpis w bazie

        DataTable queryResult;
        Color stdclr = Color.LightGray;
        Color activeModeClr = Color.LightBlue;
        DatabaseConnector ourDB = null;
        LogForm logForm;

        ArrayList buttonList = new ArrayList();
        public MainForm(LogForm log, string typedLogin, DatabaseConnector ourDB)
        {
            InitializeComponent();

            this.ourDB = ourDB;
            this.typedLogin = typedLogin;
            this.logForm = log;

            if (typedLogin.Equals("admin"))
            {
                add.Visible = true;
                usun.Visible = true;
            }

            selectComboBox.Items.Add("Faktura");
            selectComboBox.Items.Add("Historia");
            selectComboBox.Items.Add("Potrawa");
            selectComboBox.Items.Add("Pracownik");
            selectComboBox.Items.Add("Restauracja");
           
            tableNameActivitiesOnBase.Items.Add("Faktura");
            tableNameActivitiesOnBase.Items.Add("Historia");
            tableNameActivitiesOnBase.Items.Add("Potrawa");
            tableNameActivitiesOnBase.Items.Add("Pracownik");
            tableNameActivitiesOnBase.Items.Add("Restauracja");
            tableNameActivitiesOnBase.Items.Add("TECHNICZNE");
            //tableNameActivitiesOnBase.Items.Add("Uzytkownik");

            buttonList.Add(selectCheckBox);
            buttonList.Add(updateCheckBox);
            buttonList.Add(deleteCheckBox);
            buttonList.Add(insertCheckBox);
            buttonList.Add(passSelectCheckBox);
            buttonList.Add(passUpdateCheckBox);
            buttonList.Add(passDeleteCheckBox);
            buttonList.Add(passInsertCheckBox);
            buttonList.Add(takeOverCheckBox);

            DataTable table = null;
            while (table == null)
                table = ourDB.getData("SELECT LoginUsera FROM Uzytkownik WHERE CzyAktywny = 1"); 
            
            foreach (DataRow row in table.Rows) // Loop over the rows.
            {
                String str = row.ItemArray[0].ToString();
                if (!str.Equals(typedLogin)) userComboBox.Items.Add(str); 
            }

            privillagesPreviewButton.BackColor = activeModeClr;
            infoLabel.Location = new Point(155, 150);

            headerLabel.Text += typedLogin + "!";
        }
            
        private void usun_Click(object sender, EventArgs e)
        {
            recipient = userComboBox.Text;
            queryResult = ourDB.getData("SELECT * FROM Historia WHERE Biorca = '" + recipient + "' and CzyAktualne = 1");
            if (queryResult == null || recipient.Equals("Wybierz użytkownika")) return;

            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć użytkownika " + recipient, "Usuwanie użytkownika", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //wpis do bazy
                query = "UPDATE Historia SET CzyAktualne = 0 WHERE Biorca = '" + recipient + "' and CzyAktualne = 1;";
                string parents = "";
                if (queryResult.Rows.Count > 1) parents = queryResult.Rows[0][6].ToString();
                query += "INSERT INTO Historia values ('admin', '" + recipient + "', 'dezaktywacja konta', '', '', '" + parents + "', '', 1,0);";
                query += "UPDATE Uzytkownik SET CzyAktywny = 0 WHERE LoginUsera = '" + recipient + "'";
                ourDB.executeSettingData(new SqlCommand(query, ourDB.connection));

                userComboBox.Items.Remove(recipient);

                //infoLabel.Visible = true;
                //infoLabel.Text = "Usunięto użytkownika";
                MessageBox.Show("Usunięto użytkownika");
                userComboBox.Text = "Wybierz uzytkownika.";
                userComboBox.SelectedIndex = -1;
            }  
        }

        private void add_Click(object sender, EventArgs e)
        {
            UserCreatorForm cnu = new UserCreatorForm(ourDB, userComboBox, infoLabel);
            cnu.Show();
        }


// ZARZĄDZANIE UPRAWNIENIAMI start ----------------------------------------------------------------------------------------------------------------

        private void przejmij_Click(object sender, EventArgs e)
        {
            mode = "takeover";
            centralCheckBoxesController();
            przejmij.BackColor = activeModeClr;
            przekaz.BackColor = stdclr;
            privillagesPreviewButton.BackColor = stdclr;

            foreach (Object o in buttonList)
                ((CheckBox)o).Checked = false;
        }


        private void przekaz_Click(object sender, EventArgs e)
        {
            mode = "pass";
            centralCheckBoxesController();
            przekaz.BackColor = activeModeClr;
            przejmij.BackColor = stdclr;
            privillagesPreviewButton.BackColor = stdclr;

            foreach (Object o in buttonList)
                ((CheckBox)o).Checked = false;
        }

        private void privillagesPreviewButton_Click(object sender, EventArgs e)
        {
            mode = "preview";
            centralCheckBoxesController();
            privillagesPreviewButton.BackColor = activeModeClr;
            przejmij.BackColor = stdclr;
            przekaz.BackColor = stdclr;

            foreach (Object o in buttonList)
                ((CheckBox)o).Checked = false;
        }

        private void centralCheckBoxesController()
        {
            string thatOtherGuy = userComboBox.Text;
            int tableNumber = selectComboBox.SelectedIndex;
            string ownedPrivillages = "";

            try
            {
                if (tableNumber == -1) { MessageBox.Show("Wybierz tabelę"); return; }
                if (mode.Equals("takeover"))
                {
                    queryResult = ourDB.getData("SELECT Flagi FROM Historia WHERE Biorca = '" + thatOtherGuy + "' and CzyAktualne = 1"); //dopisac, ze jak to admin, to ownedPowers=wszystkie
                    ownedPrivillages = queryResult.Rows[0][0].ToString();

                    queryResult = ourDB.getData("SELECT Blokada FROM Historia WHERE Biorca = '" + thatOtherGuy + "' and CzyAktualne = 1");
                    string blabla = queryResult.Rows[0][0].ToString();
                    if (blabla.Equals("True"))
                    { infoLabel.Text = "Wybrany zasób jest \n tymczasowo \n niedostępny"; infoLabel.Visible = true; tableNumber = -2; }
                    else infoLabel.Visible = false;
                    ExecuteButton.Visible = true;
                }
                else if (mode.Equals("pass"))
                {
                    infoLabel.Visible = false;
                    queryResult = ourDB.getData("SELECT WszystkiePosiadaneUprawnienia FROM Historia WHERE Biorca = '" + typedLogin + "' and CzyAktualne = 1"); //dopisac, ze jak to admin, to ownedPowers=wszystkie
                    ownedPrivillages = queryResult.Rows[0][0].ToString();
                    ExecuteButton.Visible = true;
                }
                else if (mode.Equals("preview"))
                {
                    infoLabel.Visible = false;
                    queryResult = ourDB.getData("SELECT WszystkiePosiadaneUprawnienia FROM Historia WHERE Biorca = '" + thatOtherGuy + "' and CzyAktualne = 1"); //dopisac, ze jak to admin, to ownedPowers=wszystkie
                    ownedPrivillages = queryResult.Rows[0][0].ToString();
                    ExecuteButton.Visible = false;
                }

                if (mode.Equals("takeover"))
                {
                    if (ownedPrivillages.Contains("s" + tableNumber) || (ownedPrivillages.Contains("S" + tableNumber))) selectCheckBox.Visible = true;
                    else selectCheckBox.Visible = false;
                    if (ownedPrivillages.Contains("u" + tableNumber) || (ownedPrivillages.Contains("U" + tableNumber))) updateCheckBox.Visible = true;
                    else updateCheckBox.Visible = false;
                    if (ownedPrivillages.Contains("d" + tableNumber) || (ownedPrivillages.Contains("D" + tableNumber))) deleteCheckBox.Visible = true;
                    else deleteCheckBox.Visible = false;
                    if (ownedPrivillages.Contains("i" + tableNumber) || (ownedPrivillages.Contains("I" + tableNumber))) insertCheckBox.Visible = true;
                    else insertCheckBox.Visible = false;
                    if ((ownedPrivillages.Contains("S" + tableNumber))) passSelectCheckBox.Visible = true;
                    else passSelectCheckBox.Visible = false;
                    if ((ownedPrivillages.Contains("U" + tableNumber))) passUpdateCheckBox.Visible = true;
                    else passUpdateCheckBox.Visible = false;
                    if ((ownedPrivillages.Contains("D" + tableNumber))) passDeleteCheckBox.Visible = true;
                    else passDeleteCheckBox.Visible = false;
                    if ((ownedPrivillages.Contains("I" + tableNumber))) passInsertCheckBox.Visible = true;
                    else passInsertCheckBox.Visible = false;
                    if ((ownedPrivillages.Contains("P" + tableNumber))) takeOverCheckBox.Visible = true;
                    else takeOverCheckBox.Visible = false;
                }
                else if (mode.Equals("pass") || mode.Equals("preview"))
                {
                    if ((ownedPrivillages.Contains("S" + tableNumber)))
                    {
                        passSelectCheckBox.Visible = true;
                        selectCheckBox.Visible = true;
                    }
                    else
                    {
                        passSelectCheckBox.Visible = false;
                        selectCheckBox.Visible = false;
                    }
                    if ((ownedPrivillages.Contains("U" + tableNumber)))
                    {
                        passUpdateCheckBox.Visible = true;
                        updateCheckBox.Visible = true;
                    }
                    else
                    {
                        passUpdateCheckBox.Visible = false;
                        updateCheckBox.Visible = false;
                    }
                    if ((ownedPrivillages.Contains("D" + tableNumber)))
                    {
                        passDeleteCheckBox.Visible = true;
                        deleteCheckBox.Visible = true;
                    }
                    else
                    {
                        passDeleteCheckBox.Visible = false;
                        deleteCheckBox.Visible = false;
                    }
                    if ((ownedPrivillages.Contains("I" + tableNumber)))
                    {
                        passInsertCheckBox.Visible = true;
                        insertCheckBox.Visible = true;
                    }
                    else
                    {
                        passInsertCheckBox.Visible = false;
                        insertCheckBox.Visible = false;
                    }
                    if ((ownedPrivillages.Contains("P" + tableNumber)))
                    {
                        takeOverCheckBox.Visible = true;
                        takeOverCheckBox.Visible = true;
                    }
                    else
                    {
                        takeOverCheckBox.Visible = false;
                        takeOverCheckBox.Visible = false;
                    }
                }
                if (mode.Equals("preview"))
                {
                    foreach (Object o in buttonList)
                        ((CheckBox)o).AutoCheck = false;
                }
                else
                {
                    foreach (Object o in buttonList)
                        ((CheckBox)o).AutoCheck = true;
                }
            }
            catch { MessageBox.Show("Wybierz użytkownika"); }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (mode.Equals("pass")) { WerkasFunction();}
            else if (mode.Equals("takeover")) { takeOverFunction(); }
        }



        private void WerkasFunction()
        {
            queryResult = ourDB.getData("SELECT * FROM Historia WHERE Biorca = '" + typedLogin + "' and CzyAktualne = 1");
            if (queryResult == null) return;
            string ownedPowers = queryResult.Rows[0][5].ToString();
            string powersToPass = "", powersToPassTEMP = "", chosenTable = "";

            chosenTable = selectComboBox.SelectedIndex.ToString();
            recipient = userComboBox.Text;

            string textToShow = "Uzytkownik " + recipient + " posiada juz uprawnienie ";
            bool showText = false;
            string parents = queryResult.Rows[0][6].ToString();

            queryResult = ourDB.getData("SELECT PESELpracownika FROM Uzytkownik WHERE LoginUsera = '" + recipient + "'");
            if (queryResult == null) return;
            bool IcannotpassToThisPerson = parents.Contains(queryResult.Rows[0][0].ToString());

            //wyciągnięcie do stringa wcześniejszych uprawnień osoby, której chcemy coś przekazać
           /* string earlierPowersOfRecipient = "";
            DataTable temporaryQueryResult = ourDB.getData("SELECT WszystkiePosiadaneUprawnienia FROM Historia WHERE Biorca = '" + recipient + "' and CzyAktualne = 1");
            if (temporaryQueryResult.Rows.Count != 0) earlierPowersOfRecipient = temporaryQueryResult.Rows[0][0].ToString();
           */ string earlierPowersOfRecipient = ourDB.getData("SELECT WszystkiePosiadaneUprawnienia FROM Historia WHERE Biorca = '" + recipient + "' and CzyAktualne = 1").Rows[0][0].ToString();
            string earlierFlagsOfRecipient = ourDB.getData("SELECT Flagi FROM Historia WHERE Biorca = '" + recipient + "' and CzyAktualne = 1").Rows[0][0].ToString();

            if (!IcannotpassToThisPerson) //jesli osoba, ktorej chce cos przekazac nie jest moim rodzicem w drzewie
            {
                //SELECT
                if (selectCheckBox.Checked)
                {
                    if (ownedPowers.Contains("S" + chosenTable))
                    {
                        if (passSelectCheckBox.Checked)
                        {
                            powersToPassTEMP += "S" + chosenTable;
                            goOn = true;
                        }
                        else
                        {
                            powersToPassTEMP += "s" + chosenTable;
                            goOn = true;
                        }

                    }
                    else if (ownedPowers.Contains("s" + chosenTable))
                    {
                        if (!passSelectCheckBox.Checked)
                        {
                            powersToPassTEMP += "s" + chosenTable;
                            goOn = true;
                        }
                        else
                            MessageBox.Show("Nie posiadasz uprawnienia select z możliwością przekazania dalej");  //może zamiast miliona komunikatów zrobić odpowiednie checjboxy nieaktywne?    
                    }
                    else
                        MessageBox.Show("Nie posiadasz wogóle uprawnienia select");

                    if (earlierPowersOfRecipient.Contains(powersToPassTEMP))
                    {
                        textToShow += "select";
                        showText = true;
                    }
                    else
                        powersToPass += powersToPassTEMP;
                    powersToPassTEMP = "";
                }

                //UPDATE
                if (updateCheckBox.Checked)
                {
                    if (ownedPowers.Contains("U" + chosenTable))
                    {
                        if (passUpdateCheckBox.Checked)
                        {
                            powersToPassTEMP += "U" + chosenTable;
                            goOn = true;
                        }
                        else
                        {
                            powersToPassTEMP += "u" + chosenTable;
                            goOn = true;
                        }
                    }
                    else if (ownedPowers.Contains("u" + chosenTable))
                    {
                        if (!passUpdateCheckBox.Checked)
                        {
                            powersToPassTEMP += "u" + chosenTable;
                            goOn = true;
                        }
                        else
                            MessageBox.Show("Nie posiadasz uprawnienia update z możliwością przekazania dalej");  //może zamiast miliona komunikatów zrobić odpowiednie checjboxy nieaktywne?    
                    }
                    else
                        MessageBox.Show("Nie posiadasz wogóle uprawnienia update");

                    if (earlierPowersOfRecipient.Contains(powersToPassTEMP))
                    {
                        textToShow += ", update";
                        showText = true;
                    }
                    else
                        powersToPass += powersToPassTEMP;
                    powersToPassTEMP = "";
                }

                //DELETE    
                if (deleteCheckBox.Checked)
                {
                    if (ownedPowers.Contains("D" + chosenTable))
                    {
                        if (passDeleteCheckBox.Checked)
                        {
                            powersToPassTEMP += "D" + chosenTable;
                            goOn = true;
                        }
                        else
                        {
                            powersToPassTEMP += "d" + chosenTable;
                            goOn = true;
                        }
                    }
                    else if (ownedPowers.Contains("d" + chosenTable))
                    {
                        if (!passDeleteCheckBox.Checked)
                        {
                            powersToPassTEMP += "d" + chosenTable;
                            goOn = true;
                        }
                        else
                            MessageBox.Show("Nie posiadasz uprawnienia delete z możliwością przekazania dalej");  //może zamiast miliona komunikatów zrobić odpowiednie checjboxy nieaktywne?    
                    }
                    else
                        MessageBox.Show("Nie posiadasz wogóle uprawnienia delete");

                    if (earlierPowersOfRecipient.Contains(powersToPassTEMP))
                    {
                        textToShow += ", delete";
                        showText = true;
                    }
                    else
                        powersToPass += powersToPassTEMP;
                    powersToPassTEMP = "";
                }

                //INSERT   
                if (insertCheckBox.Checked)
                {
                    if (ownedPowers.Contains("I" + chosenTable))
                    {
                        if (passInsertCheckBox.Checked)
                        {
                            powersToPassTEMP += "I" + chosenTable;
                            goOn = true;
                        }
                        else
                        {
                            powersToPassTEMP += "i" + chosenTable;
                            goOn = true;
                        }
                    }
                    else if (ownedPowers.Contains("i" + chosenTable))
                    {
                        if (!passInsertCheckBox.Checked)
                        {
                            powersToPassTEMP += "i" + chosenTable;
                            goOn = true;
                        }
                        else
                            MessageBox.Show("Nie posiadasz uprawnienia insert z możliwością przekazania dalej");  //może zamiast miliona komunikatów zrobić odpowiednie checjboxy nieaktywne?    
                    }
                    else
                        MessageBox.Show("Nie posiadasz wogóle uprawnienia insert");

                    if (earlierPowersOfRecipient.Contains(powersToPassTEMP))
                    {
                        textToShow += ", insert";
                        showText = true;
                    }
                    else
                        powersToPass += powersToPassTEMP;
                    powersToPassTEMP = "";
                }

                //TAKEOVER   
                if (takeOverCheckBox.Checked)
                {
                    if (ownedPowers.Contains("P" + chosenTable))
                    {
                        powersToPassTEMP += "P" + chosenTable;
                        goOn = true;
                    }
                    else
                        MessageBox.Show("Nie posiadasz wogóle uprawnienia przejmowania");

                    if (earlierPowersOfRecipient.Contains(powersToPassTEMP))
                    {
                        textToShow += ", insert";
                        showText = true;
                    }
                    else
                        powersToPass += powersToPassTEMP;
                    powersToPassTEMP = "";
                }

                if (showText)
                    MessageBox.Show(textToShow + " do tabeli " + selectComboBox.Text + " .\nPominieto przekazanie wymienionych uprawnien.");
            }
            else
                MessageBox.Show("Nie możesz przekazać nic tej osobie.");//bo ta osoba jest Twoim rodziecem w drzewie


            if (recipient.Equals(""))
            {
                goOn = false;
                MessageBox.Show("Wpisz login użytkownika, na którym chcesz wykonać działanie!");
            }

            if (goOn && !powersToPass.Equals(""))
            {
                //pobiera rodziców biorcy
                queryResult = ourDB.getData("SELECT * FROM Historia WHERE Biorca = '" + recipient + "' and CzyAktualne = 1");
                parents = queryResult.Rows[0][6].ToString();

                //ustawianie poprzedniego wpisu o uprawnieniach biorcy, jako nieaktualny
                query = "UPDATE Historia SET CzyAktualne = 0 WHERE Biorca = '"+recipient+"' and CzyAktualne = 1;";

                //pobranie peselu osoby, które robi aktualnie przekazywanie
                //string newParent = ourDB.getData("SELECT PESELpracownika FROM Uzytkownik WHERE LoginUsera = '" + typedLogin + "'").Rows[0][0].ToString();
                string newParent = typedLogin;
                newParent = pseudoRecursiveParentialTest(typedLogin, parents);

                //wpis do bazy
                query += "INSERT INTO Historia values ('"+ typedLogin+ "', '" + recipient+ "', 'przekaz', '" + powersToPass+ "', '" + earlierPowersOfRecipient + powersToPass + "', '" + parents + "" + newParent + "', '"+ earlierFlagsOfRecipient+"', 1, 0)";
                ourDB.executeSettingData(new SqlCommand(query, ourDB.connection));

                /*
                //usuwa flagi dawcy
                query = "UPDATE Historia SET Flagi = '' WHERE Biorca = @BiorcaUpdate and CzyAktualne = 1";
                command = new SqlCommand(query, ourDB.connection);
                command.Parameters.Add("@BiorcaUpdate", typedLogin);
                command.ExecuteNonQuery();*/

                MessageBox.Show("Przekazywanie wykonano");
               /* int counter = 0;

                while (counter <= 500)
                {
                    infoLabel.Visible = true;
                    infoLabel.Text = "Przekazywanie \n wykonano";
                    counter++;
                }*/
                infoLabel.Visible = false;
                selectCheckBox.Checked = false;
                passSelectCheckBox.Checked = false;
                updateCheckBox.Checked = false;
                passUpdateCheckBox.Checked = false;
                deleteCheckBox.Checked = false;
                passDeleteCheckBox.Checked = false;
                insertCheckBox.Checked = false;
                passInsertCheckBox.Checked = false;
                takeOverCheckBox.Checked = false;
            }
        }

        private string pseudoRecursiveParentialTest(string login, string parents)
        {
            string[] result = parents.Split(new string[] { ", " }, StringSplitOptions.None);
           
            HashSet<String> parentSet = new HashSet<String>();
            HashSet<String> tempChildrenSet = new HashSet<String>();

            foreach (string str in result)
                parentSet.Add(str);

            int min = 0, max = parentSet.Count;
            while (min != max)
            {
                foreach (String str in parentSet)
                {
                    string newParents = "";
                    DataTable table = ourDB.getData("SELECT RodziceWDrzewie FROM Historia WHERE Biorca = '" + str + "' and CzyAktualne=1");
                    if(table.Rows.Count>0) newParents = table.Rows[0][0].ToString();
                    result = newParents.Split(new string[] { ", " }, StringSplitOptions.None);

                    foreach (string parent in result)
                        if (!parent.Equals("")) tempChildrenSet.Add(parent);
                }
                min = max;
                parentSet.UnionWith(tempChildrenSet);
                max = parentSet.Count;
            }
            if (parentSet.Contains(login)) return "";
            else return login += ", ";
        }

        private void takeOverFunction()
        {
            string ourPrivillages = "";
            string ourParents = "";
            string ourFlags = "";
            string thatOtherGuy = userComboBox.Text;
            string thatOtherGuysPrivillages = "";
            string thatOtherGuysParents = "";
            string thatOtherGuysFlags = "";
            string query = "";
            int ourID = -1;
            int thatOtherGuyID = -1;
            int tableNumber = selectComboBox.SelectedIndex;

            DataTable queryResult1 = ourDB.getData("SELECT * FROM Historia WHERE Biorca = '" + typedLogin + "' and CzyAktualne = '1'");
            DataTable queryResult2 = ourDB.getData("SELECT * FROM Historia WHERE Biorca = '" + thatOtherGuy + "' and CzyAktualne = '1'");

            try
            {
                ourID = Int32.Parse(queryResult1.Rows[0][0].ToString());
                ourParents = queryResult1.Rows[0][6].ToString();
                ourPrivillages = queryResult1.Rows[0][5].ToString();
                ourFlags = queryResult1.Rows[0][7].ToString();
            }
            catch { }
            try
            {
                thatOtherGuyID = Int32.Parse(queryResult2.Rows[0][0].ToString());
                thatOtherGuysPrivillages = queryResult2.Rows[0][5].ToString();
                thatOtherGuysParents = queryResult2.Rows[0][6].ToString();
                thatOtherGuysFlags = queryResult2.Rows[0][7].ToString();
            }
            catch { }

            HashSet<String> ourPrivillagesSet = queryQuasiParser(ourPrivillages);
            HashSet<String> priviSet2 = queryQuasiParser(thatOtherGuysPrivillages);
            HashSet<String> thatOtherGuysFlagsSet = queryQuasiParser(thatOtherGuysFlags);
            HashSet<String> selectedPrivillages = new HashSet<string>();
            HashSet<String> toRemove = new HashSet<string>();

            if (passSelectCheckBox.Checked == true) selectedPrivillages.Add("S" + tableNumber);
            else if (selectCheckBox.Checked == true) selectedPrivillages.Add("s" + tableNumber);
            if (passUpdateCheckBox.Checked == true) selectedPrivillages.Add("U" + tableNumber);
            else if (updateCheckBox.Checked == true) selectedPrivillages.Add("u" + tableNumber);
            if (passDeleteCheckBox.Checked == true) selectedPrivillages.Add("D" + tableNumber);
            else if (deleteCheckBox.Checked == true) selectedPrivillages.Add("d" + tableNumber);
            if (passInsertCheckBox.Checked == true) selectedPrivillages.Add("I" + tableNumber);
            else if (insertCheckBox.Checked == true) selectedPrivillages.Add("i" + tableNumber);

            //ustalania części wspólnej uprawnień
            foreach (String str in ourPrivillagesSet)
            {
                foreach (String flag in selectedPrivillages)
                {
                    if (str.Equals(flag)) toRemove.Add(flag); //<------- co robimy z duplikatami?
                    if (str.Equals(FirstLetterToUpper(flag))) toRemove.Add(flag);
                }
            }

            //usuwanie powtórzonych lub słabszych uprawnień
            if (toRemove.Count != 0)
            {
                foreach (String str in toRemove)
                {
                    selectedPrivillages.Remove(str);
                }
            }

            //łączenie 
            ourPrivillagesSet.UnionWith(selectedPrivillages);
            
            //odbieranie uprawnień dawcy 
            if (!thatOtherGuy.Equals("admin") && selectedPrivillages.Count != 0)
            { 
                foreach (String str in selectedPrivillages)
                {
                    priviSet2.Remove(str);
                    priviSet2.Remove(FirstLetterToUpper(str));
                }
            }

            //ustalanie nowej flagi dawcy
            if (!thatOtherGuy.Equals("admin") && selectedPrivillages.Count != 0)
            {
                foreach (String str in selectedPrivillages)
                {
                    thatOtherGuysFlagsSet.Remove(str);
                    thatOtherGuysFlagsSet.Remove(FirstLetterToUpper(str));
                }
            }

            //obsługa dzieci
            //zrobić listę dzieci
            //znaleźć PESEL typedUsera
            HashSet<String> childrenSet = new HashSet<String>();
            HashSet<String> tempChildrenSet = new HashSet<String>();
            HashSet<String> tempSet = childrenSet;
            DataTable queryResult3 = ourDB.getData("SELECT Biorca, RodziceWDrzewie FROM Historia WHERE CzyAktualne = 1;");

            for(int i=0; i < queryResult3.Rows.Count; i++)
                if (queryResult3.Rows[i][1].ToString().Contains(thatOtherGuy)) childrenSet.Add(queryResult3.Rows[i][0].ToString());

            int min = 0, max = childrenSet.Count;
            while (true)
            {
                foreach (String str in tempSet)
                {
                    for (int i = 0; i < queryResult3.Rows.Count; i++)
                        if (queryResult3.Rows[i][1].ToString().Contains(str)) tempChildrenSet.Add(queryResult3.Rows[i][0].ToString());

                   /* string kurczak = ourDB.getData("SELECT PESELPracownika FROM Uzytkownik WHERE LoginUsera = '" + str + "';").Rows[0][0].ToString();

                    for (int i = 0; i < queryResult3.Rows.Count; i++)
                         if (queryResult3.Rows[i][1].ToString().Contains(kurczak))
                            tempChildrenSet.Add(queryResult3.Rows[i][0].ToString());
                    */
                }
                min = max;
                childrenSet.UnionWith(tempChildrenSet);
                max = childrenSet.Count;

                if (min == max) break;

                tempSet = new HashSet<String>();
                foreach (String str in tempChildrenSet)
                    tempSet.Add(str);
            }

            String stringedSelectedPrivillages = HashSetToString(selectedPrivillages);

            foreach (String str in childrenSet)
            {
                if (str.Equals(typedLogin) || str.Equals(typedLogin)) continue;
                query += "UPDATE Historia SET CzyAktualne = 0 WHERE CzyAktualne = 1 and Biorca = '" + str + "';";
                   
                queryResult3 = ourDB.getData("SELECT RodziceWDrzewie, Flagi, WszystkiePosiadaneUprawnienia FROM Historia WHERE CzyAktualne = 1 and Biorca = '" + str + "';");

                string parents = queryResult3.Rows[0][0].ToString();
                String flags = queryResult3.Rows[0][1].ToString(); flags = blablabla(flags, stringedSelectedPrivillages);
                String privilages = queryResult3.Rows[0][2].ToString(); privilages = blablabla(privilages, stringedSelectedPrivillages);
                query += "Insert into Historia values(null, '" + str + "', 'stan', '-', '" + privilages + "', '" + parents + "', '" + flags + "', 1, 0); ";
            }
            if (ourID!=-1)
                query += "UPDATE Historia SET CzyAktualne = 0 WHERE ID = " + ourID;

            query += "UPDATE Historia SET CzyAktualne = 0 WHERE ID = " + thatOtherGuyID + ";";
            query += "Insert into Historia values (null,'" + thatOtherGuy + "', 'stan', '-', '" + HashSetToString(priviSet2) + "', '" + thatOtherGuysParents + "', '" + HashSetToString(thatOtherGuysFlagsSet) + "', 1,0);";
            query += "Insert into Historia values ('" + thatOtherGuy + "','" + typedLogin + "', 'przejmij', '" + stringedSelectedPrivillages + "', '" + HashSetToString(ourPrivillagesSet) + "', '" + ourParents + "', '', 1,0)";

            if (ourDB.executeSettingData(new SqlCommand(query, ourDB.connection)) == false) return;

            MessageBox.Show("Przejęcie wykonano");
        }

        //Funkcja zwraca uprawnienia/flagi bez tych zawartych w stringu elements
        private String blablabla(String input, string elements)
        {
            string bigElements = elements.ToUpper();
            HashSet<String> inputSet = queryQuasiParser(input);
            HashSet<String> elementSet = queryQuasiParser(elements);
            HashSet<String> bigElementSet = queryQuasiParser(bigElements);
            inputSet.ExceptWith(elementSet);
            inputSet.ExceptWith(bigElementSet);
            return HashSetToString(inputSet);
        }

        private String HashSetToString(HashSet<String> input)
        {
            String output = "";
            foreach (String str in input)
            {
                output += str;
            }
            return output;
        }

        private HashSet<String> queryQuasiParser(string input)
        {
            HashSet<String> priviSet = new HashSet<string>();
            string temp = "";
            for (int i = 0; i < input.Length; i++)
            {
                temp += input[i];
                if (i % 2 != 0 && i>0)
                {
                    priviSet.Add(temp);
                    temp = "";
                }
            }
            return priviSet;
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

// ZARZĄDZANIE UPRAWNIENIAMI koniec ----------------------------------------------------------------------------------------------------------------

        private void tableNameActivitiesOnBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            newRowCount = 0;
            questionResult.AllowUserToAddRows = true;
          //  availableColumns.Text = "";
            int tableNumber = tableNameActivitiesOnBase.SelectedIndex;
            string tableName = tableNameActivitiesOnBase.Text;

            if (tableName.Equals("TECHNICZNE"))
            {
                SqlDataAdapter dataAdapter;
                var select = "SELECT TOP 20 * FROM " + tableName;
                var c = ourDB.connection; // Your Connection String here
                dataAdapter = new SqlDataAdapter(select, c);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                //questionResult.ReadOnly = true;
                questionResult.DataSource = ds.Tables[0];
                oldRowCount = ds.Tables[0].Rows.Count;
                searchButton.Visible = true;
                questionResult.AllowUserToAddRows = false;
                questionResult.AllowUserToDeleteRows = false;
                questionResult.ReadOnly = true;
                return;
            }
            queryResult = ourDB.getData("SELECT WszystkiePosiadaneUprawnienia FROM Historia WHERE Biorca = '" + typedLogin + "' and CzyAktualne = '1'");
            if (queryResult == null) return;
            try
            {
                string powers = queryResult.Rows[0][0].ToString();

                if (powers.Contains("s" + tableNumber) || (powers.Contains("S" + tableNumber))) selectButton.BackColor = Color.Green;
                else selectButton.BackColor = Color.Red;
                if (powers.Contains("d" + tableNumber) || (powers.Contains("D" + tableNumber))) deleteButton.BackColor = Color.Green;
                else deleteButton.BackColor = Color.Red;
                if (powers.Contains("i" + tableNumber) || (powers.Contains("I" + tableNumber))) insertButton.BackColor = Color.Green;
                else insertButton.BackColor = Color.Red;
                if (powers.Contains("u" + tableNumber) || (powers.Contains("U" + tableNumber))) updateButton.BackColor = Color.Green;
                else updateButton.BackColor = Color.Red;
                if (powers.Contains("S" + tableNumber)) selectWithTransferButton.BackColor = Color.Green;
                else selectWithTransferButton.BackColor = Color.Red;
                if (powers.Contains("D" + tableNumber)) deleteWithTransferButton.BackColor = Color.Green;
                else deleteWithTransferButton.BackColor = Color.Red;
                if (powers.Contains("I" + tableNumber)) insertWithTransferButton.BackColor = Color.Green;
                else insertWithTransferButton.BackColor = Color.Red;
                if (powers.Contains("U" + tableNumber)) updateWithTransferButton.BackColor = Color.Green;
                else updateWithTransferButton.BackColor = Color.Red;
                if (powers.Contains("P" + tableNumber)) takeOverButton.BackColor = Color.Green;
                else takeOverButton.BackColor = Color.Red;

                questionResult.AllowUserToAddRows = false;
                questionResult.AllowUserToDeleteRows = false;
                questionResult.ReadOnly = true;

                addNewRowButton.Visible = false;
                searchButton.Visible = false;

                if (powers.Contains("s" + tableNumber) || (powers.Contains("S" + tableNumber)))
                {
                    SqlDataAdapter dataAdapter;
                    var select = "SELECT TOP 20 * FROM " + tableName;
                    var c = ourDB.connection; // Your Connection String here
                    dataAdapter = new SqlDataAdapter(select, c);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds);
                    //questionResult.ReadOnly = true;
                    questionResult.DataSource = ds.Tables[0];
                    oldRowCount = ds.Tables[0].Rows.Count;
                    searchButton.Visible = true;
                }
                else questionResult.DataSource = null;
                if (powers.Contains("u" + tableNumber) || powers.Contains("U" + tableNumber))
                {
                    questionResult.ReadOnly = false;
                }
                if (powers.Contains("i" + tableNumber) || powers.Contains("I" + tableNumber))
                {
                    if (questionResult.DataSource == null)
                    {
                        SqlDataAdapter dataAdapter;
                        var select = "SELECT TOP 0 * FROM " + tableName;
                        var c = ourDB.connection; // Your Connection String here
                        dataAdapter = new SqlDataAdapter(select, c);

                        var commandBuilder = new SqlCommandBuilder(dataAdapter);
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds);

                        questionResult.DataSource = ds.Tables[0];
                        oldRowCount = ds.Tables[0].Rows.Count;
                    } 
                    questionResult.AllowUserToAddRows = true;

                    if (!powers.Contains("u" + tableNumber) && !powers.Contains("U" + tableNumber))
                    {
                        questionResult.ReadOnly = false;

                        for (int i = 0; i < questionResult.Rows.Count - 1; i++)
                        {
                            questionResult.Rows[i].ReadOnly = true;
                        }
                    }
                }
                if (powers.Contains("d" + tableNumber) || powers.Contains("D" + tableNumber))
                {
                    questionResult.AllowUserToDeleteRows = true;
                }
                if (questionResult.DataSource != null)
                {
                    string bla = "SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'";
                    DataTable queryResult = ourDB.getData(bla);
                    if (queryResult == null) return;
                    string IDColumnName = queryResult.Rows[0][0].ToString();

                    bla = "select columnproperty(object_id('" + tableName + "'), '" + IDColumnName + "', 'IsIdentity')";
                    queryResult = ourDB.getData(bla);
                    if (queryResult == null) return;
                    string isIdentity = queryResult.Rows[0][0].ToString();
                    
                    if (isIdentity.Equals("1")) questionResult.Columns[0].ReadOnly = true;
                }
            }
            catch
            {
                MessageBox.Show("Błąd w połączeniu z bazą danych");
            }
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            logForm.Logout();
        }

        private void questionResultDeleteEvent(object sender, DataGridViewRowCancelEventArgs e)
        { 
            string tableName = tableNameActivitiesOnBase.Text;
            string bla = "SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'";
            DataTable queryResult = ourDB.getData(bla);
            if (queryResult == null) return;
            string IDColumnName = queryResult.Rows[0][0].ToString();

            String query = "";
            if (e.Row.Index < oldRowCount)
            {
                try//if (!e.Row.Cells[0].Value.Equals(""))
                {
                    int j = Convert.ToInt32(e.Row.Cells[0].Value);
                    query += "DELETE FROM " + tableName + " WHERE " + IDColumnName + " = " + j + ";";

                    ourDB.executeSettingData(new SqlCommand(query, ourDB.connection), Int32.MaxValue);
                }
                catch { }
            }
            else
            {
                newRowCount--;
                if (newRowCount > 5) addNewRowButton.Text = "Dodaj " + newRowCount + " nowych wpisów";
                else if (newRowCount > 1) addNewRowButton.Text = "Dodaj " + newRowCount + " nowe wpisy";
                else addNewRowButton.Text = "Dodaj nowy wpis";
                if (newRowCount == 0) { addNewRowButton.Visible = false; }
            }
            updateOldRowCount(tableName, true);
        }

        private void updateOldRowCount(string tableName, Boolean delete = false)
        {
            SqlDataAdapter dataAdapter;
            var select = "select top 20 * from " + tableName;// + " order by " + ColumnName + " desc;"; //"SELECT LAST 20 * FROM " + tableName;
            var c = ourDB.connection; // Your Connection String here
            dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            //questionResult.ReadOnly = true;
            if (!delete) questionResult.DataSource = ds.Tables[0];
            oldRowCount = ds.Tables[0].Rows.Count;
        }

        private Int32 oldRowCount = 0;
        private int newRowCount = 0;
        private void questionResult_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            newRowCount++;
            addNewRowButton.Visible = true;
            if (newRowCount > 1) addNewRowButton.Text = "Dodaj " + newRowCount + " nowe wpisy";
            if (newRowCount > 5) addNewRowButton.Text = "Dodaj " + newRowCount + " nowych wpisów";
        }

        private void flagSetUp_Click(object sender, EventArgs e)
        {
            FlagForm form = new FlagForm(typedLogin, ourDB);
            form.Show();
        }

        private void selectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Object o in buttonList)
                ((CheckBox)o).Checked = false;

            DataTable queryResult = ourDB.getData("SELECT WszystkiePosiadaneUprawnienia FROM Historia WHERE Biorca = '" + typedLogin + "' and CzyAktualne = 1");
            if (queryResult == null) return;

            string ownedPrivillages = queryResult.Rows[0][0].ToString();

            if (ownedPrivillages.Contains("P" + selectComboBox.SelectedIndex)) przejmij.Visible = true;
            else przejmij.Visible = false;

            if (userComboBox.SelectedIndex != -1)
                centralCheckBoxesController();
        }

       

        private void userComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectComboBox.SelectedIndex != -1) centralCheckBoxesController();
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logForm.ByeBye();
        }

        private void questionResult_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            questionResult.Rows[e.RowIndex].ReadOnly = false;
            questionResult.FirstDisplayedScrollingRowIndex = e.RowIndex;
        }

        private void passSelectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            selectCheckBox.Checked = passSelectCheckBox.Checked;
        }

        private void passUpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            updateCheckBox.Checked = passUpdateCheckBox.Checked;
        }

        private void passDeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            deleteCheckBox.Checked = passDeleteCheckBox.Checked;
        }

        private void passInsertCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            insertCheckBox.Checked = passInsertCheckBox.Checked;
        }

        private void addNewRowButton_Click(object sender, EventArgs e)
        {
            string tableName = tableNameActivitiesOnBase.Text;
            String query = "";
            String str = "";
            SqlCommand command = new SqlCommand();
            if (newRowCount > 0)
            {
                for (int j = 0; j < newRowCount; j++)
                {
                    str += query;
                    str += "Insert into " + tableName + " values(";
                    int i = 0;
                    foreach (DataGridViewCell cell in questionResult.Rows[questionResult.RowCount - 2 - j].Cells)
                    {
                        i++;
                        if (i == 1) continue;
                        str += "'" + cell.Value + "',";
                    }
                    query = str.TrimEnd(',');
                    query += ");";
                    str = "";
                }
            }
            ourDB.executeSettingData(new SqlCommand(query, ourDB.connection));

            updateOldRowCount(tableName);

            newRowCount = 0;
            addNewRowButton.Visible = false;
            addNewRowButton.Text = "Dodaj nowy wpis";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(ourDB, questionResult, oldRowCount, tableNameActivitiesOnBase.Text);
            search.Show();
        }

        private void questionResult_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < oldRowCount)
            {
                string tableName = tableNameActivitiesOnBase.Text;
                string bla = "SELECT COLUMN_NAME,* FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'";

                DataTable queryResult = ourDB.getData(bla);
                if (queryResult == null) return;
                string ColumnName = queryResult.Rows[e.ColumnIndex][0].ToString();
                string IDColumnName = queryResult.Rows[0][0].ToString();

                bla = "SELECT " + queryResult.Rows[0][0].ToString() + " FROM " + tableName;
                queryResult = ourDB.getData(bla);
                if (queryResult == null) return;
                
                int irgrg = queryResult.Rows.Count;
                string ID = queryResult.Rows[e.RowIndex][0].ToString();
                string query = "UPDATE " + tableName + " SET " + ColumnName + " = '" + questionResult[e.ColumnIndex, e.RowIndex].Value.ToString() + "' WHERE " + IDColumnName + " = " + ID;

                ourDB.executeSettingData(new SqlCommand(query, ourDB.connection));
            } 
        }
    }
}
